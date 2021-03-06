﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.Enums.CP.Rust;
using EasyShop.Domain.ViewModels.ControlPanel.Rust.Shop;
using EasyShop.Domain.ViewModels.ControlPanel.Shop;
using EasyShop.Interfaces.Services.CP.Rust.Data;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Interfaces.Services.MultiTenancy;
using EasyShop.Interfaces.Services.Rust;
using EasyShop.Services.ExtensionMethods;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Guid = System.Guid;

namespace EasyShop.Services.Rust
{
    public class RustShopService : IRustShopService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly EasyShopContext _easyShopContext;
        private readonly ILogger<RustShopService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRustDefaultCategoriesWithItemsService _rustDefaultCategoriesWithItemsService;
        private readonly IMultiTenancyStoreService _tenancyStoreService;

        public RustShopService(
            IConfiguration configuration,
            UserManager<AppUser> userManager,
            EasyShopContext easyShopContext,
            ILogger<RustShopService> logger,
            IHttpContextAccessor httpContextAccessor,
            IRustDefaultCategoriesWithItemsService rustDefaultCategoriesWithItemsService,
            IMultiTenancyStoreService tenancyStoreService
            )
        {
            _configuration = configuration;
            _userManager = userManager;
            _easyShopContext = easyShopContext;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _rustDefaultCategoriesWithItemsService = rustDefaultCategoriesWithItemsService;
            _tenancyStoreService = tenancyStoreService;
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
                do { secret = Guid.NewGuid(); } while (_easyShopContext.Shops.FirstOrDefault(x => x.Secret == secret) != null);

                var gameType = _easyShopContext.GameTypes.First(x => x.Type == model.GameType);

                Guid newShopId;
                do { newShopId = Guid.NewGuid(); } while (_easyShopContext.UserShops.FirstOrDefault(x => x.ShopId == newShopId) != null);

                var newShop = new Shop
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
                    AppUser = user,
                };

                var addNewTenant = await _tenancyStoreService.TryAddAsync(
                    newShopId.ToString(),
                    newShopId.ToString(),
                    model.ShopName,
                    null);

                if (!addNewTenant)
                    return RustCreateShopResult.SomethingWentWrong;

                _easyShopContext.Shops.Add(newShop);
                _easyShopContext.UserShops.Add(userShop);
                await _easyShopContext.SaveChangesAsync();

                if (model.AddDefaultItems)
                {
                    try
                    {
                        await SetDefaultProductsAsync(user, newShop);
                        await _easyShopContext.SaveChangesAsync();

                        _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                            user.UserName,
                            user.Id,
                            _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                            $"Rust shop has been successfully created! ShopId: {newShopId}");

                        return RustCreateShopResult.Success;
                    }
                    catch(Exception e)
                    {
                        _easyShopContext.Shops.Remove(newShop);
                        _easyShopContext.UserShops.Remove(userShop);
                        await RemoveAllCategoriesAndItemsInShopAsync(newShop);
                        await _easyShopContext.SaveChangesAsync();

                        _logger.LogError("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                            user.UserName,
                            user.Id,
                            _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                            $"Error on adding default products and categories. Error message: {e.Message}; Inner exception: {e.InnerException?.Message}; Stacktrace: {e.StackTrace};");

                        return RustCreateShopResult.SomethingWentWrong;
                    }
                }

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    user.UserName,
                    user.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Rust shop has been successfully created! ShopId: {newShop.Id}");

                return RustCreateShopResult.Success;
            }

            return RustCreateShopResult.MaxShopLimitIsReached;
        }

        public async Task<Shop> UpdateShopAsync(RustShopEditMainSettingsViewModel model)
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
                _easyShopContext.Shops.Update(shop);
                await _easyShopContext.SaveChangesAsync();

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    userForLog.UserName,
                    userForLog.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Shop has been successfully updated! ShopId: {shop.Id}");

                return shop;
            }
            catch (Exception e)
            {
                _logger.LogError("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    userForLog.UserName,
                    userForLog.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Error on updating shop. Error message: {e.Message}; Inner exception: {e.InnerException?.Message}; Stacktrace: {e.StackTrace};");

                return null;
            }
        }

        public async Task<bool> DeleteShopAsync(Guid shopId)
        {
            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            var userShop = _easyShopContext.UserShops.FirstOrDefault(x => x.ShopId == shopId);
            var shop = GetShopById(shopId);

            if (userShop is null || shop is null)
                return false;

            var allAssignedCategoriesToShop = GetAllAssignedCategoriesToShopByShopId(shopId);

            var removeTenant = await _tenancyStoreService.RemoveAsync(shop.Id.ToString());

            if (!removeTenant)
            {
                _logger.LogError("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    userForLog.UserName,
                    userForLog.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    "Error on shop deletion. Cannot delete tenant from store");

                return false;
            }
            
            _easyShopContext.RustCategories.RemoveRange(allAssignedCategoriesToShop);
            await _easyShopContext.SaveChangesAsync();

            _easyShopContext.UserShops.Remove(userShop);
            _easyShopContext.Shops.Remove(shop);

            await _easyShopContext.SaveChangesAsync();

            
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"Shop was successfully deleted. ShopId: {shop.Id}");

            return true;
        }

        public Shop GetShopById(Guid shopId) => _easyShopContext.Shops.FirstOrDefault(x => x.Id == shopId);

        public Shop GetCurrentRequestShopInRustStore()
        {
            var tenantInfo = _httpContextAccessor.HttpContext.GetMultiTenantContext().TenantInfo;

            return _easyShopContext.Shops.First(x => x.Id == Guid.Parse(tenantInfo.Id));
        }

        #endregion

        #region Rust Categories
        public IEnumerable<RustCategory> GetAllAssignedCategoriesToShopByShopId(Guid shopId)
        {
            var categories = _easyShopContext.RustCategories
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

                _easyShopContext.RustCategories.Add(newCategory);
                await _easyShopContext.SaveChangesAsync();

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    userForLog.UserName,
                    userForLog.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Description was successfully created. CategoryId: {newCategory.Id}");

                return (newCategory, RustEditCategoryResult.Created);
            }

            var category = GetCategoryById(Guid.Parse(model.RustCategoryEditViewModel.Category.Id));

            if (category is null)
                return (null, RustEditCategoryResult.Failed);

            category.Index = model.RustCategoryEditViewModel.Category.Index;
            category.Name = model.RustCategoryEditViewModel.Category.Name;

            _easyShopContext.RustCategories.Update(category);
            await _easyShopContext.SaveChangesAsync();

            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"Description was successfully updated. CategoryId: {category.Id}");

            return (category, RustEditCategoryResult.Success);
        }

        public RustCategory GetCategoryById(Guid categoryId) => _easyShopContext.RustCategories
            .Include(x => x.AppUser).Include(x => x.Shop).FirstOrDefault(x => x.Id == categoryId);

        public async Task<bool> DeleteCategory(Guid categoryId)
        {
            var category = _easyShopContext.RustCategories.FirstOrDefault(x => x.Id == categoryId);

            if (category is null)
                return false;

            _easyShopContext.RustCategories.Remove(category);
            await _easyShopContext.SaveChangesAsync();

            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"Description was successfully deleted. CategoryId: {category.Id}");

            return true;
        }
        #endregion

        #region Rust Products
        public int GetAssignedUserItemsCountToACategoryInShop(Guid categoryId, Guid shopId)
        {
            var result = _easyShopContext.RustUserItems
                .Include(x => x.Shop)
                .Include(x => x.RustCategory)
                .Where(x => x.RustCategory.Id == categoryId && x.Shop.Id == shopId).ToList().Count;

            return result;
        }

        public (List<RustCategory>, List<RustProduct>) GetDefaultCategoriesWithProducts(AppUser user, Shop shop)
        {
            var defaultCategories = _easyShopContext.RustCategories.Include(x => x.AppUser).Where(x => x.AppUser == null).ToList();
            var rustItems = _easyShopContext.RustItems.ToList();

            return _rustDefaultCategoriesWithItemsService.CreateDefaultCategoriesWithItems(user, shop, defaultCategories, rustItems);
        }

        public async Task<bool> SetDefaultProductsAsync(AppUser user, Shop shop)
        {
            await RemoveAllCategoriesAndItemsInShopAsync(shop);
            (List<RustCategory>, List<RustProduct>)? defaultData = GetDefaultCategoriesWithProducts(user, shop);

            try
            {
                _easyShopContext.RustCategories.AddRange(defaultData?.Item1);
                _easyShopContext.RustUserItems.AddRange(defaultData?.Item2);

                await _easyShopContext.SaveChangesAsync();

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    user.UserName,
                    user.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Default categories and products have been successfully installed. ShopId: {shop.Id}");

                return true;
            }
            catch(Exception e)
            {
                _logger.LogError("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    user.UserName,
                    user.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Error on default categories and products installing. Error message: {e.Message}; Inner exception: {e.InnerException?.Message}; Stacktrace: {e.StackTrace};");
                return false;
            }
        }

        public async Task<IEnumerable<RustProduct>> GetAllAssignedProductsToAShopByShopIdAsync(Guid shopId)
        {
            var products = _easyShopContext.RustUserItems
                .Include(x => x.Shop)
                .Include(x => x.AppUser)
                .Include(x => x.RustItem)
                .Include(x => x.RustCategory)
                .Include(x => x.RustItem.RustItemType)
                .Where(x => x.Shop.Id == shopId)
                .OrderBy(x => x.Index)
                .ToList();

            var productsList = new List<RustProduct>();

            foreach (var product in products)
                productsList.Add(await CheckBlockedTillDateAndUpdateAsync(product));

            return productsList.AsEnumerable();
        }

        public async Task<IEnumerable<RustProduct>> GetAllAssignedVisibleProductsToAShopByShopIdAsync(Guid shopId)
        {
            var products = _easyShopContext.RustUserItems
                .Include(x => x.Shop)
                .Include(x => x.AppUser)
                .Include(x => x.RustItem)
                .Include(x => x.RustCategory)
                .Include(x => x.RustItem.RustItemType)
                .Where(x => x.Shop.Id == shopId && x.ShowInShop)
                .OrderBy(x => x.Index)
                .ToList();

            var productsList = new List<RustProduct>();

            foreach (var product in products)
                productsList.Add(await CheckBlockedTillDateAndUpdateAsync(product));

            return productsList.AsEnumerable();
        }

        public async Task<RustProduct> GetProductById(Guid productId)
        {
            var product = _easyShopContext.RustUserItems
                    .Include(x => x.RustCategory)
                    .Include(x => x.RustItem)
                    .FirstOrDefault(x => x.Id == productId);

            if (product is null)
                return null;

            await CheckBlockedTillDateAndUpdateAsync(product);

            return product;
        }

        public async Task<RustEditProductResult> UpdateRustProductAsync(RustShopViewModel model)
        {
            var shop = GetShopById(Guid.Parse(model.Id));
            var product =
                _easyShopContext.RustUserItems.FirstOrDefault(x => x.Id == Guid.Parse(model.RustProductEditViewModel.Id));

            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            if (shop is null || product is null)
                return RustEditProductResult.NotFound;

            if (!model.RustProductEditViewModel.ShowInShop)
            {
                product.ShowInShop = false;

                _easyShopContext.RustUserItems.Update(product);
                await _easyShopContext.SaveChangesAsync();

                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    userForLog.UserName,
                    userForLog.Id,
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Rust product was successfully updated. ItemId: {product.Id}");

                return RustEditProductResult.Success;
            }

            product.ShowInShop = true;
            product.Name = model.RustProductEditViewModel.Name;
            product.Description = model.RustProductEditViewModel.Description;
            product.Price = model.RustProductEditViewModel.Price;
            product.Discount = model.RustProductEditViewModel.Discount;
            product.ItemsPerStack = model.RustProductEditViewModel.Amount;
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

            _easyShopContext.RustUserItems.Update(product);
            await _easyShopContext.SaveChangesAsync();

            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"Rust product was successfully updated. ItemId: {product.Id}");

            return RustEditProductResult.Success;
        }

        #endregion

        #region Private methods
        private async Task RemoveAllCategoriesAndItemsInShopAsync(Shop shop)
        {
            _easyShopContext.RustCategories.RemoveRange(_easyShopContext.RustCategories.Where(x => x.Shop.Id == shop.Id));
            await _easyShopContext.SaveChangesAsync();

            var userForLog = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                $"All categories and products was removed. shopId: {shop.Id}");
        }

        private async Task<IEnumerable<Shop>> UserShopsByUserEmailAsync(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);

            if (user is null)
                return null;

            var query = from userShop in _easyShopContext.UserShops
                join shop in _easyShopContext.Shops on userShop.ShopId equals shop.Id
                where userShop.AppUserId == user.Id
                select new Shop
                {
                    Id = shop.Id,
                    ShopName = shop.ShopName,
                    GameType = _easyShopContext.GameTypes.FirstOrDefault(x => x.Id == shop.GameType.Id),
                    ShopTitle = shop.ShopTitle,
                    StartBalance = shop.StartBalance,
                    Secret = shop.Secret
                };

            var result = query.AsEnumerable();

            return result;
        }

        private async Task<RustProduct> CheckBlockedTillDateAndUpdateAsync(RustProduct product)
        {
            if (product.BlockedTill.Date.Ticks < DateTime.Now.Date.Ticks)
                product.BlockedTill = default;

            _easyShopContext.RustUserItems.Update(product);
            await _easyShopContext.SaveChangesAsync();

            return product;
        }
        #endregion
    }
}
