using System.Threading.Tasks;
using EasyShop.Domain.Dto.CP.Account;
using EasyShop.Domain.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.Interfaces.Services.CP
{
    public interface IAccountService
    {
        Task<AccountDto> RegisterAsync(RegisterUserViewModel model, IUrlHelper url);

        Task<AccountDto> LoginAsync(LoginUserViewModel model, IUrlHelper url);

        Task<AccountDto> SendEmailConfirmationLinkAsync(string userName, IUrlHelper url);

        Task<AccountDto> ConfirmEmail(string userId, string token);

        Task<AccountDto> SendPasswordResetLink(ForgotPasswordViewModel model, IUrlHelper url);

        Task<AccountDto> ResetPasswordAsync(string userId, PasswordResetViewModel model, IUrlHelper url);
    }
}
