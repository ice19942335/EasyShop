﻿using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Enums.CP.Rust;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.Shop.Stats
{
    public class RustShopStatsViewModel
    {
        public RustShopStatsPeriodEnum StatsPeriod { get; set; } = RustShopStatsPeriodEnum.Over_the_last_week;

        public List<RustShopStatsPeriodEnum> StatsPeriodList { get; set; } = new List<RustShopStatsPeriodEnum>
        {
            RustShopStatsPeriodEnum.Today,
            RustShopStatsPeriodEnum.Over_the_last_week,
            RustShopStatsPeriodEnum.Over_the_last_30_days,
            RustShopStatsPeriodEnum.Over_the_last_90_days,
            RustShopStatsPeriodEnum.Over_the_last_180_days,
            RustShopStatsPeriodEnum.Over_the_last_year,
            RustShopStatsPeriodEnum.All_Time,
        };

        public ShopTotalRevenueViewModel RevenueModel { get; set; }

        public ShopTotalOrdersViewModel OrdersModel { get; set; }

        public ShopTotalItemsViewModel ItemsModel { get; set; }

        public ShopTotalBuyersViewModel BuyersModel { get; set; }

        public ShopTotalRevenueOverviewViewModel RevenueOverviewModel { get; set; }
    }
}
