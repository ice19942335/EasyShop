using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.CP.DashBoard;
using EasyShop.Domain.Enums.CP.Rust;
using EasyShop.Domain.ViewModels.ControlPanel.DashBoard;
using EasyShop.Interfaces.Services.CP.Rust.Dashboard;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
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
        public async Task<IActionResult> Dashboard(string userId, DashBoardStatsPeriodEnum statsPeriod = DashBoardStatsPeriodEnum.Over_the_last_week)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null)
                return RedirectToAction("NotFoundPage", "Home");

            var stats = statsPeriod switch
            {
                DashBoardStatsPeriodEnum.Today => _dashBoardStatsService.GetTodayStats(Guid.Parse(userId)),
                DashBoardStatsPeriodEnum.Over_the_last_week => _dashBoardStatsService.GetOverTheLastWeekStats(Guid.Parse(userId)),
                DashBoardStatsPeriodEnum.Over_the_last_30_days => _dashBoardStatsService.GetOverTheLast30DaysStats(Guid.Parse(userId)),
                DashBoardStatsPeriodEnum.Over_the_last_90_days => _dashBoardStatsService.GetOverTheLast90DaysStats(Guid.Parse(userId)),
                DashBoardStatsPeriodEnum.Over_the_last_180_days => _dashBoardStatsService.GetOverTheLast180DaysStats(Guid.Parse(userId)),
                DashBoardStatsPeriodEnum.Over_the_last_year => _dashBoardStatsService.GetOverTheLastYearStats(Guid.Parse(userId)),
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