using System.ComponentModel.DataAnnotations;

namespace EasyShop.Domain.ViewModels.ControlPanel.Account
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "Email address required.")]
        [EmailAddress(ErrorMessage = "Email format is: abc@def.domain")]
        [MaxLength(36, ErrorMessage = "Email max length 36 symbols.")]
        [MinLength(2, ErrorMessage = "Email required minimum 4 characters.")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required")]
        [MaxLength(36, ErrorMessage = "Max 36 symbols")]
        [MinLength(10, ErrorMessage = "Password must be 10 characters or more.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
