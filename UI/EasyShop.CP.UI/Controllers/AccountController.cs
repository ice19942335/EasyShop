using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Domain.ViewModels.Account;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Services.CP.Account;
using EasyShop.Services.ExtensionMethods;
using EasyShop.Services.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IAccountService _accountService;

        public AccountController(
            IWebHostEnvironment environment,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AccountController> logger, 
            IEmailSender emailSender,
            IAccountService accountService)
        {
            _environment = environment;
            _userManager = userManager; 
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _accountService = accountService;
        }

        [AllowAnonymous]
        public IActionResult Register() => View();

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _accountService.Register(model, Url);

            if (!result.Success)
            {
                result.Errors.ToList().ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            if (result.RedirectToAction != null)
            {
                var redirectData = result.RedirectToAction.First();
                return RedirectToAction(redirectData.Key, redirectData.Value);
            }
            
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login() => View();

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var loginResult = await _signInManager
                .PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (loginResult.Succeeded)
            {
                _logger.LogInformation($"User: {model.UserName} successfully logged in.");

                var user = await _userManager.FindByNameAsync(model.UserName);

                if (!await _userManager.IsEmailConfirmedAsync(user))
                    return RedirectToAction("EmailConfirmation", "UserProfile");

                if (Url.IsLocalUrl(model.ReturnUrl))
                    return LocalRedirect(model.ReturnUrl);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Username or password is incorrect, please try again.");

            _logger.LogWarning($"User: {model.UserName} login error.");

            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation($"User: {User.Identity.Name} has been logged out.");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if(userId == null || code == null)
                return View(nameof(AccessDenied));

            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return View(nameof(AccessDenied));

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                _logger.LogInformation($"User: {user.UserName} successfully confirmed email");
                return RedirectToAction("EmailConfirmation", "UserProfile");
            }
            else
            {
                _logger.LogWarning(
                    "Date ({0}) User: {1} email confirmation failed. Errors: {2}",
                    DateTime.Now,
                    user.UserName,
                    string.Join(", ", result.Errors.Select(e => e.Description))
                );
                return View(nameof(AccessDenied));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmailConfirmationLink([FromQuery] string userName)
        {

            var user = await _userManager.FindByNameAsync(userName);

            if (user is null)
                return View(nameof(AccessDenied));

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Action(
                nameof(ConfirmEmail),
                "Account",
                new { userId = user.Id, code = code },
                protocol: HttpContext.Request.Scheme);

            Dictionary<string, string> data = new Dictionary<string, string>
            {
                { "callbackUrl", callbackUrl }
            };

            var fileInsertDataHelper = new FileInsertDataHelper(
                _environment,
                "EmailConfirmationLink",
                "txt", 
                "Interpolation",
                data);

            await _emailSender.SendEmailAsync(
                user.Email,
                "Monetization | Confirm E-mail",
                fileInsertDataHelper.GetResult().Result);

            _logger.LogInformation($"Confirmation link was sent to User: {userName}, Confirmation link: {callbackUrl}");

            return RedirectToAction("EmailConfirmationRequestHasBeenSent", "UserProfile");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.IsEmailConfirmedAsync(user))
                return View("ForgotPasswordConfirmation");

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword",
                "Account",
                new {userId = user.Id, code = code},
                protocol: HttpContext.Request.Scheme);

            Dictionary<string, string> data = new Dictionary<string, string>
            {
                { "callbackUrl", callbackUrl }
            };

            var fileInsertDataHelper = new FileInsertDataHelper(
                _environment,
                "PasswordResetLink",
                "txt",
                "Interpolation",
                data);

            await _emailSender.SendEmailAsync(
                user.Email,
                "Monetization | Confirm E-mail",
                await fileInsertDataHelper.GetResult());

            if (model.Authenticated)
                return RedirectToAction("PasswordResetRequestHasBeenSent", "UserProfile");

            _logger.LogInformation($"Password reset request link was sent to User: {user.UserName}, Link: {callbackUrl}");
            return View("ForgotPasswordConfirmation");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            return code == null ? View("AccessDenied") : View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            var user = await _userManager.FindByNameAsync(model.Email);

            if (user == null)
                return View("ResetPasswordConfirmation");
            
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation($"User: {user.UserName}, Password has been successfully changed.");
                return View("ResetPasswordConfirmation");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            _logger.LogWarning($"User: {user.UserName}, Password reset fail, Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            return View(model);
        }

        public IActionResult AccessDenied() => View();
    }
}