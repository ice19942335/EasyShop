using System.Collections.Generic;
using EasyShop.Domain.Enums.CP.Rust;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Category;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Product;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Server;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Shop.Stats;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Shop
{
    public class RustShopViewModel
    {
        public string Id { get; set; }

        public string ShopName { get; set; }

        public string ShopTitle { get; set; }

        public RustShopStatsViewModel RustShopStatsViewModel { get; set; }

        public RustShopEditMainSettingsViewModel RustShopEditMainSettingsViewModel { get; set; }

        public RustProductEditViewModel RustProductEditViewModel { get; set; }

        public RustServerEditViewModel RustServerEditViewModel { get; set; }

        public RustCategoryEditViewModel RustCategoryEditViewModel { get; set; }

        public RustShopCategoriesViewModel RustShopCategories { get; set; }

        public RustProductsManagerViewModel RustProductsManagerViewModel { get; set; }

        public RustServerManagerViewModel RustServerManagerViewModel { get; set; }
    }
}
