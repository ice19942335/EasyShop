using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.Shop.Rust;
using EasyShop.Interfaces.Services.CP.Shop;
using EasyShop.Interfaces.Services.CP.Shop.Rust;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace EasyShop.Services.CP.Shop.Rust
{
    public class RustShopService : IRustShopService
    {
        private readonly IShopManager _shopManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly EasyShopContext _context;
        private readonly ILogger<RustShopService> _logger;

        public RustShopService(IShopManager shopManager, UserManager<AppUser> userManager, EasyShopContext context, ILogger<RustShopService> logger)
        {
            _shopManager = shopManager;
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        public async Task<Domain.Entries.Shop.Shop> UpdateShopAsync(MainSettingsRustShopViewModel model)
        {
            var shop = await _shopManager.GetShopByIdAsync(model.Id);

            if (shop is null)
                return null;

            shop.ShopName = model.ShopName;
            shop.ShopTitle = model.ShopTitle;
            shop.StartBalance = model.StartBalance;

            try
            {
                _context.Shops.Update(shop);
                await _context.SaveChangesAsync();

                return shop;
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.Message);
                return null;
            }
        }
    }
}
