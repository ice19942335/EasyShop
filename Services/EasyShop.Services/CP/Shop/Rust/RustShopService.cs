using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Items.RustItems;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;
using EasyShop.Interfaces.Services.CP.Shop;
using EasyShop.Interfaces.Services.CP.Shop.Rust;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Security;
using Guid = System.Guid;

namespace EasyShop.Services.CP.Shop.Rust
{
    public class RustShopService : IRustShopService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly EasyShopContext _context;
        private readonly ILogger<RustShopService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRustDefaultCategoriesWithItemsService _rustDefaultCategoriesWithItemsService;

        public RustShopService(
            IConfiguration configuration,
            UserManager<AppUser> userManager,
            EasyShopContext context,
            ILogger<RustShopService> logger,
            IHttpContextAccessor httpContextAccessor,
            IRustDefaultCategoriesWithItemsService rustDefaultCategoriesWithItemsService)
        {
            _configuration = configuration;
            _userManager = userManager;
            _context = context;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _rustDefaultCategoriesWithItemsService = rustDefaultCategoriesWithItemsService;
        }

        #region Rust Shop
        public async Task<bool> CreateShopAsync(CreateShopViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

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

                Guid newUserShopId;
                do { newUserShopId = Guid.NewGuid(); } while (_context.UserShops.FirstOrDefault(x => x.ShopId == newUserShopId) != null);

                var userShop = new UserShop
                {
                    ShopId = newUserShopId,
                    Shop = newShop,
                    AppUserId = user.Id,
                    AppUser = user
                };

                _context.Shops.Add(newShop);
                _context.UserShops.Add(userShop);
                await _context.SaveChangesAsync();

                if (model.AddDefaultItems)
                {
                    try
                    {
                        (List<RustCategory>, List<RustUserItem>)? defaultCategoriesAndItems = await SetDefaultProductsAsync(user, newShop);
                        if (defaultCategoriesAndItems != null)
                        {
                            _context.RustCategories.AddRange(defaultCategoriesAndItems?.Item1);
                            _context.RustUserItems.AddRange(defaultCategoriesAndItems?.Item2);
                            await _context.SaveChangesAsync();
                        }

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        private async Task<IEnumerable<Domain.Entries.Shop.Shop>> UserShopsByUserEmailAsync(string userEmail)
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

        public async Task<Domain.Entries.Shop.Shop> UpdateShopAsync(MainSettingsRustShopViewModel model)
        {
            var shop = await GetShopByIdAsync(Guid.Parse(model.Id));

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
                var shop = await GetShopByIdAsync(Guid.Parse(model.Id));

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

        #region Rust Products
        public int GetAssignedUserItemsCountToACategoryInShop(Guid categoryId, Guid shopId)
        {
            var result = _context.RustUserItems
                .Include(x => x.Shop)
                .Include(x => x.RustCategory)
                .Where(x => x.RustCategory.Id == categoryId && x.Shop.Id == shopId).ToList().Count;

            return result;
        }

        public async Task<(List<RustCategory>, List<RustUserItem>)> GetDefaultCategoriesWithProducts(AppUser user, Domain.Entries.Shop.Shop shop)
        {
            var defaultCategories = _context.RustCategories.Include(x => x.AppUser).Where(x => x.AppUser == null).ToList();
            var rustItems = _context.RustItems.ToList();

            return await _rustDefaultCategoriesWithItemsService.CreateDefaultCategoriesWithItems(user, shop, defaultCategories, rustItems);
        }

        public async Task<bool> SetDefaultProductsAsync(Domain.Entries.Shop.Shop shop)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

                (List<RustCategory>, List<RustUserItem>)? defaultCategoriesAndItems = await SetDefaultProductsAsync(user, shop);
                if (defaultCategoriesAndItems != null)
                {
                    _context.RustCategories.AddRange(defaultCategoriesAndItems?.Item1);
                    _context.RustUserItems.AddRange(defaultCategoriesAndItems?.Item2);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<(List<RustCategory>, List<RustUserItem>)?> SetDefaultProductsAsync(AppUser user, Domain.Entries.Shop.Shop shop)
        {
            await RemoveAllCategoriesAndItemsInShopAsync(shop);
            return await GetDefaultCategoriesWithProducts(user, shop);
        }
        #endregion

        #region Private methods
        private async Task RemoveAllCategoriesAndItemsInShopAsync(Domain.Entries.Shop.Shop shop)
        {
            _context.RustCategories.RemoveRange(_context.RustCategories.Where(x => x.Shop.Id == shop.Id));
            await _context.SaveChangesAsync();
        }

        private async Task<Domain.Entries.Shop.Shop> GetShopByIdAsync(Guid shopId) => _context.Shops.FirstOrDefault(x => x.Id == shopId);
        #endregion
    }
}
