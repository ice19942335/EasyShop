using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
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
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;

namespace EasyShop.Services.CP.Account
{
    public class AccountService : IAccountService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountService> _logger;
        private readonly IEmailSender _emailSender;

        public AccountService(
            IHttpContextAccessor httpContext,
            IWebHostEnvironment environment,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<AccountService> logger,
            IEmailSender emailSender)
        {
            _httpContext = httpContext;
            _environment = environment;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
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
                        new { userId = user.Id, code = code },
                        protocol: _httpContext.HttpContext.Request.Scheme);

                    Dictionary<string, string> data = new Dictionary<string, string> { { "callbackUrl", callbackUrl } };

                    var fileInsertDataHelper = new FileInsertDataHelper(
                        _environment,
                        "EmailConfirmationLink",
                        "txt",
                        "Interpolation",
                        data);

                    await _emailSender.SendEmailAsync(
                        user.Email,
                        "E-mail confirmation Monetization",
                        fileInsertDataHelper.GetResult().Result);

                    await _signInManager.SignInAsync(user, false);

                    return new AccountDto
                    {
                        RedirectToAction = new Dictionary<string, string> { { "EmailConfirmation", "UserProfile" } },
                        Success = true
                    };
                }

                _logger.LogWarning(
                    "Registration error, User: {0}, Errors: {1}",
                    model.Email,
                    string.Join(",\n", creationResult.Errors.Select(err => err.Description))
                );

                return new AccountDto { Errors = creationResult.Errors.Select(x => x.Description) };
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
                    return new AccountDto
                    {
                        RedirectToAction = new Dictionary<string, string> { { "EmailConfirmation", "UserProfile" } },
                        Success = true
                    };

                if (url.IsLocalUrl(model.ReturnUrl))
                    return new AccountDto
                    {
                        LocalRedirect = model.ReturnUrl,
                        Success = true
                    };

                return new AccountDto
                {
                    RedirectToAction = new Dictionary<string, string> { { "Index", "Home" } },
                    Success = true
                };
            }

            _logger.LogWarning($"User: {model.UserName} login error.");
            return new AccountDto { Errors = new[] { "Username or password is incorrect, please try again." } };
        }

        public async Task<AccountDto> SendEmailConfirmationLinkAsync(string userName, IUrlHelper url)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user is null)
                return new AccountDto();

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = url.Action(
                "ConfirmEmail",
                "Account",
                new { userId = user.Id, code = code },
                protocol: _httpContext.HttpContext.Request.Scheme);

            var data = new Dictionary<string, string> { { "callbackUrl", callbackUrl } };
            var fileInsertDataHelper = new FileInsertDataHelper(
                _environment,
                "EmailConfirmationLink",
                "txt",
                "Interpolation",
                data);

            var response = await _emailSender.SendEmailAsync(
                user.Email,
                "Monetization | Confirm E-mail",
                fileInsertDataHelper.GetResult().Result);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                _logger.LogInformation($"Confirmation link was sent to User: {userName}, Confirmation link: {callbackUrl}");
                return new AccountDto { Success = true };
            }

            return new AccountDto();
        }
    }
}
