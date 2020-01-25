using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.CP.Account;
using EasyShop.Interfaces.Email;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Interfaces.Services.CP.Account;
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
        private readonly ISendGridEmailSender _sendGridEmailSender;
        private readonly IAccountService _accountService;

        public AccountController(
            IWebHostEnvironment environment,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AccountController> logger, 
            ISendGridEmailSender sendGridEmailSender,
            IAccountService accountService)
        {
            _environment = environment;
            _userManager = userManager; 
            _signInManager = signInManager;
            _logger = logger;
            _sendGridEmailSender = sendGridEmailSender;
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

            return registrationResult.RedirectToAction ?? registrationResult.ReturnToView;
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

            if (loginResult.LocalRedirect != null)
                return LocalRedirect(loginResult.LocalRedirect);

            return loginResult.RedirectToAction ?? loginResult.ReturnToView;
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

            return sendLinkResult.RedirectToAction ?? sendLinkResult.ReturnToView;
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
                return View(nameof(AccessDenied));

            var confirmationResult = await _accountService.ConfirmEmail(userId, token);

            return confirmationResult.RedirectToAction;
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

            return result.RedirectToAction ?? result.ReturnToView;
        }

        [HttpGet]
        public IActionResult ResetPassword(string token = null)
        {
            return token == null ? View("AccessDenied") : View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromQuery] string userId, PasswordResetViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList()
                    .ForEach(x => ModelState.AddModelError("", x));

                return View(model);
            }

            var resetResult = await _accountService.ResetPasswordAsync(userId, model, Url);

            return resetResult.RedirectToAction ?? resetResult.ReturnToView;
        }

        [HttpGet]
        public IActionResult AccessDenied() => View();

        [HttpGet]
        public IActionResult EmailHaveToBeConfirmed() => View();

        [HttpGet]
        public IActionResult PasswordResetRequestHasBeenSent() => View();

        [HttpGet]
        public IActionResult ResetPasswordConfirmation() => View();
    }
}