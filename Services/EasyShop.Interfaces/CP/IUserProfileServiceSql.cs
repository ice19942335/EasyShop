using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Domain.ViewModels.User.UserProfile;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Interfaces.CP
{
    public interface IUserProfileServiceSql
    {
        Task<UserProfileViewModel> UpdateUserData(UserProfileViewModel model);

        bool UploadProfilePicture(IFormFile file);
    }
}
