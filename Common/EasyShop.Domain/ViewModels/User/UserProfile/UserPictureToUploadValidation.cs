﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Domain.ViewModels.User.UserProfile
{
    public class UserPictureToUploadValidation : ValidationAttribute
    {
        private readonly string[] _fileTypeList;

        public UserPictureToUploadValidation(string[] fileTypeList) => _fileTypeList = fileTypeList;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = (IFormFile)value;

            if (file != null)
            {
                var fileType = file.ContentType.Split("/")[1];

                if (!_fileTypeList.Contains(fileType))
                    return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"File type should be one of these: {string.Join(", ", _fileTypeList)}.";
        }
    }
}
