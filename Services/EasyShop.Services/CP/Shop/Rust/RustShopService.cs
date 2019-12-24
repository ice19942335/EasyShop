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
using Microsoft.AspNetCore.Http;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RustShopService(IShopManager shopManager, UserManager<AppUser> userManager, EasyShopContext context, ILogger<RustShopService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _shopManager = shopManager;
            _userManager = userManager;
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }


        #region Rust Chop
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

        public async Task<bool> DeleteShopAsync(Guid shopId)
        {
            var userShop = _context.UserShops.FirstOrDefault(x => x.ShopId == shopId);
            var shop = _context.Shops.FirstOrDefault(x => x.Id == shopId);

            if (userShop is null || shop is null)
                return false;

            var allAssignedCategoriesToShop = await GetAllAssignedItemsToShopByIdAsync(shopId);

            _context.RustCategories.RemoveRange(allAssignedCategoriesToShop);
            await _context.SaveChangesAsync();

            _context.UserShops.Remove(userShop);
            _context.Shops.Remove(shop);

            await _context.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Rust Category
        public async Task<IEnumerable<RustCategory>> GetAllAssignedItemsToShopByIdAsync(Guid shopId)
        {
            var categories = _context.RustCategories
                .Include(x => x.AppUser)
                .Include(x => x.Shop)
                .Where(x => x.Shop.Id == shopId)
                .OrderBy(x => x.Index)
                .AsEnumerable();

            return categories;
        }

        public async Task<RustCategory> UpdateCategoryAsync(RustShopViewModel model)
        {
            if (model.EditRustCategoryViewModel.Category.Id is null)
            {
                var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(model.Id));

                if (shop is null)
                    return null;

                RustCategory newCategory = new RustCategory
                {
                    Id = Guid.NewGuid(),
                    Index = 1,
                    Name = model.EditRustCategoryViewModel.Category.Name,
                    AppUser = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name),
                    Shop = shop
                };

                _context.RustCategories.Add(newCategory);
                await _context.SaveChangesAsync();

                return newCategory;
            }

            var category = GetCategoryById(Guid.Parse(model.EditRustCategoryViewModel.Category.Id));

            if (category is null)
                return null;

            category.Index = model.EditRustCategoryViewModel.Category.Index;
            category.Name = model.EditRustCategoryViewModel.Category.Name;

            _context.RustCategories.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public RustCategory GetCategoryById(Guid categoryId) => _context.RustCategories
            .Include(x => x.AppUser).Include(x => x.Shop).FirstOrDefault(x => x.Id == categoryId);

        public async Task<bool> DeleteCategory(Guid categoryId)
        {
            var category = _context.RustCategories.FirstOrDefault(x => x.Id == categoryId);

            if (category is null)
                return false;

            _context.RustCategories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Rust Items
        public int GetAssignedUserItemsCountToACategoryInShop(Guid categoryId, Guid shopId)
        {
            var result = _context.RustUserItems
                .Include(x => x.Shop)
                .Include(x => x.RustCategory)
                .Where(x => x.RustCategory.Id == categoryId && x.Shop.Id == shopId).ToList().Count;

            return result;
        }
        #endregion
    }
}
