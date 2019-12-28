using System;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.Rust.Category;
using EasyShop.Domain.ViewModels.Rust.Shop;

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
                RustShopEditMainSettingsViewModel = shop.CreateMainSettingsViewModel(),
                RustCategoryEditViewModel = new RustCategoryEditViewModel()
            };

            return model;
        }
    }
}
