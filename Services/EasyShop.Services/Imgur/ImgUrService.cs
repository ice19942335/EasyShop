using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Settings;
using EasyShop.Interfaces.Imgur;
using EasyShop.Services.ExtensionMethods;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace EasyShop.Services.Imgur
{
    public class ImgUrService : IImgUrService
    {
        private readonly ILogger<ImgUrService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly ImgurSettings _imgurSettings;
        private readonly AppUser _appUser;

        public ImgUrService(ILogger<ImgUrService> logger, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, ImgurSettings imgurSettings)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _imgurSettings = imgurSettings;
            _appUser = userManager.FindByEmailAsync(httpContextAccessor.HttpContext.User.Identity.Name).Result;
        }

        public async Task<IImage> UploadImageAsync(IFormFile imageToUpload)
        {
            try
            {
                byte[] imageByteArray;
                await using (var fileStream = imageToUpload.OpenReadStream())
                await using (var memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    imageByteArray = memoryStream.ToArray();
                }

                var client = new ImgurClient(_imgurSettings.ClientId);
                var endpoint = new ImageEndpoint(client);
                //var file = File.ReadAllBytes(@"IMAGE_LOCATION");
                var image = await endpoint.UploadImageBinaryAsync(imageByteArray);

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    _appUser != null ? _appUser.UserName : "Null",
                    _appUser != null ? _appUser.Id : "Null",
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Image was success-fully uploaded.");

                return image;
            }
            catch (Exception e)
            {
                _logger.LogError("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    _appUser != null ? _appUser.UserName : "Null",
                    _appUser != null ? _appUser.Id : "Null",
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Error on uploading picture. Error: {e.Message}; Inner exception: {e.InnerException?.Message}; Stacktrace:\n{e.StackTrace};");
                return null;
            }
        }

        public async Task DeleteImageAsync(string hash)
        {
            var client = new ImgurClient(_imgurSettings.ClientId);
            var endpoint = new ImageEndpoint(client);
            var result = await endpoint.UpdateImageAsync(hash);

            if (!result)
            {
                _logger.LogError("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    _appUser != null ? _appUser.UserName : "Null",
                    _appUser != null ? _appUser.Id : "Null",
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    "Error picture deletion.");
            }
        }
    }
}
