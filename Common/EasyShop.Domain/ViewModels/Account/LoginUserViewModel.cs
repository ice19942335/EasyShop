using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyShop.Domain.ViewModels.Account
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "Username required")]
        [MaxLength(256, ErrorMessage = "Max 256 symbols")]
        [MinLength(8, ErrorMessage = "Username required minimum 8 symbols")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required")]
        [MaxLength(256, ErrorMessage = "Max 256 symbols")]
        [MinLength(8, ErrorMessage = "Password required minimum 8 symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
