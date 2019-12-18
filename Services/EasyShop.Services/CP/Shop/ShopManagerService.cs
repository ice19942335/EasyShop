using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Interfaces.Services.CP.Shop;
using Microsoft.AspNetCore.Identity;

namespace EasyShop.Services.CP.Shop
{
    public class ShopManagerService : IShopManagerService
    {
        private readonly EasyShopContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ShopManagerService(EasyShopContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<IEnumerable<Domain.Entries.Shop.Shop>> UserShopsByUserEmail(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user is null)
                return null;

            var query = from userShop in _context.UserShops
                join shops in _context.Shops on userShop.ShopId equals shops.Id
                where userShop.AppUserId == user.Id
                select new Domain.Entries.Shop.Shop
                {
                    Id = shops.Id,
                    ShopName = shops.ShopName,
                    GameType = shops.GameType,
                    ShopTitle = shops.ShopTitle,
                    StartBalance = shops.StartBalance,
                    Secret = shops.Secret
                };

            return query.AsEnumerable();
        }
    }
}
