using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.CP.Profile;
using EasyShop.Domain.ViewModels.CP.User.UserProfile;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Interfaces.Services.CP.FileImage;
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
        private readonly IFileImageService _fileImageService;

        public UserProfileService(
            UserManager<AppUser> userManager,
            EasyShopContext context,
            ILogger<UserProfileService> logger,
            IHttpContextAccessor httpContextAccessor,
            IFileImageService fileImageService)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _fileImageService = fileImageService;
        }

        public async Task<UpdateUserProfileEnum> UpdateUserData(UserProfileViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                _logger.LogError("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    "Null",
                    "Null",
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"User data was successfully updated");

                return UpdateUserProfileEnum.UserNotFound;
            }

            using (_logger.BeginScope($"User profile data update: {model.Email}"))
            {
                if (model.ImageToUpload != null)
                {
                    string profileImageName = model.ImgUrl;

                    var saveFileResult = await _fileImageService.SaveFile(model.ImageToUpload, "UserImages");
                    model.ImgUrl = saveFileResult;

                    if (saveFileResult is null)
                        return UpdateUserProfileEnum.ImageSizeIsTooBig;

                    if (!DefaultPictureNameHelper.DefaultPictures.Contains(profileImageName))
                        _fileImageService.DeleteImage(profileImageName, "UserImages");

                    var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
                    _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                        userForLog.UserName,
                        userForLog.Id,
                        _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                        $"New picture was successfully saved. Picture name: {saveFileResult}");
                }

                var updatedUser = model.CreateApplicationUser(user);

                await _userManager.UpdateAsync(updatedUser);

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    user.UserName,
                    user.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"User data was successfully updated");

                return UpdateUserProfileEnum.Updated;
            }
        }
    }
}
