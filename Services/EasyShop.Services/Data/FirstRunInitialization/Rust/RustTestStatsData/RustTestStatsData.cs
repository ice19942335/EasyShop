using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.ControlPanel.Shop;
using EasyShop.Interfaces.Services.CP.Rust.Data;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Services.Data.FirstRunInitialization.IdentityInitialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Services.Data.FirstRunInitialization.Rust.RustTestStatsData
{
    public class RustTestStatsData : IRustTestStatsData
    {
        private readonly IShopManager _shopManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IRustShopService _rustShopService;
        private readonly EasyShopContext _context;
        private readonly IRustDefaultCategoriesWithItemsService _rustDefaultCategoriesWithItemsService;

        public RustTestStatsData(
            IShopManager shopManager,
            UserManager<AppUser> userManager,
            IRustShopService rustShopService,
            EasyShopContext context,
            IRustDefaultCategoriesWithItemsService rustDefaultCategoriesWithItemsService)
        {
            _shopManager = shopManager;
            _userManager = userManager;
            _rustShopService = rustShopService;
            _context = context;
            _rustDefaultCategoriesWithItemsService = rustDefaultCategoriesWithItemsService;
        }

        public async Task InitializeDefaultStatsData()
        {
            if (!_context.RustPurchaseStats.Any())
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
            } while (_context.Shops.FirstOrDefault(x => x.Secret == secret) != null);

            var gameType = _context.GameTypes.First(x => x.Type == model.GameType);

            Guid newShopId;
            do
            {
                newShopId = Guid.NewGuid();
            } while (_context.UserShops.FirstOrDefault(x => x.ShopId == newShopId) != null);

            var newShop = new Shop
            {
                Id = newShopId,
                ShopName = model.ShopName,
                GameType = gameType,
                ShopTitle = model.ShopTitle,
                StartBalance = model.StartBalance,
                Secret = secret
            };

            var userShop = new UserShop
            {
                ShopId = newShopId,
                Shop = newShop,
                AppUserId = user.Id,
                AppUser = user
            };

            _context.Shops.Add(newShop);
            _context.UserShops.Add(userShop);
            await _context.SaveChangesAsync();

            (List<RustCategory>, List<RustProduct>)? defaultData = GetDefaultCategoriesWithProducts(user, newShop);

            _context.RustCategories.AddRange(defaultData?.Item1);
            _context.RustUserItems.AddRange(defaultData?.Item2);

            await _context.SaveChangesAsync();

            return newShopId;
        }

        private async Task CreateTestStats(Guid shopId)
        {
            var purchasedItemsList = new List<RustPurchasedItem>();
            var rustPurchaseStatsList = new List<RustPurchaseStats>();

            var user = await _userManager.FindByEmailAsync(DefaultIdentity.AdminUserName);
            var shop = _shopManager.GetShopById(shopId);
            var rustUser = await CreateDefaultRustUser();

            DateTime dateWeekAgo = DateTime.Now.Subtract(TimeSpan.FromDays(7));
            DateTime dateMonthAgo = DateTime.Now.Subtract(TimeSpan.FromDays(31));
            DateTime dateYearAgo = DateTime.Now.Subtract(TimeSpan.FromDays(365));

            Random rnd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                var rustPurchasedItem = new RustPurchasedItem
                {
                    Id = Guid.NewGuid(),
                    RustUser = rustUser,
                    RustItem = _context.RustItems.First(),
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

            await _context.RustPurchasedItems.AddRangeAsync(purchasedItemsList);
            await _context.RustPurchaseStats.AddRangeAsync(rustPurchaseStatsList);
            await _context.SaveChangesAsync();
        }

        private (List<RustCategory>, List<RustProduct>) GetDefaultCategoriesWithProducts(AppUser user, Shop shop)
        {
            var defaultCategories = _context.RustCategories.Include(x => x.AppUser).Where(x => x.AppUser == null).ToList();
            var rustItems = _context.RustItems.ToList();

            return _rustDefaultCategoriesWithItemsService.CreateDefaultCategoriesWithItems(user, shop, defaultCategories, rustItems);
        }

        private async Task<RustUser> CreateDefaultRustUser()
        {
            var rustUser = new RustUser
            {
                Id = Guid.NewGuid(),
                Uid = "76561198302334945",
                Balance = 50,
                TotalSpent = 150
            };

            _context.RustUsers.Add(rustUser);
            await _context.SaveChangesAsync();

            return rustUser;
        }
    }
}
