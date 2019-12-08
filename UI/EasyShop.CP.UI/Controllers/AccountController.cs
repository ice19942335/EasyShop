using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Domain.ViewModels.Account;
using EasyShop.Interfaces.Email;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Services.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EasyShop.CP.UI.Controllers
{
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

        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorsList = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errorsList.ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }
            
            var registrationResult = await _accountService.RegisterAsync(model, Url);

            if (!registrationResult.Success)
            {
                registrationResult.Errors.ToList().ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            if (registrationResult.RedirectToAction != null)
                return registrationResult.RedirectToAction;
            
            
            return View(model);
        }

        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorsList = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errorsList.ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }
            
            var loginResult = await _accountService.LoginAsync(model, Url);

            if (!loginResult.Success)
            {
                loginResult.Errors.ToList().ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            if (loginResult.RedirectToAction != null)
                return loginResult.RedirectToAction;
            
            if (loginResult.LocalRedirect != null)
                return LocalRedirect(loginResult.LocalRedirect);
            
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation($"User: {User.Identity.Name} has been logged out.");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmailConfirmationLink()
        {
            var sendLinkResult = await _accountService.SendEmailConfirmationLinkAsync(User.Identity.Name, Url);

            if (!sendLinkResult.Success)
                return RedirectToAction("SomethingWentWrong", "UserProfile");

            return RedirectToAction("EmailConfirmationRequestHasBeenSent", "UserProfile");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
                return View(nameof(AccessDenied));

            var confirmationResult = await _accountService.ConfirmEmail(userId, token);

            if (confirmationResult.RedirectToAction != null)
            {
                if (!confirmationResult.Success)
                    return confirmationResult.RedirectToAction;

                return confirmationResult.RedirectToAction;
            }

            return RedirectToAction("ErrorStatus", "Home", new { id = 404 }, null);
        }

        [HttpGet]
        public IActionResult ForgotPassword() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _accountService.SendPasswordResetLink(model, Url);

            return result.RedirectToAction;
        }

        [HttpGet]
        public IActionResult ResetPassword(string token = null)
        {
            return token == null ? View("AccessDenied") : View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList()
                    .ForEach(x => ModelState.AddModelError("", x));

                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
                return RedirectToAction("ErrorStatus", "Home", new { id = 404 }, null);
            
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

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

        [HttpGet]
        public IActionResult AccessDenied() => View();

        [HttpGet]
        public IActionResult EmailHaveToBeConfirmed() => View();

        [HttpGet]
        public IActionResult PasswordResetRequestHasBeenSent() => View();
    }
}