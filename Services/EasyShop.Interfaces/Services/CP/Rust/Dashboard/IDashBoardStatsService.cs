using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Enums.CP.DashBoard;

namespace EasyShop.Interfaces.Services.CP.Rust.Dashboard
{
    public interface IDashBoardStatsService
    {
        Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetTodayStats();

        Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLastWeekStats();

        Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast30DaysStats();

        Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast90DaysStats();

        Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast180DaysStats();

        Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLastYearStats();
    }
}
