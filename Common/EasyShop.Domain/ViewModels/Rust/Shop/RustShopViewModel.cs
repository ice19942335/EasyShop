﻿using System.Collections.Generic;
using EasyShop.Domain.Enums.Rust;
using EasyShop.Domain.ViewModels.Rust.Category;
using EasyShop.Domain.ViewModels.Rust.Product;
using EasyShop.Domain.ViewModels.Rust.Server;

namespace EasyShop.Domain.ViewModels.Rust.Shop
{
    public class RustShopViewModel
    {
        public string Id { get; set; }

        public string ShopName { get; set; }

        public string ShopTitle { get; set; }

        public RustShopStatsEnum StatsPeriod { get; set; } = RustShopStatsEnum.Last_week;

        public List<RustShopStatsEnum> StatsPeriodList { get; set; } = new List<RustShopStatsEnum>
        {
            RustShopStatsEnum.Today,
            RustShopStatsEnum.Yesterday,
            RustShopStatsEnum.Last_week,
            RustShopStatsEnum.Last_month,
            RustShopStatsEnum.Last_three_months,
            RustShopStatsEnum.Last_six_months,
            RustShopStatsEnum.Last_year
        };

        public RustShopEditMainSettingsViewModel RustShopEditMainSettingsViewModel { get; set; }

        public RustShopCategoriesViewModel RustShopCategories { get; set; }

        public RustCategoryEditViewModel RustCategoryEditViewModel { get; set; }

        public RustProductsManagerViewModel RustProductsManagerViewModel { get; set; }

        public RustProductEditViewModel RustProductEditViewModel { get; set; }

        public RustServerManagerViewModel RustServerManagerViewModel { get; set; }

        public RustServerEditViewModel RustServerEditViewModel { get; set; }
    }
}
