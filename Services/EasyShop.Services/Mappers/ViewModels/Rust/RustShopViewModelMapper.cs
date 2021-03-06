﻿using System;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.ControlPanel.Rust.Category;
using EasyShop.Domain.ViewModels.ControlPanel.Rust.Shop;
using EasyShop.Domain.ViewModels.ControlPanel.Shop.Stats;

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
                RustCategoryEditViewModel = new RustCategoryEditViewModel(),
                RustShopStatsViewModel = new RustShopStatsViewModel()   
            };

            return model;
        }
    }
}
