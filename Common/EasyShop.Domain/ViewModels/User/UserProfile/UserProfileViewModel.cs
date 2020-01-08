﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EasyShop.Domain.ViewModels.ViewModelValidation;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Domain.ViewModels.User.UserProfile
{
    public class UserProfileViewModel
    {
        [Required(ErrorMessage = "The name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email is required.")]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "The birth date is required.")]
        [RegularExpression("[0-9]{2}-[0-9]{2}-[0-9]{4}", ErrorMessage = "Please enter a correct birth date.")]
        public string BirthDateToUpdate { get; set; }

        public int Gender { get; set; }

        public string ProfileImage { get; set; }

        [UserPictureToUploadValidation(new string[] { "png", "jpg", "jpeg" })]
        public IFormFile ImageToUpload { get; set; }
    }
}
