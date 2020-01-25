using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.CP.DashBoard;
using EasyShop.Domain.Enums.CP.Rust;
using EasyShop.Domain.ViewModels.CP.ControlPanel.DashBoard;
using EasyShop.Interfaces.Services.CP.Rust.Dashboard;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
#pragma warning disable 8509

namespace ServerMonetization.CP.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class ControlPanelController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDashBoardStatsService _dashBoardStatsService;

        public ControlPanelController(UserManager<AppUser> userManager, IDashBoardStatsService dashBoardStatsService)
        {
            _userManager = userManager;
            _dashBoardStatsService = dashBoardStatsService;
        }

        [HttpGet]
        public IActionResult Dashboard(DashBoardStatsPeriodEnum statsPeriod = DashBoardStatsPeriodEnum.Over_the_last_week)
        {
            var stats = statsPeriod switch
            {
                DashBoardStatsPeriodEnum.Today => _dashBoardStatsService.GetTodayStats(),
                DashBoardStatsPeriodEnum.Over_the_last_week => _dashBoardStatsService.GetOverTheLastWeekStats(),
                DashBoardStatsPeriodEnum.Over_the_last_30_days => _dashBoardStatsService.GetOverTheLast30DaysStats(),
                DashBoardStatsPeriodEnum.Over_the_last_90_days => _dashBoardStatsService.GetOverTheLast90DaysStats(),
                DashBoardStatsPeriodEnum.Over_the_last_180_days => _dashBoardStatsService.GetOverTheLast180DaysStats(),
                DashBoardStatsPeriodEnum.Over_the_last_year => _dashBoardStatsService.GetOverTheLastYearStats(),
            };

            var model = new DashBoardViewModel
            {
                StatsPeriod = statsPeriod,
                Stats = stats
            };

            return View(model);
        }

        public IActionResult SomethingWentWrong() => View();
    }
}