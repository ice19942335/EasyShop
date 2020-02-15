using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Entries.Shop;

namespace EasyShop.Interfaces.SqlServices.Rust.Stats
{
    public interface IRustPurchaseStatsServiceSql
    {
        Task<RustPurchaseStats> CreateAsync(AppUser appUser, RustPurchasedItem rustPurchasedItem, Shop shop);

        RustPurchaseStats GetById(Guid id);

        IEnumerable<RustPurchaseStats> GetAll();

        IEnumerable<RustPurchaseStats> GetAllByShopIdAndSteamUserId(Guid shopId, Guid steamUserId);

        Task<RustPurchaseStats> UpdateAsync(AppUser appUser = null, RustPurchasedItem rustPurchasedItem = null, Shop shop = null);

        Task<RustPurchaseStats> DeleteAsync();
    }
}
