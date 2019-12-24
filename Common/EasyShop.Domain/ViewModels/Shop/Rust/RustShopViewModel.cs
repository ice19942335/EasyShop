using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyShop.Domain.ViewModels.Shop.Rust
{
    public class RustShopViewModel
    {
        public string Id { get; set; }

        public string ShopName { get; set; }

        public string ShopTitle { get; set; }

        public MainSettingsRustShopViewModel MainSettingsRustShopViewModel { get; set; }

        public RustShopCategoriesViewModel RustShopCategories { get; set; }

        public EditRustCategoryViewModel EditRustCategoryViewModel { get; set; }
    }
}
