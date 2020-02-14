using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.CP.Rust;
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

        public Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetTodayStats(Guid shopId)
        {
            Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> result =
                new Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>();

            var revenueData = GetRevenueDailyStats(shopId);
            result.Add(revenueData.Key, revenueData.Value);

            var ordersData = GetOrdersDailyStats(shopId);
            result.Add(ordersData.Key, ordersData.Value);

            var itemsSoldData = GetSoldItemsDailyStats(shopId);
            result.Add(itemsSoldData.Key, itemsSoldData.Value);

            var buyersData = GetBuyersDailyStats(shopId);
            result.Add(buyersData.Key, buyersData.Value);

            return result;
        }

        public Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLastWeekStats(Guid shopId)
        {
            Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> result =
                new Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>();

            var revenueData = GetRevenueStats(shopId, 7);
            result.Add(revenueData.Key, revenueData.Value);

            var ordersData = GetOrdersStats(shopId, 7);
            result.Add(ordersData.Key, ordersData.Value);

            var itemsSoldData = GetSoldItemsStats(shopId, 7);
            result.Add(itemsSoldData.Key, itemsSoldData.Value);

            var buyersData = GetBuyersStats(shopId, 7);
            result.Add(buyersData.Key, buyersData.Value);

            var revenueOverviewData = GetRevenueOverviewStats(shopId, 7);
            result.Add(revenueOverviewData.Key, revenueOverviewData.Value);

            return result;
        }

        public Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast30DaysStats(Guid shopId)
        {
            Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> result =
                new Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>();

            var revenueData = GetRevenueStats(shopId, 30);
            result.Add(revenueData.Key, revenueData.Value);

            var ordersData = GetOrdersStats(shopId, 30);
            result.Add(ordersData.Key, ordersData.Value);

            var itemsSoldData = GetSoldItemsStats(shopId, 30);
            result.Add(itemsSoldData.Key, itemsSoldData.Value);

            var buyersData = GetBuyersStats(shopId, 30);
            result.Add(buyersData.Key, buyersData.Value);

            var revenueOverviewData = GetRevenueOverviewStats(shopId, 30);
            result.Add(revenueOverviewData.Key, revenueOverviewData.Value);

            return result;
        }

        public Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast90DaysStats(Guid shopId)
        {
            Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> result =
                new Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>();

            var revenueData = GetRevenueStats(shopId, 90);
            result.Add(revenueData.Key, revenueData.Value);

            var ordersData = GetOrdersStats(shopId, 90);
            result.Add(ordersData.Key, ordersData.Value);

            var itemsSoldData = GetSoldItemsStats(shopId, 90);
            result.Add(itemsSoldData.Key, itemsSoldData.Value);

            var buyersData = GetBuyersStats(shopId, 90);
            result.Add(buyersData.Key, buyersData.Value);

            var revenueOverviewData = GetRevenueOverviewStats(shopId, 90);
            result.Add(revenueOverviewData.Key, revenueOverviewData.Value);

            return result;
        }

        public Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLast180DaysStats(Guid shopId)
        {
            Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> result =
                new Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>();

            var revenueData = GetRevenueStats(shopId, 180);
            result.Add(revenueData.Key, revenueData.Value);

            var ordersData = GetOrdersStats(shopId, 180);
            result.Add(ordersData.Key, ordersData.Value);

            var itemsSoldData = GetSoldItemsStats(shopId, 180);
            result.Add(itemsSoldData.Key, itemsSoldData.Value);

            var buyersData = GetBuyersStats(shopId, 180);
            result.Add(buyersData.Key, buyersData.Value);

            var revenueOverviewData = GetRevenueOverviewStats(shopId, 180);
            result.Add(revenueOverviewData.Key, revenueOverviewData.Value);

            return result;
        }

        public Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOverTheLastYearStats(Guid shopId)
        {
            Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> result =
                new Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>();

            var revenueData = GetRevenueStats(shopId, 360);
            result.Add(revenueData.Key, revenueData.Value);

            var ordersData = GetOrdersStats(shopId, 360);
            result.Add(ordersData.Key, ordersData.Value);

            var itemsSoldData = GetSoldItemsStats(shopId, 360);
            result.Add(itemsSoldData.Key, itemsSoldData.Value);

            var buyersData = GetBuyersStats(shopId, 360);
            result.Add(buyersData.Key, buyersData.Value);

            var revenueOverviewData = GetRevenueOverviewStats(shopId, 360);
            result.Add(revenueOverviewData.Key, revenueOverviewData.Value);

            return result;
        }


        #region DailyStats

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetRevenueDailyStats(Guid shopId)
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user && x.Shop.Id == shopId);

            List<string> revenueDates = new List<string>();
            List<string> revenueValues = new List<string>();
            List<string> revenueEmpty = new List<string>();

            revenueValues.Add(rustPurchaseStats.Select(x => x.RustPurchasedItem.TotalPaid).Sum().ToString());

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.Revenue, (revenueDates, revenueValues, revenueEmpty));
        }

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOrdersDailyStats(Guid shopId)
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user && x.Shop.Id == shopId);

            List<string> ordersDates = new List<string>();
            List<string> ordersValues = new List<string>();
            List<string> ordersEmpty = new List<string>();

            ordersValues.Add(rustPurchaseStats.Count().ToString("G29"));

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.Orders, (ordersDates, ordersValues, ordersEmpty));
        }

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetSoldItemsDailyStats(Guid shopId)
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user && x.Shop.Id == shopId);

            List<string> itemsSoldDates = new List<string>();
            List<string> itemsSoldValues = new List<string>();
            List<string> itemsSoldEmpty = new List<string>();

            itemsSoldValues.Add(rustPurchaseStats.Select(x => x.RustPurchasedItem.AmountOnPurchase * x.RustPurchasedItem.ItemsPerStack).Sum().ToString("G29"));

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.ItemsSold, (itemsSoldDates, itemsSoldValues, itemsSoldEmpty));
        }

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetBuyersDailyStats(Guid shopId)
        {
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == DateTime.Today.Date && x.AppUser == _user && x.Shop.Id == shopId);

            List<string> buyersDates = new List<string>();
            List<string> buyersValues = new List<string>();
            List<string> buyersEmpty = new List<string>();

            buyersValues.Add(rustPurchaseStats
                .Select(x => x.RustPurchasedItem.SteamUser)
                .ToList()
                .Distinct()
                .Count()
                .ToString("G29"));

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.Buyers, (buyersDates, buyersValues, buyersEmpty));
        }

        #endregion DailyStats

        #region StatsByPeriod

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetRevenueStats(Guid shopId, int daysPeriod)
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
            List<string> revenueValues = new List<string>();
            List<string> revenueEmpty = new List<string>();

            for (int i = daysPeriod; i >= 0; i--)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                revenueDates.Add(selectedDay.DayOfWeek.ToString());
                var soldProductOfSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date);

                decimal totalRevenueInSelectedDate = 0m;
                foreach (var item in soldProductOfSelectedDate)
                    totalRevenueInSelectedDate += item.RustPurchasedItem.TotalPaid;
                revenueValues.Add(totalRevenueInSelectedDate.ToString());
            }

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.Revenue, (revenueDates, revenueValues, revenueEmpty));
        }

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOrdersStats(Guid shopId, int daysPeriod)
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
            List<string> ordersValues = new List<string>();
            List<string> ordersEmpty = new List<string>();

            for (int i = daysPeriod; i >= 0; i--)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                ordersDates.Add(selectedDay.DayOfWeek.ToString());
                var soldProductOfSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                ordersValues.Add(soldProductOfSelectedDate.Count.ToString());
            }

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.Orders, (ordersDates, ordersValues, ordersEmpty));
        }

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetSoldItemsStats(Guid shopId, int daysPeriod)
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
            List<string> itemsSoldValues = new List<string>();
            List<string> itemsSoldEmpty = new List<string>();

            for (int i = daysPeriod; i >= 0; i--)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                itemsSoldDates.Add(selectedDay.DayOfWeek.ToString());
                var soldProductsInSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                int soldItemsInSelectedDate = 0;
                soldProductsInSelectedDate
                        .Select(x => x.RustPurchasedItem.AmountOnPurchase * x.RustPurchasedItem.ItemsPerStack)
                        .ToList()
                        .ForEach(x => soldItemsInSelectedDate += x);

                itemsSoldValues.Add(soldItemsInSelectedDate.ToString());
            }

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.ItemsSold, (itemsSoldDates, itemsSoldValues, itemsSoldEmpty));
        }

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetBuyersStats(Guid shopId, int daysPeriod)
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
            List<string> buyersEmpty = new List<string>();

            for (int i = daysPeriod; i >= 0 ; i--)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));

                buyersDates.Add(selectedDay.DayOfWeek.ToString());
                var soldProductInSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                var buyersInSelectedDate = soldProductInSelectedDate.Select(x => x.RustPurchasedItem.SteamUser.Uid).Distinct().Count().ToString("G29");
                buyersValues.Add(buyersInSelectedDate);
            }

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.Buyers, (buyersDates, buyersValues, buyersEmpty));
        }

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetRevenueOverviewStats(Guid shopId, int daysPeriod)
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
            List<string> revenueOverviewPreviousWeekValues = new List<string>();

            for (int i = daysPeriod; i >= 0; i--)
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

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.RevenueOverview, (revenueOverviewDates, revenueOverviewValues, revenueOverviewPreviousWeekValues));
        }

        #endregion StatsByPeriod
    }
}
