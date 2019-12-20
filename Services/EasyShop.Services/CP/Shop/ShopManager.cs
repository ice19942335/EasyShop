using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;
using EasyShop.Interfaces.Services.CP.Shop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EasyShop.Services.CP.Shop
{
    public class ShopManager : IShopManager
    {
        private readonly EasyShopContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly HttpContext _httpContext;

        public ShopManager(EasyShopContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContext, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
            _httpContext = httpContext.HttpContext;
        }

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

        public async Task<bool> CreateShopAsync(CreateShopViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(_httpContext.User.Identity.Name);

            var userShops = await UserShopsByUserEmailAsync(user.Email);

            var userAllowedShops = int.Parse(_configuration["ShopsAllowed"]);

            if (userAllowedShops > userShops.Count())
            {
                Guid secret;
                do { secret = Guid.NewGuid(); } while (_context.Shops.FirstOrDefault(x => x.Secret == secret) != null);

                var gameType = _context.GameTypes.First(x => x.Type == model.GameType);

                var newShop = new Domain.Entries.Shop.Shop
                {
                    ShopName = model.ShopName,
                    GameType = gameType,
                    ShopTitle = model.ShopTitle,
                    StartBalance = model.StartBalance,
                    Secret = secret
                };

                Guid userShopId;
                do { userShopId = Guid.NewGuid(); } while (_context.UserShops.FirstOrDefault(x => x.ShopId == userShopId) != null);

                var userShop = new UserShop
                {
                    ShopId = userShopId,
                    Shop = newShop,
                    AppUserId = user.Id,
                    AppUser = user
                };
                
                _context.Shops.Add(newShop);
                _context.UserShops.Add(userShop);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<Domain.Entries.Shop.Shop> GetShopByIdAsync(Guid shopId) =>
            _context.Shops.Include(x => x.GameType).FirstOrDefault(x => x.Id == shopId);

    }
}
