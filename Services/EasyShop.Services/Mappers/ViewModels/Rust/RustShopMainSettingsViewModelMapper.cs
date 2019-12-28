using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.Rust.Shop;

namespace EasyShop.Services.Mappers.ViewModels.Rust
{
    public static class RustShopMainSettingsViewModelMapper
    {
        public static RustShopEditMainSettingsViewModel CreateMainSettingsViewModel(this Shop shop)
        {
            var model = shop.CopyToMainSettingsRustShopViewModel();
            return model;
        }

        private static RustShopEditMainSettingsViewModel CopyToMainSettingsRustShopViewModel(this Shop shop)
        {
            var model = new RustShopEditMainSettingsViewModel
            {
                Id = shop.Id.ToString(),
                ShopName = shop.ShopName,
                ShopTitle = shop.ShopTitle,
                StartBalance = shop.StartBalance,
                Secret = shop.Secret
            };

            return model;
        }
    }
}
