using System.Threading.Tasks;
using EasyShop.Domain.Enums.CP.Profile;
using EasyShop.Domain.ViewModels.CP.User.UserProfile;

namespace EasyShop.Interfaces.Services.CP.UserProfile
{
    public interface IUserProfileService
    {
        Task<UpdateUserProfileEnum> UpdateUserData(UserProfileViewModel model);
    }
}
