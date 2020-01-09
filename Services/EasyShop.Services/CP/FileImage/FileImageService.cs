using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.User.UserProfile;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Interfaces.Services.CP.FileImage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Services.CP.FileImage
{
    public class FileImageService : IFileImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileImageService(IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUniqueFileName(string filename)
        {
            filename = Path.GetFileName(filename);
            return Path.GetFileNameWithoutExtension(filename)
                   + "_"
                   + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(filename);
        }

        public IEnumerable<string> GetImageNames(string folder)
        {
            return Directory.EnumerateFiles(Path.Combine(_environment.WebRootPath, folder))
                .Select(path => Path.GetFileName(path));
        }

        public async Task<string> SaveFile(IFormFile imgFile, string folder)
        {
            var imagesFolder = Path.Combine(_environment.WebRootPath, folder);

            if (imgFile.Length <= 0)
                return null;

            var type = imgFile.ContentType.Split("/")[1];

            if (type == "jpeg" || type == "jpg" || type == "png" || imgFile.Length < 10000000)
            {
                var uniqueFileName = GetUniqueFileName($"image_{_httpContextAccessor.HttpContext.User.Identity.Name}_{imgFile.FileName}");
                var filePathUploadsImages = Path.Combine(imagesFolder, uniqueFileName);

                await using var stream = new FileStream(filePathUploadsImages, FileMode.Create);
                await imgFile.CopyToAsync(stream);

                return uniqueFileName;
            }

            return null;
        }
    }
}
