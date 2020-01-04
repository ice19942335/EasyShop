using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyShop.DAL.Context;
using EasyShop.Domain.Enums.Rust;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Services.CP.Rust.Shop
{
    public class RustShopStatsService : IRustShopStatsService
    {
        private readonly EasyShopContext _context;

        public RustShopStatsService(EasyShopContext context)
        {
            _context = context;
        }

        public Dictionary<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> GetYesterdayStats(Guid shopId)
        {
            throw new NotImplementedException();
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
                .Where(x => x.RustPurchasedItem.PurchaseDateTime > dateWeekAgo && x.RustPurchasedItem.PurchaseDateTime <= DateTime.Now);

            List<string> revenueDates = new List<string>();
            List<string> revenueValues = new List<string>();
            List<string> revenueEmpty = new List<string>();

            for (int i = 0; i < 7; i++)
            {
                var selectedDay = DateTime.Now.Subtract(TimeSpan.FromDays(i));

                revenueDates.Add(selectedDay.DayOfWeek.ToString());
                var soldProductOfSelectedDate = rustPurchaseStats.Where(x => x.RustPurchasedItem.PurchaseDateTime.Date == selectedDay.Date);

                decimal totalRevenueOfSelectedDate = 0m;
                foreach (var item in soldProductOfSelectedDate)
                    totalRevenueOfSelectedDate += item.RustPurchasedItem.TotalPaid;
                revenueValues.Add(totalRevenueOfSelectedDate.ToString());
            }

            revenueDates.Reverse();
            revenueValues.Reverse();

            return new KeyValuePair<RustShopStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)>(RustShopStatsUnitEnum.Revenue, (revenueDates, revenueValues, revenueEmpty));
        }

        #endregion WeeklyStats
    }
}
