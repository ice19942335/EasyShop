using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.CP.DashBoard;
using EasyShop.Domain.ViewModels.CP.ControlPanel.DashBoard;
using EasyShop.Interfaces.Services.CP.Rust.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Services.CP.Rust.Dashboard
{
    public class DashBoardStatsService : IDashBoardStatsService
    {

        private readonly EasyShopContext _context;
        private readonly AppUser _user;

        public DashBoardStatsService(EasyShopContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _user = userManager.FindByEmailAsync(contextAccessor.HttpContext.User.Identity.Name).Result;
        }


        #region Public Get methods

        public DashBoardViewModel GetTodayStats()
        {
            DashBoardViewModel statsResult = new DashBoardViewModel
            {
                StatsPeriod = DashBoardStatsPeriodEnum.Today,
                RevenueModel = GetRevenueDailyStats(),
                OrdersModel = GetOrdersDailyStats(),
                ItemsModel = GetSoldItemsDailyStats(),
                BuyersModel = GetBuyersDailyStats()
            };

            return statsResult;
        }
        public DashBoardViewModel GetOverTheLastWeekStats()
        {
            DashBoardViewModel statsResult = new DashBoardViewModel
            {
                StatsPeriod = DashBoardStatsPeriodEnum.Over_the_last_week,
                RevenueModel = GetRevenueStats(7),
                OrdersModel = GetOrdersStats(7),
                ItemsModel = GetSoldItemsStats(7),
                BuyersModel = GetBuyersStats(7)
            };

            return statsResult;
        }
        public DashBoardViewModel GetOverTheLast30DaysStats()
        {
            DashBoardViewModel statsResult = new DashBoardViewModel
            {
                StatsPeriod = DashBoardStatsPeriodEnum.Over_the_last_30_days,
                RevenueModel = GetRevenueStats(30),
                OrdersModel = GetOrdersStats(30),
                ItemsModel = GetSoldItemsStats(30),
                BuyersModel = GetBuyersStats(30)
            };

            return statsResult;
        }
        public DashBoardViewModel GetOverTheLast90DaysStats()
        {
            DashBoardViewModel statsResult = new DashBoardViewModel
            {
                StatsPeriod = DashBoardStatsPeriodEnum.Over_the_last_90_days,
                RevenueModel = GetRevenueStats(90),
                OrdersModel = GetOrdersStats(90),
                ItemsModel = GetSoldItemsStats(90),
                BuyersModel = GetBuyersStats(90)
            };

            return statsResult;
        }
        public DashBoardViewModel GetOverTheLast180DaysStats()
        {
            DashBoardViewModel statsResult = new DashBoardViewModel
            {
                StatsPeriod = DashBoardStatsPeriodEnum.Over_the_last_180_days,
                RevenueModel = GetRevenueStats(180),
                OrdersModel = GetOrdersStats(180),
                ItemsModel = GetSoldItemsStats(180),
                BuyersModel = GetBuyersStats(180)
            };

            return statsResult;
        }
        public DashBoardViewModel GetOverTheLastYearStats()
        {
            DashBoardViewModel statsResult = new DashBoardViewModel
            {
                StatsPeriod = DashBoardStatsPeriodEnum.Over_the_last_year,
                RevenueModel = GetRevenueStats(360),
                OrdersModel = GetOrdersStats(360),
                ItemsModel = GetSoldItemsStats(360),
                BuyersModel = GetBuyersStats(360)
            };

            return statsResult;
        }
        public DashBoardViewModel GetAllTimeStats()
        {
            DashBoardViewModel statsResult = new DashBoardViewModel
            {
                StatsPeriod = DashBoardStatsPeriodEnum.All_time,
                RevenueModel = GetAllTimeRevenueStats(),
                OrdersModel = GetAllTimeOrdersStats(),
                ItemsModel = GetAllTimeSoldItemsStats(),
                BuyersModel = GetAllTimeBuyersStats()
            };

            return statsResult;
        }

        #endregion Public Get methods


        #region AllTimeStats
        private DashBoardTotalRevenueViewModel GetAllTimeRevenueStats()
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.AppUser == _user)
                .ToList();

            var totalRevenue = rustPurchaseStats.Select(x => x.RustPurchasedItem.TotalPaid).Sum();

            return new DashBoardTotalRevenueViewModel
            {
                ChartValues = new[] { 0.00m },
                TotalRevenue = totalRevenue
            };
        }
        private DashBoardTotalOrdersViewModel GetAllTimeOrdersStats()
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.AppUser == _user);

            return new DashBoardTotalOrdersViewModel()
            {
                ChartValues = new[] { "0" },
                TotalOrders = rustPurchaseStats.Count()
            };
        }
        private DashBoardTotalItemsViewModel GetAllTimeSoldItemsStats()
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.AppUser == _user);

            return new DashBoardTotalItemsViewModel
            {
                ChartValues = new[] { "0" },
                TotalItems = rustPurchaseStats.Select(x => x.RustPurchasedItem.ItemsPerStack * x.RustPurchasedItem.AmountOnPurchase).Sum()
            };
        }
        private DashBoardTotalBuyersViewModel GetAllTimeBuyersStats()
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.AppUser == _user);

            List<string> buyersDates = new List<string>();
            List<string> buyersValues = new List<string>();
            List<string> buyersEmpty = new List<string>();

            var uniqueBuyers = rustPurchaseStats
                .Select(x => x.RustPurchasedItem.SteamUser)
                .ToList()
                .Distinct()
                .Count();

            return new DashBoardTotalBuyersViewModel
            {
                ChartValues = new[] { "0" },
                TotalBuyers = uniqueBuyers
            };
        }
        #endregion AllTimeStats


        #region DailyStats
        private DashBoardTotalRevenueViewModel GetRevenueDailyStats()
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user)
                .ToList();

            var totalRevenue = rustPurchaseStats.Select(x => x.RustPurchasedItem.TotalPaid).Sum();

            return new DashBoardTotalRevenueViewModel
            {
                ChartValues = new []{ 0.00m },
                TotalRevenue = totalRevenue
            };
        }
        private DashBoardTotalOrdersViewModel GetOrdersDailyStats()
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user);

            return new DashBoardTotalOrdersViewModel()
            {
                ChartValues = new []{"0"},
                TotalOrders = rustPurchaseStats.Count()
            };
        }
        private DashBoardTotalItemsViewModel GetSoldItemsDailyStats()
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user);

            return new DashBoardTotalItemsViewModel
            {
                ChartValues = new[] { "0" },
                TotalItems = rustPurchaseStats.Select(x => x.RustPurchasedItem.ItemsPerStack * x.RustPurchasedItem.AmountOnPurchase).Sum()
            };
        }
        private DashBoardTotalBuyersViewModel GetBuyersDailyStats()
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user);

            List<string> buyersDates = new List<string>();
            List<string> buyersValues = new List<string>();
            List<string> buyersEmpty = new List<string>();

            var uniqueBuyers = rustPurchaseStats
                .Select(x => x.RustPurchasedItem.SteamUser)
                .ToList()
                .Distinct()
                .Count();

            return new DashBoardTotalBuyersViewModel
            {
                ChartValues = new[] { "0" },
                TotalBuyers = uniqueBuyers
            };
        }
        #endregion DailyStats


        #region StatsByPeriod
        private DashBoardTotalRevenueViewModel GetRevenueStats(int daysPeriod)
        {
            DateTime datePeriodAgo = DateTime.Today.Subtract(TimeSpan.FromDays(daysPeriod));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x =>
                    x.RustPurchasedItem.PurchaseDateTime.Date > datePeriodAgo.Date &&
                    x.RustPurchasedItem.PurchaseDateTime.Date <= DateTime.Today.Date
                    && x.AppUser == _user);

            List<string> revenueDates = new List<string>();
            List<decimal> revenueValues = new List<decimal>();

            for (int i = daysPeriod; i >= 0; i--)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                revenueDates.Add($"\"{selectedDay.DayOfWeek}\"");
                var soldProductOfSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date);

                decimal totalRevenueInSelectedDate = 0m;
                foreach (var item in soldProductOfSelectedDate)
                    totalRevenueInSelectedDate += item.RustPurchasedItem.TotalPaid;
                revenueValues.Add(totalRevenueInSelectedDate);

            }

            return new DashBoardTotalRevenueViewModel
            {
                ChartValues = revenueValues,
                ChartLabelValues = revenueDates,
                TotalRevenue = revenueValues.Sum()
            };  
        }
        private DashBoardTotalOrdersViewModel GetOrdersStats(int daysPeriod)
        {
            DateTime datePeriodAgo = DateTime.Today.Subtract(TimeSpan.FromDays(daysPeriod));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x =>
                    x.RustPurchasedItem.PurchaseDateTime.Date > datePeriodAgo.Date &&
                    x.RustPurchasedItem.PurchaseDateTime.Date <= DateTime.Today.Date
                    && x.AppUser == _user);

            List<string> ordersDates = new List<string>();
            List<string> ordersValues = new List<string>();

            for (int i = daysPeriod; i >= 0; i--)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                ordersDates.Add($"\"{selectedDay.DayOfWeek}\"");
                var soldProductOfSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                ordersValues.Add(soldProductOfSelectedDate.Count.ToString());
            }

            return new DashBoardTotalOrdersViewModel
            {
                ChartValues = ordersValues,
                ChartLabelValues = ordersDates,
                TotalOrders = ordersValues.Select(x => Int32.Parse(x)).Sum()
            };
        }
        private DashBoardTotalItemsViewModel GetSoldItemsStats(int daysPeriod)
        {
            DateTime datePeriodAgo = DateTime.Today.Subtract(TimeSpan.FromDays(daysPeriod));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x =>
                    x.RustPurchasedItem.PurchaseDateTime.Date > datePeriodAgo.Date &&
                    x.RustPurchasedItem.PurchaseDateTime.Date <= DateTime.Today.Date
                    && x.AppUser == _user);

            List<string> itemsSoldDates = new List<string>();
            List<string> itemsSoldValues = new List<string>();

            for (int i = daysPeriod; i >= 0; i--)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                itemsSoldDates.Add($"\"{selectedDay.DayOfWeek}\"");
                var soldProductsInSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                int soldItemsInSelectedDate = 0;
                soldProductsInSelectedDate
                        .Select(x => x.RustPurchasedItem.AmountOnPurchase * x.RustPurchasedItem.ItemsPerStack)
                        .ToList()
                        .ForEach(x => soldItemsInSelectedDate += x);

                itemsSoldValues.Add(soldItemsInSelectedDate.ToString());
            }

            return new DashBoardTotalItemsViewModel
            {
                ChartValues = itemsSoldValues,
                ChartLabelValues = itemsSoldDates,
                TotalItems = itemsSoldValues.Select(x => Int32.Parse(x)).Sum()
            };
        }
        private DashBoardTotalBuyersViewModel GetBuyersStats(int daysPeriod)
        {
            DateTime datePeriodAgo = DateTime.Today.Subtract(TimeSpan.FromDays(daysPeriod));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.RustPurchasedItem.SteamUser)
                .Include(x => x.Shop)
                .Where(x =>
                    x.RustPurchasedItem.PurchaseDateTime.Date > datePeriodAgo.Date &&
                    x.RustPurchasedItem.PurchaseDateTime.Date <= DateTime.Today.Date
                    && x.AppUser == _user);

            List<string> buyersDates = new List<string>();
            List<string> buyersValues = new List<string>();

            List<string> uniqueBuyers = new List<string>();

            for (int i = daysPeriod; i >= 0; i--)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                buyersDates.Add($"\"{selectedDay.DayOfWeek}\"");
                var soldProductInSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                var buyersInSelectedDate = soldProductInSelectedDate.Select(x => x.RustPurchasedItem.SteamUser.Uid).Distinct().Count();
                buyersValues.Add(buyersInSelectedDate.ToString());

                uniqueBuyers.AddRange(soldProductInSelectedDate.Select(x => x.RustPurchasedItem.SteamUser.Uid).Distinct());
            }

            return new DashBoardTotalBuyersViewModel
            {
                ChartValues = buyersValues,
                ChartLabelValues = buyersDates,
                TotalBuyers = uniqueBuyers.Distinct().Count()
            };
        }
        #endregion StatsByPeriod
    }
}

