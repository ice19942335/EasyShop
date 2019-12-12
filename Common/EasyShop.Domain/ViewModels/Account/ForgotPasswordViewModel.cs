using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyShop.Domain.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email address required.")]
        [EmailAddress(ErrorMessage = "Email format is: abc@def.domain")]
        [MaxLength(36, ErrorMessage = "Email max length 36 symbols.")]
        [MinLength(2, ErrorMessage = "Email required minimum 4 characters.")]
        public string Email { get; set; }

        public bool Authenticated { get; set; }
    }
}
