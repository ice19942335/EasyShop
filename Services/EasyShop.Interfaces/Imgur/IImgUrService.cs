using System.Threading.Tasks;
using Imgur.API.Models;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Interfaces.Imgur
{
    public interface IImgUrService
    {
        Task<IImage> UploadImageAsync(IFormFile imageToUpload);

        Task DeleteImageAsync(string hash);
    }
}
