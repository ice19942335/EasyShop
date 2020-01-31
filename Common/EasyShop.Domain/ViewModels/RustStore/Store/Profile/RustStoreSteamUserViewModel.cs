using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace EasyShop.Domain.ViewModels.RustStore.Store.Profile
{
    public class RustStoreSteamUserViewModel
    {
        public string UserName { get; set; }

        public string ImgUrl { get; set; }

        public string Uid { get; set; }

        public Decimal Balance { get; set; }
    }
}
