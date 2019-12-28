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

        public RustShopEditMainSettingsViewModel RustShopEditMainSettingsViewModel { get; set; }

        public RustShopCategoriesViewModel RustShopCategories { get; set; }

        public RustCategoryEditViewModel RustCategoryEditViewModel { get; set; }

        public RustProductsManagerViewModel RustProductsManagerViewModel { get; set; }

        public RustProductEditViewModel RustProductEditViewModel { get; set; }

        public RustServerManagerViewModel RustServerManagerViewModel { get; set; }

        public RustServerEditViewModel RustServerEditViewModel { get; set; }
    }
}
