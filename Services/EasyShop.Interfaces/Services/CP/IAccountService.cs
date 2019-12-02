﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Dto.CP.Account;
using EasyShop.Domain.ViewModels.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace EasyShop.Interfaces.Services.CP
{
    public interface IAccountService
    {
        Task<AccountDto> RegisterAsync(RegisterUserViewModel model, IUrlHelper url);

        Task<AccountDto> LoginAsync(LoginUserViewModel model, IUrlHelper url);

        Task<AccountDto> SendEmailConfirmationLinkAsync(string userName, IUrlHelper url);
    }
}