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
        private static void CopyToUserProfileViewModel(this AppUser user, UserProfileViewModel model)
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
        /// Converting AppUser to UserProfileViewModel
        /// </summary>
        /// <param name="user"></param>
        /// <returns>UserProfileViewModel</returns>
        public static UserProfileViewModel CreateViewModel(this AppUser user)
        {
            var model = new UserProfileViewModel();
            user.CopyToUserProfileViewModel(model);
            return model;
        }

        private static void CopyToApplicationUser(this UserProfileViewModel model, AppUser user)
        {
            var dateArr = model.BirthDateToUpdate.Split('-');
            var birthDate = new DateTime(Int32.Parse(dateArr[2]), Int32.Parse(dateArr[0]), Int32.Parse(dateArr[1]));

            if (DefaultPictureNameHelper.IsPictureDefault(model.ProfileImage))
                user.ProfileImage = DefaultPictureNameHelper.GetDefaultPictureName(model.Gender);
            
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.BirthDate = birthDate;
            user.Gender = model.Gender;
            user.ProfileImage = model.ProfileImage;
        }

        /// <summary>
        /// Applying changed fields and return AppUser
        /// </summary>
        /// <param name="model"></param>
        /// <param name="user"></param>
        /// <returns>AppUser</returns>
        public static AppUser CreateApplicationUser(this UserProfileViewModel model, AppUser user)
        {
            model.CopyToApplicationUser(user);
            return user;
        }
    }
}
