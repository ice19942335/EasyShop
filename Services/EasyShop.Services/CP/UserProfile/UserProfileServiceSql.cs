using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.User.UserProfile;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Services.Mappers.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.Logging;

namespace EasyShop.Services.CP.UserProfile
{
    public class UserProfileServiceSql : IUserProfileServiceSql
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly EasyShopContext _context;
        private readonly ILogger<UserProfileServiceSql> _logger;

        public UserProfileServiceSql(
            UserManager<AppUser> userManager,
            EasyShopContext context,
            ILogger<UserProfileServiceSql> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
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

                _logger.LogInformation($"User: {user.Email} data was successfully updated.");

                return updatedUser.CreateViewModel();
            }
        }

        public bool UploadProfilePicture(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
