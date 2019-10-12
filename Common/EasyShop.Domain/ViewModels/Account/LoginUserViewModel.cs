using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyShop.Domain.ViewModels.Account
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "Email required")]
        [MaxLength(256, ErrorMessage = "Max 256 symbols")]
        [EmailAddress(ErrorMessage = "Email format is: abc@def.domain")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required")]
        [MaxLength(256, ErrorMessage = "Max 256 symbols")]
        [MinLength(10, ErrorMessage = "Password must be 10 characters or more.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
