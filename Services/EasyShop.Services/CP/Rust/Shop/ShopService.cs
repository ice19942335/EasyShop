using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Interfaces.Services.CP.Rust.Data;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Services.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EasyShop.Services.CP.Rust.Shop
{
    public class ShopService : IShopService
    {
        private readonly EasyShopContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<ShopService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShopService(EasyShopContext context,
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            ILogger<ShopService> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
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

            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"Secret was successfully updated. shopId: {shop.Id}");

            return true;
        }
    }
}
