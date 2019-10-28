using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace EasyShop.Services.ExtensionMethods
{
    public static class GenderHelper
    {
        private static string[] _defaultPictures = new[] { "default-profile-male", "default-profile-female", "not-specified" };

        /// <summary>
        /// Return default picture name depend on user gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static string GetDefaultPictureName(int gender)
        {
            string profileImage;

            if (gender == 1)
                profileImage = _defaultPictures[0];
            else if (gender == 2)
                profileImage = _defaultPictures[1];
            else
                profileImage = _defaultPictures[2];

            return profileImage;
        }

        public static bool IsPictureDefault(string pictureName)
        {
            if (_defaultPictures.Contains(pictureName))
                return true;

            return false;
        }
    }
}
