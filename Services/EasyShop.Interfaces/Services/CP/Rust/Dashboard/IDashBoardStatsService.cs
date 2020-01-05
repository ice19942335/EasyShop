using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Enums.CP.DashBoard;

namespace EasyShop.Interfaces.Services.CP.Rust.Dashboard
{
    public interface IDashBoardStatsService
    {
        Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetTodayStats(Guid shopId);

        Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLastWeekStats(Guid shopId);

        Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast30DaysStats(Guid shopId);

        Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast90DaysStats(Guid shopId);

        Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast180DaysStats(Guid shopId);

        Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLastYearStats(Guid shopId);
    }
}
