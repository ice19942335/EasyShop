using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Items.RustItems;
using EasyShop.Domain.ViewModels.Shop.Rust;
using EasyShop.Interfaces.Services.CP.Shop;
using EasyShop.Interfaces.Services.CP.Shop.Rust;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Guid = System.Guid;

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
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(model.Id));

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

        public async Task<IEnumerable<RustCategory>> GetAllAssignedCategoriesByShopIdAsync(Guid shopId)
        {
            var categories = _context.RustCategories.Include(x => x.AppUser).Include(x => x.Shop).Where(x => x.Shop.Id == shopId).AsEnumerable();

            return categories;
        }

        public int GetAssignedItemsCountToACategoryInShop(Guid categoryId, Guid shopId)
        {
            var result = _context.RustUserItems
                .Include(x => x.Shop)
                .Include(x => x.RustCategory)
                .Where(x => x.RustCategory.Id == categoryId && x.Shop.Id == shopId).ToList().Count;

            return result;
        }

        public async Task<RustCategory> UpdateCategoryAsync(EditRustCategoryViewModel model)
        {
            var category = GetCategoryById(Guid.Parse(model.Category.Id));

            if (category is null)
                return null;

            category.Name = model.Category.Name;

            _context.RustCategories.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public RustCategory GetCategoryById(Guid categoryId) => _context.RustCategories
            .Include(x => x.AppUser).Include(x => x.Shop).FirstOrDefault(x => x.Id == categoryId);
    }
}
