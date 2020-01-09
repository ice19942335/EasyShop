using System.Collections.Generic;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.User.UserProfile;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Interfaces.Services.CP.FileImage
{
    public interface IFileImageService
    {
        string GetUniqueFileName(string filename);

        IEnumerable<string> GetImageNames(string folder);

        Task<string> SaveFile(IFormFile imgFile, string folder);
    }
}
