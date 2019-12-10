using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EasyShop.Domain.Dto.CP.Account;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Domain.ViewModels.Account;
using EasyShop.Interfaces.Email;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Services.ExtensionMethods;
using EasyShop.Services.Files;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SendGrid;

// ReSharper disable Mvc.ViewNotResolved

namespace EasyShop.Services.CP.Account
{
    public class AccountService : Controller, IAccountService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountService> _logger;
        private readonly ISendGridEmailSender _sendGridEmailSender;

        public AccountService(
            IHttpContextAccessor httpContext,
            IWebHostEnvironment environment,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AccountService> logger,
            ISendGridEmailSender sendGridEmailSender)
        {
            _httpContext = httpContext;
            _environment = environment;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _sendGridEmailSender = sendGridEmailSender;
        }

        public async Task<AccountDto> RegisterAsync(RegisterUserViewModel model, IUrlHelper url)
        {
            using (_logger.BeginScope($"New user registration: {model.Email}"))
            {
                var profileImage = DefaultPictureNameHelper.GetDefaultPictureName(model.Gender);

                var user = new AppUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.Firstname,
                    LastName = model.LastName,
                    BirthDate = new DateTime(model.Year, model.Day, Int32.Parse(model.Month)),
                    Gender = model.Gender,
                    TransactionPercent = 1,
                    ShopsAllowed = 2,
                    RegistrationDate = DateTime.Now,
                    ProfileImage = profileImage
                };

                var creationResult = await _userManager.CreateAsync(user, model.Password);

                if (creationResult.Succeeded)
                {
                    _logger.LogInformation($"User: {model.Email} successfully registered in system.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { userId = user.Id, token = code },
                        protocol: _httpContext.HttpContext.Request.Scheme);

                    var response = await SendMailAsync(user, "Email confirmation", "EmailConfirmationLink", "txt", "Interpolation", "callbackUrl", callbackUrl);

                    if (response.StatusCode == HttpStatusCode.Accepted)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return new AccountDto { RedirectToAction = RedirectToAction("EmailConfirmation", "UserProfile") };
                    }

                    return new AccountDto { ReturnToView = View("SomethingWentWrong", "link sending") };
                }

                _logger.LogWarning(
                    "Registration error, User: {0}, Errors: {1}",
                    model.Email,
                    string.Join(",\n", creationResult.Errors.Select(err => err.Description))
                );

                foreach (var error in creationResult.Errors)
                    ModelState.AddModelError("", error.Description);

                return new AccountDto { ReturnToView = View(model) };
            }
        }

        public async Task<AccountDto> LoginAsync(LoginUserViewModel model, IUrlHelper url)
        {
            var loginResult = await _signInManager
                .PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (loginResult.Succeeded)
            {
                _logger.LogInformation($"User: {model.UserName} successfully logged in.");

                var user = await _userManager.FindByNameAsync(model.UserName);

                if (!await _userManager.IsEmailConfirmedAsync(user))
                    return new AccountDto { RedirectToAction = RedirectToAction("EmailConfirmation", "UserProfile"), };

                if (url.IsLocalUrl(model.ReturnUrl))
                    return new AccountDto { LocalRedirect = model.ReturnUrl };

                return new AccountDto { RedirectToAction = RedirectToAction("Index", "Home"), };
            }

            _logger.LogWarning($"User: {model.UserName} login error.");

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
                protocol: _httpContext.HttpContext.Request.Scheme);

            var response = await SendMailAsync(user, "Email confirmation", "EmailConfirmationLink", "txt", "Interpolation", "callbackUrl", callbackUrl);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                _logger.LogInformation($"Confirmation link was sent to User: {userName}, Confirmation link: {callbackUrl}");
                return new AccountDto
                {
                    RedirectToAction = RedirectToAction("EmailConfirmationRequestHasBeenSent", "UserProfile")
                };
            }

            return new AccountDto
            {
                ReturnToView = View("SomethingWentWrong", "link sending")
            };
        }

        public async Task<AccountDto> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return new AccountDto
                {
                    RedirectToAction = RedirectToAction("AccessDenied", "Account")
                };

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded)
            {
                _logger.LogWarning(
                    "Date ({0}) User: {1} email confirmation failed. Errors: {2}",
                    DateTime.Now,
                    user.UserName,
                    string.Join(", ", result.Errors.Select(e => e.Description))
                );
                return new AccountDto { RedirectToAction = RedirectToAction("AccessDenied", "Account") };
            }

            _logger.LogInformation($"User: {user.UserName} successfully confirmed email");
            return new AccountDto
            {
                RedirectToAction = RedirectToAction("EmailConfirmation", "UserProfile"),
            };
        }

        public async Task<AccountDto> SendPasswordResetLink(ForgotPasswordViewModel model, IUrlHelper url)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.IsEmailConfirmedAsync(user))
                return new AccountDto { RedirectToAction = RedirectToAction("EmailHaveToBeConfirmed", "Account") };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = url.Action("ResetPassword",
                "Account",
                new { userId = user.Id, token = token },
                protocol: _httpContext.HttpContext.Request.Scheme);

            var response = await SendMailAsync(user, "Password reset", "PasswordResetLink", "txt", "Interpolation", "callbackUrl", callbackUrl);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                if (model.Authenticated)
                {
                    _logger.LogInformation($"Password reset request link was sent to User: {user.UserName}, Link: {callbackUrl}");
                    return new AccountDto { RedirectToAction = RedirectToAction("PasswordResetRequestHasBeenSent", "UserProfile") };
                }

                _logger.LogInformation($"Password reset request link was sent to User: {user.UserName}, Link: {callbackUrl}");
                return new AccountDto { RedirectToAction = RedirectToAction("PasswordResetRequestHasBeenSent", "Account") };
            }

            return new AccountDto { ReturnToView = View("SomethindWentWrong", "link sending") };
        }

        public async Task<AccountDto> ResetPasswordAsync(string userId, PasswordResetViewModel model, IUrlHelper url)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return new AccountDto
                {
                    RedirectToAction = RedirectToAction("ErrorStatus", "Home", new { id = 404 }, null)
                };


            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = url.Action("ResetPassword",
                "Account",
                new { userId = user.Id, token = token },
                protocol: _httpContext.HttpContext.Request.Scheme);

            var response = await SendMailAsync(user, "Password reset", "PasswordHasBeenChangedNotification", "txt", "Interpolation", "callbackUrl", callbackUrl);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation($"User: {user.UserName}, Password has been successfully changed.");
                    return new AccountDto { RedirectToAction = RedirectToAction("ResetPasswordConfirmation", "Account") };
                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);

                    _logger.LogWarning($"User: {user.UserName}, Password reset fail, Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    return new AccountDto { ReturnToView = View(model) };
                }
            }
            else
            {
                _logger.LogWarning($"User: {user.UserName}, $Password reset fail, Errors: Send grid response status code: {response.StatusCode}");
                return new AccountDto { ReturnToView = View("SomethindWentWrong", "link sending") };
            }
        }

        private async Task<Response> SendMailAsync(AppUser user, string subject, string filename, string fileType, string folderNameInRoot, string key, string value)
        {
            Dictionary<string, string> data = new Dictionary<string, string> { { key, value } };

            var fileInsertDataHelper = new FileInsertDataHelper(
                _environment,
                filename,
                fileType,
                folderNameInRoot,
                data);

            var html = await fileInsertDataHelper.GetResult();

            return await _sendGridEmailSender.SendEmailAsync(user.Email, $"Monetization | {subject}", html);
        }
    }
}
