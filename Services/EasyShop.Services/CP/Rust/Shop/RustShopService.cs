using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.Enums.CP.Rust;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Shop;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Shop;
using EasyShop.Interfaces.Services.CP.Rust.Data;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Services.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Guid = System.Guid;

namespace EasyShop.Services.CP.Rust.Shop
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

                Guid newShopId;
                do { newShopId = Guid.NewGuid(); } while (_context.UserShops.FirstOrDefault(x => x.ShopId == newShopId) != null);

                var newShop = new Domain.Entries.Shop.Shop
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

                if (model.AddDefaultItems)
                {
                    try
                    {
                        await SetDefaultProductsAsync(user, newShop);
                        await _context.SaveChangesAsync();

                        _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                            user.UserName,
                            user.Id,
                            _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                            $"Rust shop has been successfully created! ShopId: {newShopId}");

                        return RustCreateShopResult.Success;
                    }
                    catch(Exception e)
                    {
                        _context.Shops.Remove(newShop);
                        _context.UserShops.Remove(userShop);
                        await RemoveAllCategoriesAndItemsInShopAsync(newShop);
                        await _context.SaveChangesAsync();

                        _logger.LogError("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                            user.UserName,
                            user.Id,
                            _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                            $"Error on adding default products and categories. Error message: {e.Message}; Inner exception: {e.InnerException?.Message}; Stacktrace: {e.StackTrace};");

                        return RustCreateShopResult.SomethingWentWrong;
                    }
                }

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    user.UserName,
                    user.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Rust shop has been successfully created! ShopId: {newShop.Id}");

                return RustCreateShopResult.Success;
            }

            return RustCreateShopResult.MaxShopLimitIsReached;
        }

        public async Task<Domain.Entries.Shop.Shop> UpdateShopAsync(RustShopEditMainSettingsViewModel model)
        {
            var shop = GetShopById(Guid.Parse(model.Id));

            if (shop is null)
                return null;

            shop.ShopName = model.ShopName;
            shop.ShopTitle = model.ShopTitle;
            shop.StartBalance = model.StartBalance;

            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            try
            {
                _context.Shops.Update(shop);
                await _context.SaveChangesAsync();

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    userForLog.UserName,
                    userForLog.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Shop has been successfully updated! ShopId: {shop.Id}");

                return shop;
            }
            catch (Exception e)
            {
                _logger.LogError("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    userForLog.UserName,
                    userForLog.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Error on updating shop. Error message: {e.Message}; Inner exception: {e.InnerException?.Message}; Stacktrace: {e.StackTrace};");

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

            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"Shop was successfully deleted. ShopId: {shop.Id}");

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
            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            if (model.RustCategoryEditViewModel.Category.Id is null)
            {
                var shop = GetShopById(Guid.Parse(model.Id));

                if (shop is null)
                    return (null, RustEditCategoryResult.Failed);

                RustCategory newCategory = new RustCategory
                {
                    Id = Guid.NewGuid(),
                    Index = 1,
                    Name = model.RustCategoryEditViewModel.Category.Name,
                    AppUser = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name),
                    Shop = shop
                };

                _context.RustCategories.Add(newCategory);
                await _context.SaveChangesAsync();

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    userForLog.UserName,
                    userForLog.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Category was successfully created. CategoryId: {newCategory.Id}");

                return (newCategory, RustEditCategoryResult.Created);
            }

            var category = GetCategoryById(Guid.Parse(model.RustCategoryEditViewModel.Category.Id));

            if (category is null)
                return (null, RustEditCategoryResult.Failed);

            category.Index = model.RustCategoryEditViewModel.Category.Index;
            category.Name = model.RustCategoryEditViewModel.Category.Name;

            _context.RustCategories.Update(category);
            await _context.SaveChangesAsync();

            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"Category was successfully updated. CategoryId: {category.Id}");

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

            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"Category was successfully deleted. CategoryId: {category.Id}");

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

        public async Task<bool> SetDefaultProductsAsync(AppUser user, Domain.Entries.Shop.Shop shop)
        {
            await RemoveAllCategoriesAndItemsInShopAsync(shop);
            (List<RustCategory>, List<RustProduct>)? defaultData = GetDefaultCategoriesWithProducts(user, shop);

            try
            {
                _context.RustCategories.AddRange(defaultData?.Item1);
                _context.RustUserItems.AddRange(defaultData?.Item2);

                await _context.SaveChangesAsync();

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    user.UserName,
                    user.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Default categories and products have been successfully installed. ShopId: {shop.Id}");

                return true;
            }
            catch(Exception e)
            {
                _logger.LogError("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    user.UserName,
                    user.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Error on default categories and products installing. Error message: {e.Message}; Inner exception: {e.InnerException?.Message}; Stacktrace: {e.StackTrace};");
                return false;
            }
        }

        public IEnumerable<RustProduct> GetAllAssignedProductsToAShopByShopId(Guid shopId)
        {
            return _context.RustUserItems
                .Include(x => x.Shop)
                .Include(x => x.AppUser)
                .Include(x => x.RustItem)
                .Include(x => x.RustCategory)
                .Where(x => x.Shop.Id == shopId)
                .OrderBy(x => x.Index);
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
                _context.RustUserItems.FirstOrDefault(x => x.Id == Guid.Parse(model.RustProductEditViewModel.Id));

            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            if (shop is null || product is null)
                return RustEditProductResult.NotFound;

            if (!model.RustProductEditViewModel.ShowInShop)
            {
                product.ShowInShop = false;

                _context.RustUserItems.Update(product);
                await _context.SaveChangesAsync();

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    userForLog.UserName,
                    userForLog.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Rust product was successfully updated. ProductId: {product.Id}");

                return RustEditProductResult.Success;
            }

            product.ShowInShop = true;
            product.Name = model.RustProductEditViewModel.Name;
            product.Description = model.RustProductEditViewModel.Description;
            product.Price = model.RustProductEditViewModel.Price;
            product.Discount = model.RustProductEditViewModel.Discount;
            product.Amount = model.RustProductEditViewModel.Amount;
            product.Index = model.RustProductEditViewModel.Index;

            if (model.RustProductEditViewModel.BlockedTill != null)
            {
                var dateFromModel = model.RustProductEditViewModel.BlockedTill.Split('/');
                var blockedTillDate = new DateTime(int.Parse(dateFromModel[2]), int.Parse(dateFromModel[0]), int.Parse(dateFromModel[1]));

                long blockedTillTicks = blockedTillDate.Ticks;
                long currentMoment = DateTime.Now.Ticks;

                if (blockedTillTicks - currentMoment < 1)
                    return RustEditProductResult.DateHaveToBeBiggerThanCurrentMoment;

                product.BlockedTill = blockedTillDate;
            }

            if (model.RustProductEditViewModel.NewCategoryId != null)
                product.RustCategory = GetCategoryById(Guid.Parse(model.RustProductEditViewModel.NewCategoryId));

            _context.RustUserItems.Update(product);
            await _context.SaveChangesAsync();

            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"Rust product was successfully updated. ProductId: {product.Id}");

            return RustEditProductResult.Success;
        }

        #endregion

        #region Private methods
        private async Task RemoveAllCategoriesAndItemsInShopAsync(Domain.Entries.Shop.Shop shop)
        {
            _context.RustCategories.RemoveRange(_context.RustCategories.Where(x => x.Shop.Id == shop.Id));
            await _context.SaveChangesAsync();

            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"All categories and products was removed. shopId: {shop.Id}");
        }

        private Domain.Entries.Shop.Shop GetShopById(Guid shopId) => _context.Shops.FirstOrDefault(x => x.Id == shopId);

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
        #endregion
    }
}
