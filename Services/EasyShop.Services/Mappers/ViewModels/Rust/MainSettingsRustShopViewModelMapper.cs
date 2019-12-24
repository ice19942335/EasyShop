using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;

namespace EasyShop.Services.Mappers.ViewModels.Rust
{
    public static class MainSettingsRustShopViewModelMapper
    {
        public static MainSettingsRustShopViewModel CreateMainSettingsViewModel(this Shop shop)
        {
            var model = shop.CopyToMainSettingsRustShopViewModel();
            return model;
        }

        private static MainSettingsRustShopViewModel CopyToMainSettingsRustShopViewModel(this Shop shop)
        {
            var model = new MainSettingsRustShopViewModel
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
