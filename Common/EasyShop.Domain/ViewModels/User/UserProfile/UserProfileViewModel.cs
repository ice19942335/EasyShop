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
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Please enter correct birth date")]
        [RegularExpression("[0-9]{2}-[0-9]{2}-[0-9]{4}", ErrorMessage = "Please enter correct birth date")]
        public string BirthDateToUpdate { get; set; }

        public int Gender { get; set; }

        public string ProfileImage { get; set; }

        [UserPictureToUploadValidation(new string[] { "png", "jpg", "jpeg" })]
        public IFormFile ImageToUpload { get; set; }
    }
}
