using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EasyShop.Domain.Enums.Rust;

namespace EasyShop.Domain.ViewModels.Shop.Rust
{
    public class RustShopViewModel
    {
        public string Id { get; set; }

        public string ShopName { get; set; }

        public string ShopTitle { get; set; }

        public RustEditShopMainSettingsViewModel RustEditShopMainSettingsViewModel { get; set; }

        public RustShopCategoriesViewModel RustShopCategories { get; set; }

        public RustEditCategoryViewModel RustEditCategoryViewModel { get; set; }

        public RustProductsManagerViewModel RustProductsManagerViewModel { get; set; }

        public RustEditProductViewModel RustEditProductViewModel { get; set; }
    }
}
