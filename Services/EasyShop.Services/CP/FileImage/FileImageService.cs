using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.User.UserProfile;
using EasyShop.Interfaces.Services.CP;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Services.CP.FileImage
{
    public class FileImageService : IFileImageService
    {
        private readonly IWebHostEnvironment _environment;

        public FileImageService(IWebHostEnvironment environment) => _environment = environment;

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

        public async Task<string?> SaveFile(UserProfileViewModel model, string folder)
        {
            var imagesFolder = Path.Combine(_environment.WebRootPath, folder);

            if (model.ImageToUpload.Length <= 0)
                return null;

            var type = model.ImageToUpload.ContentType.Split("/")[1];

            if (type == "jpeg" || type == "jpg" || type == "png")
            {
                // full path to file in temp location
                var filePath = Path.GetTempFileName();
                var uniqueFileName = GetUniqueFileName($"image_{model.Email}_{model.ImageToUpload.FileName}");
                var filePathUploadsImages = Path.Combine(imagesFolder, uniqueFileName);

                await using var stream = new FileStream(filePathUploadsImages, FileMode.Create);
                await model.ImageToUpload.CopyToAsync(stream);

                return uniqueFileName;
            }

            return null;
        }
    }
}
