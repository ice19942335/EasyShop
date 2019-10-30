using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.User.UserProfile;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Interfaces.Services.CP
{
    public interface IUserProfileServiceSql
    {
        Task<UserProfileViewModel> UpdateUserData(UserProfileViewModel model);
    }
}
