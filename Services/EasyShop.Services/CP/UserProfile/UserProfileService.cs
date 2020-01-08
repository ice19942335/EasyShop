using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.User.UserProfile;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Interfaces.Services.CP.UserProfile;
using EasyShop.Services.ExtensionMethods;
using EasyShop.Services.Mappers.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.Logging;

namespace EasyShop.Services.CP.UserProfile
{
    public class UserProfileService : IUserProfileService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly EasyShopContext _context;
        private readonly ILogger<UserProfileService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserProfileService(
            UserManager<AppUser> userManager,
            EasyShopContext context,
            ILogger<UserProfileService> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserProfileViewModel> UpdateUserData(UserProfileViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            using (_logger.BeginScope($"User profile data update: {model.Email}"))
            {
                if (user is null)
                    throw new ApplicationException("Error on UserProfile data update. Error: user is null");

                var updatedUser = model.CreateApplicationUser(user);

                await _userManager.UpdateAsync(updatedUser);


                //var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    user.UserName,
                    user.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"User data was successfully updated");

                return updatedUser.CreateViewModel();
            }
        }
    }
}
