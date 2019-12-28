using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.Enums;
using EasyShop.Domain.Enums.Rust;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;
using EasyShop.Interfaces.Services.CP.Shop.Rust;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        public async Task<RustCreateShopResult> CreateShopAsync(CreateShopViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            var userShops = await UserShopsByUserEmailAsync(user.Email);

            var userAllowedShops = int.Parse(_configuration["ShopsAllowed"]);

            if (userShops.Count() < userAllowedShops)
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
                        (List<RustCategory>, List<RustProduct>)? defaultCategoriesAndItems = await SetDefaultProductsAsync(user, newShop);
                        if (defaultCategoriesAndItems != null)
                        {
                            _context.RustCategories.AddRange(defaultCategoriesAndItems?.Item1);
                            _context.RustUserItems.AddRange(defaultCategoriesAndItems?.Item2);
                            await _context.SaveChangesAsync();
                        }

                        return RustCreateShopResult.Success;
                    }
                    catch
                    {
                        _context.Shops.Remove(newShop);
                        _context.UserShops.Remove(userShop);
                        await _context.SaveChangesAsync();
                        return RustCreateShopResult.SomethingWentWrong;
                    }
                }

                return RustCreateShopResult.Success;
            }

            return RustCreateShopResult.MaxShopLimitIsReached;
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

        public async Task<Domain.Entries.Shop.Shop> UpdateShopAsync(RustEditShopMainSettingsViewModel model)
        {
            var shop = GetShopById(Guid.Parse(model.Id));

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
            var shop = GetShopById(shopId);

            if (userShop is null || shop is null)
                return false;

            var allAssignedCategoriesToShop = GetAllAssignedCategoriesToShopByShopId(shopId);

            _context.RustCategories.RemoveRange(allAssignedCategoriesToShop);
            await _context.SaveChangesAsync();

            _context.UserShops.Remove(userShop);
            _context.Shops.Remove(shop);

            await _context.SaveChangesAsync();

            return true;
        }

        #endregion

        #region Rust Category
        public IEnumerable<RustCategory> GetAllAssignedCategoriesToShopByShopId(Guid shopId)
        {
            var categories = _context.RustCategories
                .Include(x => x.AppUser)
                .Include(x => x.Shop)
                .Where(x => x.Shop.Id == shopId)
                .OrderBy(x => x.Index)
                .AsEnumerable();

            return categories;
        }

        public async Task<(RustCategory, RustEditCategoryResult)> UpdateCategoryAsync(RustShopViewModel model)
        {
            if (model.RustEditCategoryViewModel.Category.Id is null)
            {
                var shop = GetShopById(Guid.Parse(model.Id));

                if (shop is null)
                    return (null, RustEditCategoryResult.Failed);

                RustCategory newCategory = new RustCategory
                {
                    Id = Guid.NewGuid(),
                    Index = 1,
                    Name = model.RustEditCategoryViewModel.Category.Name,
                    AppUser = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name),
                    Shop = shop
                };

                _context.RustCategories.Add(newCategory);
                await _context.SaveChangesAsync();

                return (newCategory, RustEditCategoryResult.Created);
            }

            var category = GetCategoryById(Guid.Parse(model.RustEditCategoryViewModel.Category.Id));

            if (category is null)
                return (null, RustEditCategoryResult.Failed);

            category.Index = model.RustEditCategoryViewModel.Category.Index;
            category.Name = model.RustEditCategoryViewModel.Category.Name;

            _context.RustCategories.Update(category);
            await _context.SaveChangesAsync();

            return (category, RustEditCategoryResult.Success);
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

        public (List<RustCategory>, List<RustProduct>) GetDefaultCategoriesWithProducts(AppUser user, Domain.Entries.Shop.Shop shop)
        {
            var defaultCategories = _context.RustCategories.Include(x => x.AppUser).Where(x => x.AppUser == null).ToList();
            var rustItems = _context.RustItems.ToList();

            return _rustDefaultCategoriesWithItemsService.CreateDefaultCategoriesWithItems(user, shop, defaultCategories, rustItems);
        }

        public async Task<bool> SetDefaultProductsAsync(Domain.Entries.Shop.Shop shop)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

                (List<RustCategory>, List<RustProduct>)? defaultCategoriesAndItems = await SetDefaultProductsAsync(user, shop);
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

        private async Task<(List<RustCategory>, List<RustProduct>)?> SetDefaultProductsAsync(AppUser user, Domain.Entries.Shop.Shop shop)
        {
            await RemoveAllCategoriesAndItemsInShopAsync(shop);
            return GetDefaultCategoriesWithProducts(user, shop);
        }

        public IEnumerable<RustProduct> GetAllAssignedProductsToAShopByShopId(Guid shopId)
        {
            return _context.RustUserItems
                .Include(x => x.Shop)
                .Include(x => x.AppUser)
                .Include(x => x.RustItem)
                .Include(x => x.RustCategory)
                .Where(x => x.Shop.Id == shopId)
                .OrderBy(x => x.RustCategory.Index);
        }

        public RustProduct GetProductById(Guid productId)
        {
            return _context.RustUserItems
                    .Include(x => x.RustCategory)
                    .Include(x => x.RustItem)
                    .FirstOrDefault(x => x.Id == productId);
        }

        public async Task<RustEditProductResult> UpdateRustProductAsync(RustShopViewModel model)
        {
            var shop = GetShopById(Guid.Parse(model.Id));
            var product =
                _context.RustUserItems.FirstOrDefault(x => x.Id == Guid.Parse(model.RustEditProductViewModel.Id));

            if (shop is null || product is null)
                return RustEditProductResult.NotFound;

            if (!model.RustEditProductViewModel.ShowInShop)
            {
                product.ShowInShop = false;
                _context.RustUserItems.Update(product);
                await _context.SaveChangesAsync();
                return RustEditProductResult.Success;
            }
            else
            {
                product.ShowInShop = true;
                product.Name = model.RustEditProductViewModel.Name;
                product.Description = model.RustEditProductViewModel.Description;
                product.Price = model.RustEditProductViewModel.Price;
                product.Discount = model.RustEditProductViewModel.Discount;
                product.Amount = model.RustEditProductViewModel.Amount;

                if (model.RustEditProductViewModel.BlockedTill != null)
                {
                    var dateFromModel = model.RustEditProductViewModel.BlockedTill.Split('/');
                    product.BlockedTill = new DateTime(int.Parse(dateFromModel[2]), int.Parse(dateFromModel[0]), int.Parse(dateFromModel[1]));
                }
                
                if (model.RustEditProductViewModel.NewCategoryId != null)
                    product.RustCategory = GetCategoryById(Guid.Parse(model.RustEditProductViewModel.NewCategoryId));

                _context.RustUserItems.Update(product);
                await _context.SaveChangesAsync();
                return RustEditProductResult.Success;
            }
        }

        #endregion

        #region Private methods
        private async Task RemoveAllCategoriesAndItemsInShopAsync(Domain.Entries.Shop.Shop shop)
        {
            _context.RustCategories.RemoveRange(_context.RustCategories.Where(x => x.Shop.Id == shop.Id));
            await _context.SaveChangesAsync();
        }

        private Domain.Entries.Shop.Shop GetShopById(Guid shopId) => _context.Shops.FirstOrDefault(x => x.Id == shopId);
        #endregion
    }
}
