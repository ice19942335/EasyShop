using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Dto.CP.Account;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Domain.ViewModels.Account;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Services.ExtensionMethods;
using EasyShop.Services.Files;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
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

        public async Task<AccountRegistrationDto> Register(RegisterUserViewModel model, IUrlHelper url)
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

                    return new AccountRegistrationDto
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

                return new AccountRegistrationDto { Errors = creationResult.Errors.Select(x => x.Description) };
            }
        }
    }
}
