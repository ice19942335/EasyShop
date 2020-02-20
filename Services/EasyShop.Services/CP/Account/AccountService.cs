using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EasyShop.Domain.Dto.CP.Account;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.ControlPanel.Account;
using EasyShop.Interfaces.Email;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Interfaces.Services.CP.Account;
using EasyShop.Services.Data.FirstRunInitialization.IdentityInitialization;
using EasyShop.Services.Email;
using EasyShop.Services.ExtensionMethods;
using EasyShop.Services.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SendGrid;

// ReSharper disable Mvc.ViewNotResolved

namespace EasyShop.Services.CP.Account
{
    public class AccountService : Controller, IAccountService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountService> _logger;
        private readonly ISendGridEmailSender _sendGridEmailSender;
        private readonly ISmtpEmailSender _smtpEmailSender;

        public AccountService(
            IHttpContextAccessor httpContextAccessor,
            IWebHostEnvironment environment,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AccountService> logger,
            ISendGridEmailSender sendGridEmailSender,
            ISmtpEmailSender smtpEmailSender)
        {
            _httpContextAccessor = httpContextAccessor;
            _environment = environment;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _sendGridEmailSender = sendGridEmailSender;
            _smtpEmailSender = smtpEmailSender;
        }

        public async Task<AccountDto> RegisterAsync(RegisterUserViewModel model, IUrlHelper url)
        {
            var profileImage = DefaultPictureNameHelper.GetDefaultPictureName(model.Gender);

            var newUser = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.Firstname,
                LastName = model.LastName,
                BirthDate = new DateTime(model.Year, model.Day, int.Parse(model.Month)),
                Gender = model.Gender,
                RegistrationDate = DateTime.Now,
                ProfileImage = profileImage,
                TransactionPercent = 3,
                ShopsAllowed = 10,
                UsingTariff = false
            };

            var creationResult = await _userManager.CreateAsync(newUser, model.Password);

            if (creationResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, DefaultIdentity.RoleUser);

                var userForLog = await _userManager.FindByEmailAsync(newUser.Email);
                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    userForLog.UserName,
                    userForLog.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    "Successfully registered in system.");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

                var callbackUrl = url.Action(
                    "ConfirmEmail",
                    "Account",
                    new { userId = newUser.Id, token = code },
                    protocol: _httpContextAccessor.HttpContext.Request.Scheme);

                var sendEmailConfirmationResponse = await SendMailAsync(newUser, "Email confirmation", "EmailConfirmationLink", "txt", "Interpolation", "callbackUrl", callbackUrl);

                if (sendEmailConfirmationResponse)
                {
                    await _signInManager.SignInAsync(newUser, false);
                    return new AccountDto { RedirectToAction = RedirectToAction("EmailConfirmation", "UserProfile") };
                }

                await _userManager.DeleteAsync(newUser);
                return new AccountDto { ReturnToView = View("SomethingWentWrong", "link sending") };
            }

            _logger.LogWarning("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                "Null",
                "Null",
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                string.Join("", creationResult.Errors.Select(x => "\n" + x.Description)));

            foreach (var error in creationResult.Errors)
                ModelState.AddModelError("", error.Description);

            return new AccountDto { ReturnToView = View(model) };
        }

        public async Task<AccountDto> LoginAsync(LoginUserViewModel model, IUrlHelper url)
        {
            var loginResult = await _signInManager
                .PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            var userForLog = await _userManager.FindByEmailAsync(model.UserName);

            if (loginResult.Succeeded)
            {
                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    userForLog.UserName,
                    userForLog.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    "Successfully logged in.");

                var user = await _userManager.FindByNameAsync(model.UserName);

                if (!await _userManager.IsEmailConfirmedAsync(user))
                    return new AccountDto { RedirectToAction = RedirectToAction("EmailConfirmation", "UserProfile"), };

                if (url.IsLocalUrl(model.ReturnUrl))
                    return new AccountDto { LocalRedirect = model.ReturnUrl };

                return new AccountDto { RedirectToAction = RedirectToAction("Index", "Home"), };
            }

            _logger.LogWarning("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                userForLog != null ? userForLog.FirstName : "Null",
                userForLog != null ? userForLog.Id : "Null",
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"Login error! Is locked out: {loginResult.IsLockedOut}. Is not allowed: {loginResult.IsNotAllowed}");

            ModelState.AddModelError("", "Username or password is incorrect, please try again.");

            return new AccountDto { ReturnToView = View(model) };
        }

        public async Task<AccountDto> SendEmailConfirmationLinkAsync(string userName, IUrlHelper url)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user is null)
                return new AccountDto
                {
                    RedirectToAction = RedirectToAction("ErrorStatus", "Home", new { id = 404 }, null)
                };

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = user.Id, token = token },
                protocol: _httpContextAccessor.HttpContext.Request.Scheme);

            var sendEmailConfirmationLinkResponse = await SendMailAsync(user, "Email confirmation", "EmailConfirmationLink", "txt", "Interpolation", "callbackUrl", callbackUrl);

            if (sendEmailConfirmationLinkResponse)
            {
                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    user.FirstName,
                    user.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    "Confirmation link was sent");

                return new AccountDto
                {
                    RedirectToAction = RedirectToAction("EmailConfirmationRequestHasBeenSent", "UserProfile")
                };
            }

            return new AccountDto
            {
                ReturnToView = RedirectToAction("SomethingWentWrong", "UserProfile")
            };
        }

        public async Task<AccountDto> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
            {
                _logger.LogWarning("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    "Null",
                    "Null",
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    "User not found.");
                return new AccountDto { RedirectToAction = RedirectToAction("AccessDenied", "Account") };
            }


            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded)
            {
                _logger.LogWarning("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    user.FirstName,
                    user.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    string.Join(", ", result.Errors.Select(e => e.Description)));

                return new AccountDto { RedirectToAction = RedirectToAction("AccessDenied", "Account") };
            }

            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                user.FirstName,
                user.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                "Email success-fully confirmed.");

            return new AccountDto
            {
                RedirectToAction = RedirectToAction("Dashboard", "ControlPanel"),
            };
        }

        public async Task<AccountDto> SendPasswordResetLink(ForgotPasswordViewModel model, IUrlHelper url)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.IsEmailConfirmedAsync(user))
            {
                if (model.Authenticated)
                    return new AccountDto { RedirectToAction = RedirectToAction("EmailHaveToBeConfirmed", "UserProfile") };

                return new AccountDto { RedirectToAction = RedirectToAction("EmailHaveToBeConfirmed", "Account") };
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = url.Action("ResetPassword",
                "Account",
                new { userId = user.Id, token = token },
                protocol: _httpContextAccessor.HttpContext.Request.Scheme);

            var response = await SendMailAsync(user, "Password reset", "PasswordResetLink", "txt", "Interpolation", "callbackUrl", callbackUrl);

            if (response)
            {
                if (model.Authenticated)
                {
                    _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                        user != null ? user.FirstName : "Null",
                        user != null ? user.Id : "Null",
                        _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                        $"Password reset request link was sent to user, Callback-link: {callbackUrl}");

                    return new AccountDto { RedirectToAction = RedirectToAction("PasswordResetRequestHasBeenSent", "UserProfile") };
                }

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    user != null ? user.FirstName : "Null",
                    user != null ? user.Id : "Null",
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Password reset request link was sent to user, Callback-link: {callbackUrl}");

                return new AccountDto { RedirectToAction = RedirectToAction("PasswordResetRequestHasBeenSent", "Account") };
            }

            return new AccountDto { ReturnToView = View("SomethingWentWrong", "link sending") };
        }

        public async Task<AccountDto> ResetPasswordAsync(string userId, PasswordResetViewModel model, IUrlHelper url)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return new AccountDto { RedirectToAction = RedirectToAction("ErrorStatus", "Home", new { id = 404 }) };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = url.Action("ResetPassword",
                "Account",
                new { userId = user.Id, token = token },
                protocol: _httpContextAccessor.HttpContext.Request.Scheme);

            var response = await SendMailAsync(user, "Password reset", "PasswordHasBeenChangedNotification", "txt", "Interpolation", "callbackUrl", callbackUrl);

            if (response)
            {
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                        user.FirstName,
                        user.Id,
                        _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                        "Password has been successfully changed.");

                    await _httpContextAccessor.HttpContext.SignOutAsync();

                    return new AccountDto { RedirectToAction = RedirectToAction("ResetPasswordConfirmation", "Account") };
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                _logger.LogWarning("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    user.FirstName,
                    user.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Password reset fail, Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");

                return new AccountDto { ReturnToView = View(model) };
            }

            return new AccountDto { ReturnToView = View("SomethingWentWrong", "link sending") };
        }

        private async Task<bool> SendMailAsync(AppUser user, string subject, string filename, string fileType, string folderNameInRoot, string key, string value)
        {
            Dictionary<string, string> data = new Dictionary<string, string> { { key, value } };

            var fileInsertDataHelper = new FileInsertDataHelper(
                _environment,
                filename,
                fileType,
                folderNameInRoot,
                data);

            var html = await fileInsertDataHelper.GetResult();

            var result = await _smtpEmailSender.SendEmailAsync(user.Email, $"Monetization | {subject}", html);

            return result;
        }
    }
}
