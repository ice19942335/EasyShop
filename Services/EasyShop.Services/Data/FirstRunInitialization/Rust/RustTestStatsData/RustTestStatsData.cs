using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.Entries.Users;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Shop;
using EasyShop.Interfaces.Services.CP.Rust.Data;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Interfaces.Services.MultiTenancy;
using EasyShop.Interfaces.Services.Rust;
using EasyShop.Services.Data.FirstRunInitialization.IdentityInitialization;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShop.Services.Data.FirstRunInitialization.Rust.RustTestStatsData
{
    public class RustTestStatsData : IRustTestStatsData
    {
        private readonly IShopService _shopService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRustShopService _rustShopService;
        private readonly EasyShopContext _easyShopContext;
        private readonly IRustDefaultCategoriesWithItemsService _rustDefaultCategoriesWithItemsService;
        private readonly IMultiTenancyStoreService _tenancyStoreService;

        private Shop _newShop;

        public RustTestStatsData(
            IShopService shopService,
            UserManager<AppUser> userManager,
            IRustShopService rustShopService,
            EasyShopContext easyShopContext,
            IRustDefaultCategoriesWithItemsService rustDefaultCategoriesWithItemsService,
            IMultiTenancyStoreService tenancyStoreService)
        {
            _shopService = shopService;
            _userManager = userManager;
            _rustShopService = rustShopService;
            _easyShopContext = easyShopContext;
            _rustDefaultCategoriesWithItemsService = rustDefaultCategoriesWithItemsService;
            _tenancyStoreService = tenancyStoreService;
        }

        public async Task InitializeDefaultStatsData()
        {
            if (!_easyShopContext.RustPurchaseStats.Any())
            {
                Guid shopId = await CreateDefaultShopForAdmin();
                await CreateTestStats(shopId);
            }
        }

        private async Task<Guid> CreateDefaultShopForAdmin()
        {
            var user = await _userManager.FindByEmailAsync(DefaultIdentity.AdminUserName);

            var model = new CreateShopViewModel
            {
                ShopName = "TestDataShop",
                ShopTitle = "TestDataShop",
                StartBalance = 50000,
                GameType = "Rust",
                AddDefaultItems = true
            };

            Guid secret;
            do
            {
                secret = Guid.NewGuid();
            } while (_easyShopContext.Shops.FirstOrDefault(x => x.Secret == secret) != null);

            var gameType = _easyShopContext.GameTypes.First(x => x.Type == model.GameType);

            Guid newShopId;
            do
            {
                newShopId = Guid.NewGuid();
            } while (_easyShopContext.UserShops.FirstOrDefault(x => x.ShopId == newShopId) != null);

            var newShop = new Shop
            {
                Id = newShopId,
                ShopName = model.ShopName,
                GameType = gameType,
                ShopTitle = model.ShopTitle,
                StartBalance = model.StartBalance,
                Secret = secret
            };

            _newShop = newShop;

            var userShop = new UserShop
            {
                ShopId = newShopId,
                Shop = newShop,
                AppUserId = user.Id,
                AppUser = user
            };

            var addNewTenant = await _tenancyStoreService.TryAddAsync(
                newShopId.ToString(),
                    newShopId.ToString(),
                    model.ShopName,
                    null);

            if (!addNewTenant)
                throw new ApplicationException($"Cannot add tenant in to DB, please check connection string for context - {nameof(RustShopMultiTenantStoreContext)}");
            

            _easyShopContext.Shops.Add(newShop);
            _easyShopContext.UserShops.Add(userShop);
            await _easyShopContext.SaveChangesAsync();

            (List<RustCategory>, List<RustProduct>)? defaultData = GetDefaultCategoriesWithProducts(user, newShop);

            _easyShopContext.RustCategories.AddRange(defaultData?.Item1);
            _easyShopContext.RustUserItems.AddRange(defaultData?.Item2);

            await _easyShopContext.SaveChangesAsync();

            return newShopId;
        }

        private async Task CreateTestStats(Guid shopId)
        {
            var purchasedItemsList = new List<RustPurchasedItem>();
            var rustPurchaseStatsList = new List<RustPurchaseStats>();

            var user = await _userManager.FindByEmailAsync(DefaultIdentity.AdminUserName);
            var shop = _shopService.GetShopById(shopId);
            var steamUser = await CreateDefaultRustUser();

            DateTime dateWeekAgo = DateTime.Now.Subtract(TimeSpan.FromDays(7));
            DateTime dateMonthAgo = DateTime.Now.Subtract(TimeSpan.FromDays(31));
            DateTime dateYearAgo = DateTime.Now.Subtract(TimeSpan.FromDays(365));

            Random rnd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                var rustPurchasedItem = new RustPurchasedItem
                {
                    Id = Guid.NewGuid(),
                    RustUser = steamUser,
                    RustItem = _easyShopContext.RustItems.First(),
                    HasBeenUsed = false,
                    Amount = rnd.Next(1, 3),
                    TotalPaid = rnd.Next(1, 5),
                };

                if (i >= 0 && i < 50) //Last week
                    rustPurchasedItem.PurchaseDateTime = dateWeekAgo.AddDays(rnd.Next(0, 7));
                else if (i >= 50 && i < 200) //Last month
                    rustPurchasedItem.PurchaseDateTime = dateMonthAgo.AddDays(rnd.Next(0, 24));
                else if (i >= 200 && i < 1000) //Last three months
                    rustPurchasedItem.PurchaseDateTime = dateYearAgo.AddDays(rnd.Next(0, 330));


                purchasedItemsList.Add(rustPurchasedItem);

                var rustPurchaseStats = new RustPurchaseStats
                {
                    Id = Guid.NewGuid(),
                    AppUser = user,
                    RustPurchasedItem = rustPurchasedItem,
                    Shop = shop
                };

                rustPurchaseStatsList.Add(rustPurchaseStats);
            }

            await _easyShopContext.RustPurchasedItems.AddRangeAsync(purchasedItemsList);
            await _easyShopContext.RustPurchaseStats.AddRangeAsync(rustPurchaseStatsList);
            await _easyShopContext.SaveChangesAsync();
        }

        private (List<RustCategory>, List<RustProduct>) GetDefaultCategoriesWithProducts(AppUser user, Shop shop)
        {
            var defaultCategories = _easyShopContext.RustCategories.Include(x => x.AppUser).Where(x => x.AppUser == null).ToList();
            var rustItems = _easyShopContext.RustItems.ToList();

            return _rustDefaultCategoriesWithItemsService.CreateDefaultCategoriesWithItems(user, shop, defaultCategories, rustItems);
        }

        private async Task<SteamUser> CreateDefaultRustUser()
        {
            Guid newSteamUserGuid;

            do
            {
                newSteamUserGuid = Guid.NewGuid();
            } while (_easyShopContext.SteamUsers.FirstOrDefault(x => x.Id == newSteamUserGuid) != null);

            var newSteamUser = new SteamUser
            {
                Id = newSteamUserGuid,
                Uid = "76561198882487777",
                TotalSpent = 0m
            };

            var newSteamUserShop = new SteamUserShop
            {
                ShopId = _newShop.Id,
                Shop = _newShop,
                SteamUserId = newSteamUser.Id,
                SteamUser = newSteamUser,
                Balance = _newShop.StartBalance,
                TotalSpent = 0m
            };

            _easyShopContext.SteamUsers.Add(newSteamUser);
            _easyShopContext.SteamUsersShops.Add(newSteamUserShop);
            await _easyShopContext.SaveChangesAsync();

            return newSteamUser;
        }
    }
}
