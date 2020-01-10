using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace EasyShop.Services.ExtensionMethods
{
    public static class DefaultPictureNameHelper
    {
        public static readonly string[] DefaultPictures = { "default-profile-male.jpg", "default-profile-female.jpg", "not-specified.jpg" };

        /// <summary>
        /// Return default picture name depend on user gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static string GetDefaultPictureName(int gender)
        {
            string profileImage;

            if (gender == 1)
                profileImage = DefaultPictures[0];
            else if (gender == 2)
                profileImage = DefaultPictures[1];
            else
                profileImage = DefaultPictures[2];

            return profileImage;
        }

        /// <summary>
        /// Return true if picture name is default name
        /// </summary>
        /// <param name="pictureName"></param>
        /// <returns></returns>
        public static bool IsPictureDefault(string pictureName)
        {
            if (DefaultPictures.Contains(pictureName))
                return true;

            return false;
        }
    }
}
