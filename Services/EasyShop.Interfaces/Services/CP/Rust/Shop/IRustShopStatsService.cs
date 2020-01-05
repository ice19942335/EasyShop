using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Enums.Rust;

namespace EasyShop.Interfaces.Services.CP.Rust.Shop
{
    public interface IRustShopStatsService
    {
        Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetTodayStats(Guid shopId);

        Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetLastWeekStats(Guid shopId);

        Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetLastMonthStats(Guid shopId);

        Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetLastThreeMonthStats(Guid shopId);

        Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetLastSixMonthStats(Guid shopId);

        Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetLastYearStats(Guid shopId);
    }
}
