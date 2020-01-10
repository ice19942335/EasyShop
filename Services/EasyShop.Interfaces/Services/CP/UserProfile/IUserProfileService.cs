using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.CP.User.UserProfile;

namespace EasyShop.Interfaces.Services.CP.UserProfile
{
    public interface IUserProfileService
    {
        Task<UserProfileViewModel> UpdateUserData(UserProfileViewModel model);
    }
}
