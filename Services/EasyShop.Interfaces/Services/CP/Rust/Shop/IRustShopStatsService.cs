using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Enums.CP.Rust;
using EasyShop.Domain.ViewModels.ControlPanel.Shop.Stats;

namespace EasyShop.Interfaces.Services.CP.Rust.Shop
{
    public interface IRustShopStatsService
    {
        RustShopStatsViewModel GetTodayStats(Guid shopId);

        RustShopStatsViewModel GetOverTheLastWeekStats(Guid shopId);

        RustShopStatsViewModel GetOverTheLast30DaysStats(Guid shopId);

        RustShopStatsViewModel GetOverTheLast90DaysStats(Guid shopId);

        RustShopStatsViewModel GetOverTheLast180DaysStats(Guid shopId);

        RustShopStatsViewModel GetOverTheLastYearStats(Guid shopId);

        RustShopStatsViewModel GetAllTimeStats(Guid shopId);
    }
}
