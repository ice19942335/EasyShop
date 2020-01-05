using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.CP.DashBoard;
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

        public Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetTodayStats()
        {
            Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> result =
                new Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>();

            var revenueData = GetRevenueDailyStats();
            result.Add(revenueData.Key, revenueData.Value);

            var ordersData = GetOrdersDailyStats();
            result.Add(ordersData.Key, ordersData.Value);

            var itemsSoldData = GetSoldItemsDailyStats();
            result.Add(itemsSoldData.Key, itemsSoldData.Value);

            var buyersData = GetBuyersDailyStats();
            result.Add(buyersData.Key, buyersData.Value);

            return result;
        }

        public Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLastWeekStats()
        {
            Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> result =
                new Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>();

            var revenueData = GetRevenueStats(7);
            result.Add(revenueData.Key, revenueData.Value);

            var ordersData = GetOrdersStats(7);
            result.Add(ordersData.Key, ordersData.Value);

            var itemsSoldData = GetSoldItemsStats(7);
            result.Add(itemsSoldData.Key, itemsSoldData.Value);

            var buyersData = GetBuyersStats(7);
            result.Add(buyersData.Key, buyersData.Value);

            var revenueOverviewData = GetRevenueOverviewStats(7);
            result.Add(revenueOverviewData.Key, revenueOverviewData.Value);

            return result;
        }

        public Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast30DaysStats()
        {
            Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> result =
                new Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>();

            var revenueData = GetRevenueStats(30);
            result.Add(revenueData.Key, revenueData.Value);

            var ordersData = GetOrdersStats(30);
            result.Add(ordersData.Key, ordersData.Value);

            var itemsSoldData = GetSoldItemsStats(30);
            result.Add(itemsSoldData.Key, itemsSoldData.Value);

            var buyersData = GetBuyersStats(30);
            result.Add(buyersData.Key, buyersData.Value);

            var revenueOverviewData = GetRevenueOverviewStats(30);
            result.Add(revenueOverviewData.Key, revenueOverviewData.Value);

            return result;
        }

        public Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast90DaysStats()
        {
            Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> result =
                new Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>();

            var revenueData = GetRevenueStats(90);
            result.Add(revenueData.Key, revenueData.Value);

            var ordersData = GetOrdersStats(90);
            result.Add(ordersData.Key, ordersData.Value);

            var itemsSoldData = GetSoldItemsStats(90);
            result.Add(itemsSoldData.Key, itemsSoldData.Value);

            var buyersData = GetBuyersStats(90);
            result.Add(buyersData.Key, buyersData.Value);

            var revenueOverviewData = GetRevenueOverviewStats(90);
            result.Add(revenueOverviewData.Key, revenueOverviewData.Value);

            return result;
        }

        public Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast180DaysStats()
        {
            Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> result =
                new Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>();

            var revenueData = GetRevenueStats(180);
            result.Add(revenueData.Key, revenueData.Value);

            var ordersData = GetOrdersStats(180);
            result.Add(ordersData.Key, ordersData.Value);

            var itemsSoldData = GetSoldItemsStats(180);
            result.Add(itemsSoldData.Key, itemsSoldData.Value);

            var buyersData = GetBuyersStats(180);
            result.Add(buyersData.Key, buyersData.Value);

            var revenueOverviewData = GetRevenueOverviewStats(180);
            result.Add(revenueOverviewData.Key, revenueOverviewData.Value);

            return result;
        }

        public Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLastYearStats()
        {
            Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> result =
                new Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>();

            var revenueData = GetRevenueStats(360);
            result.Add(revenueData.Key, revenueData.Value);

            var ordersData = GetOrdersStats(360);
            result.Add(ordersData.Key, ordersData.Value);

            var itemsSoldData = GetSoldItemsStats(360);
            result.Add(itemsSoldData.Key, itemsSoldData.Value);

            var buyersData = GetBuyersStats(360);
            result.Add(buyersData.Key, buyersData.Value);

            var revenueOverviewData = GetRevenueOverviewStats(360);
            result.Add(revenueOverviewData.Key, revenueOverviewData.Value);

            return result;
        }


        #region DailyStats

        private KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetRevenueDailyStats()
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user);

            List<string> revenueDates = new List<string>();
            List<string> revenueValues = new List<string>();
            List<string> revenueEmpty = new List<string>();

            revenueValues.Add(rustPurchaseStats.Select(x => x.RustPurchasedItem.TotalPaid).Sum().ToString());

            return new KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(DashBoardStatsUnitEnum.Revenue, (revenueDates, revenueValues, revenueEmpty));
        }

        private KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOrdersDailyStats()
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user);

            List<string> ordersDates = new List<string>();
            List<string> ordersValues = new List<string>();
            List<string> ordersEmpty = new List<string>();

            ordersValues.Add(rustPurchaseStats.Count().ToString("G29"));

            return new KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(DashBoardStatsUnitEnum.Orders, (ordersDates, ordersValues, ordersEmpty));
        }

        private KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetSoldItemsDailyStats()
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user);

            List<string> itemsSoldDates = new List<string>();
            List<string> itemsSoldValues = new List<string>();
            List<string> itemsSoldEmpty = new List<string>();

            itemsSoldValues.Add(rustPurchaseStats.Select(x => x.RustPurchasedItem.Amount).Sum().ToString("G29"));

            return new KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(DashBoardStatsUnitEnum.ItemsSold, (itemsSoldDates, itemsSoldValues, itemsSoldEmpty));
        }

        private KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetBuyersDailyStats()
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user);

            List<string> buyersDates = new List<string>();
            List<string> buyersValues = new List<string>();
            List<string> buyersEmpty = new List<string>();

            buyersValues.Add(rustPurchaseStats
                .Select(x => x.RustPurchasedItem.RustUser)
                .ToList()
                .Distinct()
                .Count()
                .ToString("G29"));

            return new KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(DashBoardStatsUnitEnum.Buyers, (buyersDates, buyersValues, buyersEmpty));
        }

        #endregion DailyStats

        #region StatsByPeriod

        private KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetRevenueStats(int daysPeriod)
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
            List<string> revenueValues = new List<string>();
            List<string> revenueEmpty = new List<string>();

            for (int i = 0; i < daysPeriod; i++)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                revenueDates.Add(selectedDay.DayOfWeek.ToString());
                var soldProductOfSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date);

                decimal totalRevenueInSelectedDate = 0m;
                foreach (var item in soldProductOfSelectedDate)
                    totalRevenueInSelectedDate += item.RustPurchasedItem.TotalPaid;
                revenueValues.Add(totalRevenueInSelectedDate.ToString());
            }

            revenueDates.Reverse();
            revenueValues.Reverse();

            return new KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(DashBoardStatsUnitEnum.Revenue, (revenueDates, revenueValues, revenueEmpty));
        }

        private KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOrdersStats(int daysPeriod)
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
            List<string> ordersEmpty = new List<string>();

            for (int i = 0; i < daysPeriod; i++)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                ordersDates.Add(selectedDay.DayOfWeek.ToString());
                var soldProductOfSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                ordersValues.Add(soldProductOfSelectedDate.Count.ToString());
            }

            ordersDates.Reverse();
            ordersValues.Reverse();

            return new KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(DashBoardStatsUnitEnum.Orders, (ordersDates, ordersValues, ordersEmpty));
        }

        private KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetSoldItemsStats(int daysPeriod)
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
            List<string> itemsSoldEmpty = new List<string>();

            for (int i = 0; i < daysPeriod; i++)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                itemsSoldDates.Add(selectedDay.DayOfWeek.ToString());
                var soldProductsInSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                int soldItemsInSelectedDate = 0;
                soldProductsInSelectedDate
                        .Select(x => x.RustPurchasedItem.Amount)
                        .ToList()
                        .ForEach(x => soldItemsInSelectedDate += x);

                itemsSoldValues.Add(soldItemsInSelectedDate.ToString());
            }

            itemsSoldDates.Reverse();
            itemsSoldValues.Reverse();

            return new KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(DashBoardStatsUnitEnum.ItemsSold, (itemsSoldDates, itemsSoldValues, itemsSoldEmpty));
        }

        private KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetBuyersStats(int daysPeriod)
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

            List<string> buyersDates = new List<string>();
            List<string> buyersValues = new List<string>();
            List<string> buyersEmpty = new List<string>();

            for (int i = 0; i < daysPeriod; i++)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                buyersDates.Add(selectedDay.DayOfWeek.ToString());
                var soldProductInSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                var buyersInSelectedDate = soldProductInSelectedDate.Select(x => x.RustPurchasedItem.RustUser).ToList().Distinct();

                buyersValues.Add(buyersInSelectedDate.Count().ToString());
            }

            buyersDates.Reverse();
            buyersValues.Reverse();

            return new KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(DashBoardStatsUnitEnum.Buyers, (buyersDates, buyersValues, buyersEmpty));
        }

        private KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetRevenueOverviewStats(int daysPeriod)
        {
            DateTime datePeriodAgo = DateTime.Today.Subtract(TimeSpan.FromDays(daysPeriod * 2));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x =>
                    x.RustPurchasedItem.PurchaseDateTime.Date > datePeriodAgo.Date &&
                    x.RustPurchasedItem.PurchaseDateTime.Date <= DateTime.Today.Date
                    && x.AppUser == _user);

            List<string> revenueOverviewDates = new List<string>();
            List<string> revenueOverviewValues = new List<string>();
            List<string> revenueOverviewPreviousWeekValues = new List<string>();

            for (int i = 0; i < daysPeriod; i++)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));
                var selectedDateWeekAgo = selectedDay.Subtract(TimeSpan.FromDays(daysPeriod));

                revenueOverviewDates.Add(selectedDay.ToShortDateString());

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
                revenueOverviewPreviousWeekValues.Add(totalRevenueInSelectedDateWeekAgo.ToString());
            }

            revenueOverviewDates.Reverse();
            revenueOverviewValues.Reverse();
            revenueOverviewPreviousWeekValues.Reverse();

            return new KeyValuePair<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(DashBoardStatsUnitEnum.RevenueOverview, (revenueOverviewDates, revenueOverviewValues, revenueOverviewPreviousWeekValues));
        }

        #endregion StatsByPeriod
    }
}

