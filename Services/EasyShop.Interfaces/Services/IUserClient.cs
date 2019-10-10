using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace EasyShop.Interfaces.Services
{
    public interface IUserClient :
        IUserRoleStore<User>,
        IUserClaimStore<User>,
        IUserPasswordStore<User>,
        IUserEmailStore<User>,
        IUserPhoneNumberStore<User>,
        IUserLoginStore<User>,
        IUserLockoutStore<User>,
        IUserTwoFactorStore<User>
    {
    }
}
