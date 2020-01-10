using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Interfaces.Services.CP.FileImage
{
    public interface IFileImageService
    {
        string GetUniqueFileName(string filename);

        IEnumerable<string> GetImageNames(string folder);

        Task<string> SaveFile(IFormFile imgFile, string folder);

        void DeleteImage(string fileName, string folder);
    }
}
