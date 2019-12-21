using System;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;

namespace EasyShop.Services.Mappers.ViewModels.Rust
{
    public static class RustShopViewModelMapper
    {
        #region Shop -> MainSettingsRustShopViewModel

        public static MainSettingsRustShopViewModel CreateMainSettingsViewModel(this Shop shop)
        {
            var model = shop.CopyToMainSettingsRustShopViewModel();
            return model;
        }

        private static MainSettingsRustShopViewModel CopyToMainSettingsRustShopViewModel(this Shop shop)
        {
            var model = new MainSettingsRustShopViewModel
            {
                Id = shop.Id,
                ShopName = shop.ShopName,
                ShopTitle = shop.ShopTitle,
                StartBalance = shop.StartBalance,
                Secret = shop.Secret
            };

            return model;
        }

        #endregion

        #region Shop -> ShopViewModel

        public static RustShopViewModel CreateRustShopViewModel(this Shop shop)
        {
            var model = shop.RustShopViewModel();
            return model;
        }

        private static RustShopViewModel RustShopViewModel(this Shop shop)
        {
            var model = new RustShopViewModel
            {
                Id = shop.Id.ToString(),
                ShopName = shop.ShopName,
                ShopTitle = shop.ShopTitle,
                MainSettingsRustShopViewModel = shop.CreateMainSettingsViewModel()
            };

            return model;
        }

        #endregion
    }
}
