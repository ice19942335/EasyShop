using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace EasyShop.Interfaces.Services
{
    public interface IUserClient :
        IUserRoleStore<ApplicationUser>,
        IUserClaimStore<ApplicationUser>,
        IUserPasswordStore<ApplicationUser>,
        IUserEmailStore<ApplicationUser>,
        IUserPhoneNumberStore<ApplicationUser>,
        IUserLoginStore<ApplicationUser>,
        IUserLockoutStore<ApplicationUser>,
        IUserTwoFactorStore<ApplicationUser>
    {
    }
}
