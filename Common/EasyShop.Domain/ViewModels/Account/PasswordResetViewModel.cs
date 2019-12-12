using System.ComponentModel.DataAnnotations;

namespace EasyShop.Domain.ViewModels.Account
{
    public class PasswordResetViewModel
    {
        public string UserId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Password must be 10 characters or more.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords not match")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}