using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.GameType;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Items.RustItems;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;
using EasyShop.Interfaces.Services.CP.Shop;
using EasyShop.Interfaces.Services.CP.Shop.Rust;
using EasyShop.Services.Data.FirstRunInitialization.RustShopDataInitialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EasyShop.Services.CP.Shop
{
    public class ShopManager : IShopManager
    {
        private readonly EasyShopContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<ShopManager> _logger;
        private readonly IRustShopService _rustShopService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShopManager(EasyShopContext context,
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            ILogger<ShopManager> logger,
            IRustDefaultCategoriesWithItemsService rustDefaultCategoriesWithItemsService,
            IRustShopService rustShopService)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
            _rustShopService = rustShopService;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetShopGameTypeById(Guid shopId) => GetShopById(shopId).GameType.Type;

        public async Task<IEnumerable<Domain.Entries.Shop.Shop>> UserShopsByUserEmailAsync(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user is null)
                return null;

            var query = from userShop in _context.UserShops
                        join shop in _context.Shops on userShop.ShopId equals shop.Id
                        where userShop.AppUserId == user.Id
                        select new Domain.Entries.Shop.Shop
                        {
                            Id = shop.Id,
                            ShopName = shop.ShopName,
                            GameType = _context.GameTypes.FirstOrDefault(x => x.Id == shop.GameType.Id),
                            ShopTitle = shop.ShopTitle,
                            StartBalance = shop.StartBalance,
                            Secret = shop.Secret
                        };

            var result = query.AsEnumerable();

            return result;
        }

        public Domain.Entries.Shop.Shop GetShopById(Guid shopId) =>
            _context.Shops.Include(x => x.GameType).FirstOrDefault(x => x.Id == shopId);

        public async Task<bool> NewSecretAsync(Guid shopId)
        {
            var shop = _context.Shops.FirstOrDefault(x => x.Id == shopId);

            if (shop is null)
                return false;

            Guid secret;
            do { secret = Guid.NewGuid(); } while (_context.Shops.FirstOrDefault(x => x.Secret == secret) != null);

            shop.Secret = secret;
            _context.Shops.Update(shop);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
