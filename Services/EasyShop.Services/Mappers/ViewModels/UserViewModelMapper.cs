using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Domain.ViewModels.User.UserProfile;

namespace EasyShop.Services.Mappers.ViewModels
{
    public static class UserViewModelMapper
    {
        private static void CopyToUserProfileViewModel(this ApplicationUser user, UserProfileViewModel model)
        {
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.BirthDate = user.BirthDate;
            model.Gender = user.Gender;
            model.TransactionPercent = user.TransactionPercent;
            model.ShopsAllowed = user.ShopsAllowed;
            model.ProfileImage = user.ProfileImage;
        }

        /// <summary>
        /// Converting ApplicationUser to UserProfileViewModel
        /// </summary>
        /// <param name="user"></param>
        /// <returns>UserProfileViewModel</returns>
        public static UserProfileViewModel CreateViewModel(this ApplicationUser user)
        {
            var model = new UserProfileViewModel();
            user.CopyToUserProfileViewModel(model);
            return model;
        }

        private static void CopyToApplicationUser(this UserProfileViewModel model, ApplicationUser user)
        {
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.BirthDate = model.BirthDate;
            user.Gender = model.Gender;
        }

        /// <summary>
        /// Applying changed fields and return ApplicationUser
        /// </summary>
        /// <param name="model"></param>
        /// <param name="user"></param>
        /// <returns>ApplicationUser</returns>
        public static ApplicationUser CreateApplicationUser(this UserProfileViewModel model, ApplicationUser user)
        {
            model.CopyToApplicationUser(user);
            return user;
        }
    }
}
