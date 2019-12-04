using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.SignalR;

namespace EasyShop.Domain.ViewModels.Account
{
    public class RegisterUserViewModel
    {
        [MaxLength(256, ErrorMessage = "Max 256 symbols.")]
        [MinLength(2, ErrorMessage = "Firstname required minimum 2 characters.")]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [MaxLength(256, ErrorMessage = "Max 256 symbols.")]
        [MinLength(2, ErrorMessage = "Lastname required minimum 2 characters.")]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address required.")]
        [EmailAddress(ErrorMessage = "Email format is: abc@def.domain")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256, ErrorMessage = "Max 256 symbols")]
        [MinLength(8, ErrorMessage = "Password must be 10 characters or more.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(256, ErrorMessage = "Max 256 symbols")]
        [MinLength(8, ErrorMessage = "Password must be 10 characters or more.")]
        [Compare(nameof(Password), ErrorMessage = "Passwords have to be same.")]
        public string ConfirmPassword { get; set; }

        public string Month { get; set; }

        public int Day { get; set; }

        public int Year { get; set; }

        public int Gender { get; set; }

        public bool Terms { get; set; }

        public string ReturnUrl { get; set; }
    }
}
