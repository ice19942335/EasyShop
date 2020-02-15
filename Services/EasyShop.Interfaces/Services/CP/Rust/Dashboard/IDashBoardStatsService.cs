using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Enums.CP.DashBoard;
using EasyShop.Domain.ViewModels.CP.ControlPanel.DashBoard;

namespace EasyShop.Interfaces.Services.CP.Rust.Dashboard
{
    public interface IDashBoardStatsService
    {
        DashBoardViewModel GetTodayStats();

        DashBoardViewModel GetOverTheLastWeekStats();

        DashBoardViewModel GetOverTheLast30DaysStats();

        DashBoardViewModel GetOverTheLast90DaysStats();

        DashBoardViewModel GetOverTheLast180DaysStats();

        DashBoardViewModel GetOverTheLastYearStats();

        DashBoardViewModel GetAllTimeStats();
    }
}
