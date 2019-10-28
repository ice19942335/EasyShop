using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Domain.ViewModels.User.UserProfile;
using EasyShop.Services.ExtensionMethods;

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
            model.Email = user.Email;
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
            var dateArr = model.BirthDateToUpdate.Split('-');
            var birthDate = new DateTime(Int32.Parse(dateArr[2]), Int32.Parse(dateArr[0]), Int32.Parse(dateArr[1]));

            if (GenderHelper.IsPictureDefault(model.ProfileImage))
                user.ProfileImage = GenderHelper.GetDefaultPictureName(model.Gender);
            
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.BirthDate = birthDate;
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
