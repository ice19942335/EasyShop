using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication;

namespace EasyShop.Domain.ViewModels.RustStore.Store.UserStatus
{
    public class RustStoreUserStatusViewModel
    {
        public AuthenticationScheme AuthenticationScheme { get; set; }

        public decimal Balance { get; set; }
    }
}
