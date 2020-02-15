using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Interfaces.SqlServices.Rust.Stats;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Services.SqlServices.Rust.Stats
{
    public class RustPurchaseStatsServiceSql : IRustPurchaseStatsServiceSql
    {
        private readonly EasyShopContext _easyShopContext;

        public RustPurchaseStatsServiceSql(EasyShopContext easyShopContext)
        {
            _easyShopContext = easyShopContext;
        }

        public async Task<RustPurchaseStats> CreateAsync(AppUser appUser, RustPurchasedItem rustPurchasedItem, Shop shop)
        {
            throw new NotImplementedException();
        }

        public RustPurchaseStats GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RustPurchaseStats> GetAll()
        {
            return _easyShopContext.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.RustPurchasedItem.SteamUser)
                .Include(x => x.Shop)
                .OrderBy(x => x.RustPurchasedItem.PurchaseDateTime)
                .ToList()
                .AsEnumerable();
        }

        public IEnumerable<RustPurchaseStats> GetAllByShopIdAndSteamUserId(Guid shopId, Guid steamUserId)
        {
            return _easyShopContext.RustPurchaseStats
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem)
                .Include(x => x.RustPurchasedItem.RustItem)
                .Include(x => x.RustPurchasedItem.SteamUser)
                .Include(x => x.Shop)
                .Where(x => x.Shop.Id == shopId && x.RustPurchasedItem.SteamUser.Id == steamUserId)
                .ToList()
                .OrderByDescending(x => x.RustPurchasedItem.PurchaseDateTime);
        }

        public Task<RustPurchaseStats> UpdateAsync(AppUser appUser = null, RustPurchasedItem rustPurchasedItem = null, Shop shop = null)
        {
            throw new NotImplementedException();
        }

        public Task<RustPurchaseStats> DeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
