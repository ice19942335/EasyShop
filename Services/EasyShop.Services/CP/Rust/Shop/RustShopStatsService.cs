using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Users;
using EasyShop.Domain.Enums.CP.DashBoard;
using EasyShop.Domain.Enums.CP.Rust;
using EasyShop.Domain.ViewModels.CP.ControlPanel.DashBoard;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Shop.Stats;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace EasyShop.Services.CP.Rust.Shop
{
    public class RustShopStatsService : IRustShopStatsService
    {
        private readonly EasyShopContext _context;
        private readonly AppUser _user;

        public RustShopStatsService(EasyShopContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _user = userManager.FindByEmailAsync(contextAccessor.HttpContext.User.Identity.Name).Result;
        }


        #region Public Get methods

        public RustShopStatsViewModel GetTodayStats(Guid shopId)
        {
            return new RustShopStatsViewModel
            {
                StatsPeriod = RustShopStatsPeriodEnum.Today,
                RevenueModel = GetRevenueDailyStats(shopId),
                OrdersModel = GetOrdersDailyStats(shopId),
                ItemsModel = GetSoldItemsDailyStats(shopId),
                BuyersModel = GetBuyersDailyStats(shopId),
            };
        }
        public RustShopStatsViewModel GetOverTheLastWeekStats(Guid shopId)
        {
            return new RustShopStatsViewModel
            {
                StatsPeriod = RustShopStatsPeriodEnum.Over_the_last_week,
                RevenueModel = GetRevenueStats(shopId, 7),
                OrdersModel = GetOrdersStats(shopId, 7),
                ItemsModel = GetSoldItemsStats(shopId, 7),
                BuyersModel = GetBuyersStats(shopId, 7),
                RevenueOverviewModel = GetRevenueOverviewStats(shopId, 7)
            };
        }
        public RustShopStatsViewModel GetOverTheLast30DaysStats(Guid shopId)
        {
            return new RustShopStatsViewModel
            {
                StatsPeriod = RustShopStatsPeriodEnum.Over_the_last_30_days,
                RevenueModel = GetRevenueStats(shopId, 30),
                OrdersModel = GetOrdersStats(shopId, 30),
                ItemsModel = GetSoldItemsStats(shopId, 30),
                BuyersModel = GetBuyersStats(shopId, 30),
                RevenueOverviewModel = GetRevenueOverviewStats(shopId, 30)
            };
        }
        public RustShopStatsViewModel GetOverTheLast90DaysStats(Guid shopId)
        {
            return new RustShopStatsViewModel
            {
                StatsPeriod = RustShopStatsPeriodEnum.Over_the_last_90_days,
                RevenueModel = GetRevenueStats(shopId, 90),
                OrdersModel = GetOrdersStats(shopId, 90),
                ItemsModel = GetSoldItemsStats(shopId, 90),
                BuyersModel = GetBuyersStats(shopId, 90),
                RevenueOverviewModel = GetRevenueOverviewStats(shopId, 90)
            };
        }
        public RustShopStatsViewModel GetOverTheLast180DaysStats(Guid shopId)
        {
            return new RustShopStatsViewModel
            {
                StatsPeriod = RustShopStatsPeriodEnum.Over_the_last_180_days,
                RevenueModel = GetRevenueStats(shopId, 180),
                OrdersModel = GetOrdersStats(shopId, 180),
                ItemsModel = GetSoldItemsStats(shopId, 180),
                BuyersModel = GetBuyersStats(shopId, 180),
                RevenueOverviewModel = GetRevenueOverviewStats(shopId, 180)
            };
        }
        public RustShopStatsViewModel GetOverTheLastYearStats(Guid shopId)
        {
            return new RustShopStatsViewModel
            {
                StatsPeriod = RustShopStatsPeriodEnum.Over_the_last_year,
                RevenueModel = GetRevenueStats(shopId, 360),
                OrdersModel = GetOrdersStats(shopId, 360),
                ItemsModel = GetSoldItemsStats(shopId, 360),
                BuyersModel = GetBuyersStats(shopId, 360),
                RevenueOverviewModel = GetRevenueOverviewStats(shopId, 360)
            };
        }
        public RustShopStatsViewModel GetAllTimeStats(Guid shopId)
        {
            RustShopStatsViewModel statsResult = new RustShopStatsViewModel
            {
                StatsPeriod = RustShopStatsPeriodEnum.All_time,
                RevenueModel = GetAllTimeRevenueStats(shopId),
                OrdersModel = GetAllTimeOrdersStats(shopId),
                ItemsModel = GetAllTimeSoldItemsStats(shopId),
                BuyersModel = GetAllTimeBuyersStats(shopId)
            };

            return statsResult;
        }
        #endregion Public Get methods


        #region AllTimeStats
        private ShopTotalRevenueViewModel GetAllTimeRevenueStats(Guid shopId)
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.AppUser == _user && x.Shop.Id == shopId);

            return new ShopTotalRevenueViewModel
            {
                ChartValues = new[] { 0.00m },
                ChartLabelValues = null,
                TotalRevenue = rustPurchaseStats.Select(x => x.RustPurchasedItem.TotalPaid).Sum()
            };
        }
        private ShopTotalOrdersViewModel GetAllTimeOrdersStats(Guid shopId)
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.AppUser == _user && x.Shop.Id == shopId);

            return new ShopTotalOrdersViewModel
            {
                ChartValues = new[] { "0" },
                ChartLabelValues = null,
                TotalOrders = rustPurchaseStats.Count()
            };
        }
        private ShopTotalItemsViewModel GetAllTimeSoldItemsStats(Guid shopId)
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.AppUser == _user && x.Shop.Id == shopId);

            return new ShopTotalItemsViewModel
            {
                ChartValues = new[] { "0" },
                ChartLabelValues = null,
                TotalItems = rustPurchaseStats.Select(x => x.RustPurchasedItem.AmountOnPurchase * x.RustPurchasedItem.ItemsPerStack).Sum()
            };
        }
        private ShopTotalBuyersViewModel GetAllTimeBuyersStats(Guid shopId)
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.AppUser == _user && x.Shop.Id == shopId);

            return new ShopTotalBuyersViewModel
            {
                ChartValues = new[] { "0" },
                ChartLabelValues = null,
                TotalBuyers = rustPurchaseStats.Select(x => x.RustPurchasedItem.SteamUser).ToList().Distinct().Count()
            };
        }
        #endregion AllTimeStats


        #region DailyStats
        private ShopTotalRevenueViewModel GetRevenueDailyStats(Guid shopId)
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user && x.Shop.Id == shopId);

            return new ShopTotalRevenueViewModel
            {
                ChartValues = new[] { 0.00m },
                ChartLabelValues = null,
                TotalRevenue = rustPurchaseStats.Select(x => x.RustPurchasedItem.TotalPaid).Sum()
            };
        }
        private ShopTotalOrdersViewModel GetOrdersDailyStats(Guid shopId)
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user && x.Shop.Id == shopId);

            return new ShopTotalOrdersViewModel
            {
                ChartValues = new[] { "0" },
                ChartLabelValues = null,
                TotalOrders = rustPurchaseStats.Count()
            };
        }
        private ShopTotalItemsViewModel GetSoldItemsDailyStats(Guid shopId)
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user && x.Shop.Id == shopId);

            return new ShopTotalItemsViewModel
            {
                ChartValues = new[] { "0" },
                ChartLabelValues = null,
                TotalItems = rustPurchaseStats.Select(x => x.RustPurchasedItem.AmountOnPurchase * x.RustPurchasedItem.ItemsPerStack).Sum()
            };
        }
        private ShopTotalBuyersViewModel GetBuyersDailyStats(Guid shopId)
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user && x.Shop.Id == shopId);

            return new ShopTotalBuyersViewModel
            {
                ChartValues = new[] { "0" },
                ChartLabelValues = null,
                TotalBuyers = rustPurchaseStats.Select(x => x.RustPurchasedItem.SteamUser).ToList().Distinct().Count()
            };
        }
        #endregion DailyStats


        #region StatsByPeriod
        private ShopTotalRevenueViewModel GetRevenueStats(Guid shopId, int daysPeriod)
        {
            DateTime datePeriodAgo = DateTime.Today.Subtract(TimeSpan.FromDays(daysPeriod));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x =>
                    x.RustPurchasedItem.PurchaseDateTime.Date > datePeriodAgo.Date &&
                    x.RustPurchasedItem.PurchaseDateTime.Date <= DateTime.Today.Date
                    && x.AppUser == _user && x.Shop.Id == shopId);

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

            return new ShopTotalRevenueViewModel
            {
                ChartValues = revenueValues,
                ChartLabelValues = revenueDates,
                TotalRevenue = revenueValues.Sum()
            };
        }
        private ShopTotalOrdersViewModel GetOrdersStats(Guid shopId, int daysPeriod)
        {
            DateTime datePeriodAgo = DateTime.Today.Subtract(TimeSpan.FromDays(daysPeriod));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x =>
                    x.RustPurchasedItem.PurchaseDateTime.Date > datePeriodAgo.Date &&
                    x.RustPurchasedItem.PurchaseDateTime.Date <= DateTime.Today.Date &&
                    x.AppUser == _user &&
                    x.Shop.Id == shopId);

            List<string> ordersDates = new List<string>();
            List<int> ordersValues = new List<int>();


            for (int i = daysPeriod; i >= 0; i--)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                ordersDates.Add($"\"{selectedDay.DayOfWeek}\"");
                var soldProductOfSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                ordersValues.Add(soldProductOfSelectedDate.Count);
            }

            return new ShopTotalOrdersViewModel
            {
                ChartValues = ordersValues.Select(x => x.ToString()),
                ChartLabelValues = ordersDates,
                TotalOrders = ordersValues.Sum()
            };

        }
        private ShopTotalItemsViewModel GetSoldItemsStats(Guid shopId, int daysPeriod)
        {
            DateTime datePeriodAgo = DateTime.Today.Subtract(TimeSpan.FromDays(daysPeriod));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x =>
                    x.RustPurchasedItem.PurchaseDateTime.Date > datePeriodAgo.Date &&
                    x.RustPurchasedItem.PurchaseDateTime.Date <= DateTime.Today.Date &&
                    x.AppUser == _user &&
                    x.Shop.Id == shopId);

            List<string> itemsSoldDates = new List<string>();
            List<int> itemsSoldValues = new List<int>();

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

                itemsSoldValues.Add(soldItemsInSelectedDate);
            }

            return new ShopTotalItemsViewModel
            {
                ChartValues = itemsSoldValues.Select(x => x.ToString()),
                ChartLabelValues = itemsSoldDates,
                TotalItems = itemsSoldValues.Sum()
            };
        }
        private ShopTotalBuyersViewModel GetBuyersStats(Guid shopId, int daysPeriod)
        {
            DateTime datePeriodAgo = DateTime.Today.Subtract(TimeSpan.FromDays(daysPeriod));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.RustPurchasedItem.SteamUser)
                .Include(x => x.Shop)
                .Where(x =>
                    x.RustPurchasedItem.PurchaseDateTime.Date > datePeriodAgo.Date &&
                    x.RustPurchasedItem.PurchaseDateTime.Date <= DateTime.Today.Date &&
                    x.AppUser == _user &&
                    x.Shop.Id == shopId);

            List<string> buyersDates = new List<string>();
            List<string> buyersValues = new List<string>();

            List<SteamUser> steamUsersList = new List<SteamUser>();

            for (int i = daysPeriod; i >= 0; i--)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                buyersDates.Add($"\"{selectedDay.DayOfWeek}\"");
                var soldProductInSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                var buyersInSelectedDate = soldProductInSelectedDate.Select(x => x.RustPurchasedItem.SteamUser.Uid).Distinct().Count().ToString();
                buyersValues.Add(buyersInSelectedDate);

                steamUsersList.AddRange(soldProductInSelectedDate.Select(x => x.RustPurchasedItem.SteamUser).Distinct());
            }

            return new ShopTotalBuyersViewModel
            {
                ChartValues = buyersValues,
                ChartLabelValues = buyersDates,
                TotalBuyers = steamUsersList.Distinct().Count()
            };
        }
        private ShopTotalRevenueOverviewViewModel GetRevenueOverviewStats(Guid shopId, int daysPeriod)
        {
            DateTime datePeriodAgo = DateTime.Today.Subtract(TimeSpan.FromDays(daysPeriod * 2));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x =>
                    x.RustPurchasedItem.PurchaseDateTime.Date > datePeriodAgo.Date &&
                    x.RustPurchasedItem.PurchaseDateTime.Date <= DateTime.Today.Date &&
                    x.AppUser == _user &&
                    x.Shop.Id == shopId);

            List<string> revenueOverviewDates = new List<string>();
            List<string> revenueOverviewValues = new List<string>();
            List<string> revenueOverviewPreviousPeriodValues = new List<string>();

            for (int i = daysPeriod; i >= 0; i--)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));
                var selectedDateWeekAgo = selectedDay.Subtract(TimeSpan.FromDays(daysPeriod));

                revenueOverviewDates.Add($"\"{selectedDay.ToShortDateString()}\"");

                var soldProductInSelectedDate = rustPurchaseStats
                    .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                var soldProductInSelectedDatePreviousWeek = rustPurchaseStats
                    .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDateWeekAgo.Date).ToList();

                decimal totalRevenueInSelectedDate = 0m;
                foreach (var item in soldProductInSelectedDate)
                    totalRevenueInSelectedDate += item.RustPurchasedItem.TotalPaid;
                revenueOverviewValues.Add(totalRevenueInSelectedDate.ToString());

                decimal totalRevenueInSelectedDateWeekAgo = 0m;
                foreach (var item in soldProductInSelectedDatePreviousWeek)
                    totalRevenueInSelectedDateWeekAgo += item.RustPurchasedItem.TotalPaid;
                revenueOverviewPreviousPeriodValues.Add(totalRevenueInSelectedDateWeekAgo.ToString());
            }

            return new ShopTotalRevenueOverviewViewModel
            {
                ChartLabelsValues = revenueOverviewDates,
                ChartValuesForPeriod = revenueOverviewValues,
                ChartValuesForPreviousPeriod = revenueOverviewPreviousPeriodValues
            };
        }
        #endregion StatsByPeriod
    }
}
