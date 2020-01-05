using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.Rust;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
            throw new NotImplementedException();
        }

        public Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetLastWeekStats(Guid shopId)
        {
            Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> result =
                new Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>();

            var revenueData = GetRevenueWeeklyStats();
            result.Add(revenueData.Key, revenueData.Value);

            var ordersData = GetOrdersWeeklyStats();
            result.Add(ordersData.Key, ordersData.Value);

            var itemsSoldData = GetItemsSoldWeeklyStats();
            result.Add(itemsSoldData.Key, itemsSoldData.Value);

            var buyersData = GetBuyersWeeklyStats();
            result.Add(buyersData.Key, buyersData.Value);

            var revenueOverviewData = GetRevenueOverviewWeeklyStats();
            result.Add(revenueOverviewData.Key, revenueOverviewData.Value);

            return result;
        }

        public Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetLastMonthStats(Guid shopId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetLastThreeMonthStats(Guid shopId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetLastSixMonthStats(Guid shopId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetLastYearStats(Guid shopId)
        {
            throw new NotImplementedException();
        }

        #region WeeklyStats

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetRevenueWeeklyStats()
        {
            DateTime dateWeekAgo = DateTime.Now.Subtract(TimeSpan.FromDays(7));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime > dateWeekAgo && x.RustPurchasedItem.PurchaseDateTime <= DateTime.Now && x.AppUser == _user);

            List<string> revenueDates = new List<string>();
            List<string> revenueValues = new List<string>();
            List<string> revenueEmpty = new List<string>();

            for (int i = 0; i < 7; i++)
            {
                var selectedDay = DateTime.Now.Subtract(TimeSpan.FromDays(i));

                revenueDates.Add(selectedDay.DayOfWeek.ToString());
                var soldProductOfSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date);

                decimal totalRevenueInSelectedDate = 0m;
                foreach (var item in soldProductOfSelectedDate)
                    totalRevenueInSelectedDate += item.RustPurchasedItem.TotalPaid;
                revenueValues.Add(totalRevenueInSelectedDate.ToString());
            }

            revenueDates.Reverse();
            revenueValues.Reverse();

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.Revenue, (revenueDates, revenueValues, revenueEmpty));
        }

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetOrdersWeeklyStats()
        {
            DateTime dateWeekAgo = DateTime.Now.Subtract(TimeSpan.FromDays(7));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime > dateWeekAgo && x.RustPurchasedItem.PurchaseDateTime <= DateTime.Now && x.AppUser == _user);

            List<string> ordersDates = new List<string>();
            List<string> ordersValues = new List<string>();
            List<string> ordersEmpty = new List<string>();

            for (int i = 0; i < 7; i++)
            {
                var selectedDay = DateTime.Now.Subtract(TimeSpan.FromDays(i));

                ordersDates.Add(selectedDay.DayOfWeek.ToString());
                var soldProductOfSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                ordersValues.Add(soldProductOfSelectedDate.Count.ToString());
            }

            ordersDates.Reverse();
            ordersValues.Reverse();

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.Orders, (ordersDates, ordersValues, ordersEmpty));
        }

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetItemsSoldWeeklyStats()
        {
            DateTime dateWeekAgo = DateTime.Now.Subtract(TimeSpan.FromDays(7));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime > dateWeekAgo && x.RustPurchasedItem.PurchaseDateTime <= DateTime.Now && x.AppUser == _user);

            List<string> itemsSoldDates = new List<string>();
            List<string> itemsSoldValues = new List<string>();
            List<string> itemsSoldEmpty = new List<string>();

            for (int i = 0; i < 7; i++)
            {
                var selectedDay = DateTime.Now.Subtract(TimeSpan.FromDays(i));

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

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.ItemsSold, (itemsSoldDates, itemsSoldValues, itemsSoldEmpty));
        }

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetBuyersWeeklyStats()
        {
            DateTime dateWeekAgo = DateTime.Now.Subtract(TimeSpan.FromDays(7));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime > dateWeekAgo && x.RustPurchasedItem.PurchaseDateTime <= DateTime.Now && x.AppUser == _user);

            List<string> buyersDates = new List<string>();
            List<string> buyersValues = new List<string>();
            List<string> buyersEmpty = new List<string>();

            for (int i = 0; i < 7; i++)
            {
                var selectedDay = DateTime.Now.Subtract(TimeSpan.FromDays(i));

                buyersDates.Add(selectedDay.DayOfWeek.ToString());
                var soldProductInSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date).ToList();

                var buyersInSelectedDate = soldProductInSelectedDate.Select(x => x.RustPurchasedItem.RustUser).ToList().Distinct();

                buyersValues.Add(buyersInSelectedDate.Count().ToString());
            }

            buyersDates.Reverse();
            buyersValues.Reverse();

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.Buyers, (buyersDates, buyersValues, buyersEmpty));
        }

        private KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetRevenueOverviewWeeklyStats()
        {
            DateTime dateTwoWeeksAgo = DateTime.Today.Subtract(TimeSpan.FromDays(14));
            var rustPurchaseStats = _context.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.Shop)
                .Where(x => x.RustPurchasedItem.PurchaseDateTime > dateTwoWeeksAgo && x.RustPurchasedItem.PurchaseDateTime <= DateTime.Today && x.AppUser == _user);

            List<string> revenueOverviewDates = new List<string>();
            List<string> revenueOverviewValues = new List<string>();
            List<string> revenueOverviewPreviousWeekValues = new List<string>();

            for (int i = 0; i < 7; i++)
            {
                var selectedDay = DateTime.Today.Subtract(TimeSpan.FromDays(i));
                var selectedDateWeekAgo = selectedDay.Subtract(TimeSpan.FromDays(7));

                revenueOverviewDates.Add(selectedDay.DayOfWeek.ToString());

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

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.RevenueOverview, (revenueOverviewDates, revenueOverviewValues, revenueOverviewPreviousWeekValues));
        }

        #endregion WeeklyStats
    }
}
