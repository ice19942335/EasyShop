using System;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;

namespace EasyShop.Services.Mappers.ViewModels.Rust
{
    public static class RustShopViewModelMapper
    {

        public static RustShopViewModel CreateRustShopViewModel(this Shop shop)
        {
            var model = shop.CopyToRustShopViewModel();
            return model;
        }

        private static RustShopViewModel CopyToRustShopViewModel(this Shop shop)
        {
            var model = new RustShopViewModel
            {
                Id = shop.Id.ToString(),
                ShopName = shop.ShopName,
                ShopTitle = shop.ShopTitle,
                RustEditShopMainSettingsViewModel = shop.CreateMainSettingsViewModel(),
                RustEditCategoryViewModel = new RustEditCategoryViewModel()
            };

            return model;
        }
    }
}
