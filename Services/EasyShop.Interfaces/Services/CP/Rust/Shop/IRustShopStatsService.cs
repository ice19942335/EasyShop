using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Enums.Rust;

namespace EasyShop.Interfaces.Services.CP.Rust.Shop
{
    public interface IRustShopStatsService
    {
        Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetTodayStats(Guid shopId);

        Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLastWeekStats(Guid shopId);

        Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast30DaysStats(Guid shopId);

        Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast90DaysStats(Guid shopId);

        Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast180DaysStats(Guid shopId);

        Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLastYearStats(Guid shopId);
    }
}
