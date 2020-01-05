using System.Collections.Generic;
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

        public RustShopStatsEnum StatsPeriod { get; set; } = RustShopStatsEnum.Over_the_last_week;

        public List<RustShopStatsEnum> StatsPeriodList { get; set; } = new List<RustShopStatsEnum>
        {
            RustShopStatsEnum.Today,
            RustShopStatsEnum.Over_the_last_week,
            RustShopStatsEnum.Over_the_last_30_days,
            RustShopStatsEnum.Over_the_last_90_days,
            RustShopStatsEnum.Over_the_last_180_days,
            RustShopStatsEnum.Over_the_last_year
        };

        public Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> Stats { get; set; }

        public RustShopEditMainSettingsViewModel RustShopEditMainSettingsViewModel { get; set; }

        public RustShopCategoriesViewModel RustShopCategories { get; set; }

        public RustCategoryEditViewModel RustCategoryEditViewModel { get; set; }

        public RustProductsManagerViewModel RustProductsManagerViewModel { get; set; }

        public RustProductEditViewModel RustProductEditViewModel { get; set; }

        public RustServerManagerViewModel RustServerManagerViewModel { get; set; }

        public RustServerEditViewModel RustServerEditViewModel { get; set; }
    }
}
