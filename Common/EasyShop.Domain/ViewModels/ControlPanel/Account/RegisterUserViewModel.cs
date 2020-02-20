using System.ComponentModel.DataAnnotations;

namespace EasyShop.Domain.ViewModels.ControlPanel.Account
{
    public class RegisterUserViewModel
    {
        [MaxLength(36, ErrorMessage = "Max 36 symbols")]
        [MinLength(2, ErrorMessage = "Firstname required minimum 2 characters.")]
        [Display(Name = "Firstname")]
        public string Firstname { get; set; }

        [MaxLength(256, ErrorMessage = "Max 256 symbols.")]
        [MinLength(2, ErrorMessage = "Lastname required minimum 2 characters.")]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address required.")]
        [EmailAddress(ErrorMessage = "Email format is: abc@def.domain")]
        [MaxLength(36, ErrorMessage = "Email max length 36 symbols.")]
        [MinLength(2, ErrorMessage = "Email required minimum 4 characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256, ErrorMessage = "Max 256 symbols")]
        [MinLength(8, ErrorMessage = "Password must be 10 characters or more.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(36, ErrorMessage = "Max 36 symbols")]
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
