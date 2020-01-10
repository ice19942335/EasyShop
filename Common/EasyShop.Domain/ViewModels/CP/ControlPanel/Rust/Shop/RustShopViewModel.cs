using System.Collections.Generic;
using EasyShop.Domain.Enums.CP.Rust;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Category;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Product;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Server;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Shop
{
    public class RustShopViewModel
    {
        public string Id { get; set; }

        public string ShopName { get; set; }

        public string ShopTitle { get; set; }

        public RustShopStatsPeriodEnum StatsPeriod { get; set; } = RustShopStatsPeriodEnum.Over_the_last_week;

        public List<RustShopStatsPeriodEnum> StatsPeriodList { get; set; } = new List<RustShopStatsPeriodEnum>
        {
            RustShopStatsPeriodEnum.Today,
            RustShopStatsPeriodEnum.Over_the_last_week,
            RustShopStatsPeriodEnum.Over_the_last_30_days,
            RustShopStatsPeriodEnum.Over_the_last_90_days,
            RustShopStatsPeriodEnum.Over_the_last_180_days,
            RustShopStatsPeriodEnum.Over_the_last_year
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
