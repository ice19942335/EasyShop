using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Domain.ViewModels.Account;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IEmailSender _emailSender;

        public AccountController(
            IWebHostEnvironment environment,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger, 
            IEmailSender emailSender)
        {
            _environment = environment;
            _userManager = userManager; 
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
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

            using (_logger.BeginScope($"Date({DateTime.Now}) New user registration: {model.Email}"))
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.Firstname,
                    LastName = model.LastName,
                    BirthDate = new DateTime(model.Year, model.Day, Int32.Parse(model.Month)),
                    Gender = model.Gender,
                    TransactionPercent = 1,
                    ShopsAllowed = 10,
                    RegistrationDate = DateTime.Now
                };

                var creationResult = await _userManager.CreateAsync(user, model.Password);

                if (creationResult.Succeeded)
                {
                    _logger.LogInformation($"User: {model.Email} successfully registered in system.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new {userId = user.Id, code = code},
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

                    await _signInManager.SignInAsync(user, false);

                    return RedirectToAction("EmailConfirmation", "UserProfile");
                }

                foreach (var error in creationResult.Errors)
                    ModelState.AddModelError("", error.Description);

                _logger.LogWarning(
                    "Registration error, User: {0}, Errors: {1}",
                    model.Email,
                    string.Join(",\n", creationResult.Errors.Select(err => err.Description))
                );
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