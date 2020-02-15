using System;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Dto.RustStore;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Enums.RustStore;
using EasyShop.Domain.ViewModels.RustStore.Store.Order;
using EasyShop.Interfaces.Services.Rust;
using EasyShop.Interfaces.Services.Rust.StandardProductPurchase;
using EasyShop.Interfaces.SteamUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EasyShop.Services.Rust.Purchase.StandardItem
{
    public class RustStoreStandardProductPurchaseService : IRustStoreStandardProductPurchaseService
    {
        private readonly ISteamUserService _steamUserService;
        private readonly EasyShopContext _easyShopContext;
        private readonly IRustShopService _rustShopService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RustStoreStandardProductPurchaseService> _logger;

        public RustStoreStandardProductPurchaseService(
            ISteamUserService steamUserService,
            EasyShopContext easyShopContext,
            IRustShopService rustShopService,
            UserManager<AppUser> userManager,
            ILogger<RustStoreStandardProductPurchaseService> logger)
        {
            _steamUserService = steamUserService;
            _easyShopContext = easyShopContext;
            _rustShopService = rustShopService;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<RustStorePurchaseStandardProductResultDto> TryPurchaseAsync(RustStoreStandardItemOrder model)
        {
            #region Data preparation

            var steamUser = _steamUserService.GetCurrentRequestSteamUser();
            var steamUserShop = _steamUserService.GetCurrentRequestSteamUserShop();
            var currentShop = _rustShopService.GetCurrentRequestShop();
            var currentUserShop = _easyShopContext.UserShops.FirstOrDefault(x => x.ShopId == currentShop.Id);
            var appUser = await _userManager.FindByIdAsync(currentUserShop?.AppUserId);
            var rustUserItem = _easyShopContext.RustUserItems
                .Include(x => x.RustItem)
                .FirstOrDefault(x => x.Id == Guid.Parse(model.ItemId));

            #endregion Data preparation

            #region Check data, continue or return

            var errorId = Guid.NewGuid();

            if (rustUserItem is null || appUser is null || currentUserShop is null || currentShop is null || steamUserShop is null || steamUser is null)
            {
                var error = new
                {
                    ErrorId = errorId,
                    rustUserItem = rustUserItem?.Id,
                    currentShopOwner = appUser?.Id,
                    currentShop = currentShop?.Id,
                    ErrosteamUserrId = steamUser?.Id,
                    currentUserShop_AppUserId = currentUserShop?.AppUserId,
                    currentUserShop_ShopId = currentUserShop?.ShopId,
                    steamUserShop_SteamUserId = steamUserShop?.SteamUserId,
                    steamUserShop_ShopId = steamUserShop?.ShopId,
                };

                _logger.LogError($"Purchase data preparation ErrorID: {errorId}\nVariables:\n{JsonConvert.SerializeObject(error, Formatting.Indented)}");

                return new RustStorePurchaseStandardProductResultDto()
                {
                    Status = RustStorePurchaseProductResultEnum.ContactSupport,
                    ErrorMessage = $"Please contact support and give them this id '{errorId}'"
                };
            }

            #endregion Check data, continue or return

            #region Price calculation 

            decimal actualPrice;
            if (rustUserItem.Discount > 0)
                actualPrice = rustUserItem.Price - (rustUserItem.Price / 100) * rustUserItem.Discount;
            else
                actualPrice = rustUserItem.Price;

            actualPrice *= model.Amount;

            #endregion Price calculation 

            #region Check balance have enough money, if not return

            if (steamUserShop.Balance < actualPrice)
            {
                var balanceTooLow = new
                {
                    SteamUserId = steamUser.Id,
                    ShopId = currentShop.Id,
                    UserBalanceInShop = steamUserShop.Balance,
                    OrderPrice = actualPrice,
                    AmountOfItemsInOrder = model.Amount,
                    SingleItemPrice = rustUserItem.Price - (rustUserItem.Price / 100) * rustUserItem.Discount
                };

                _logger.LogInformation($"Balance too low:\n{JsonConvert.SerializeObject(balanceTooLow, Formatting.Indented)}");

                return new RustStorePurchaseStandardProductResultDto()
                {
                    Status = RustStorePurchaseProductResultEnum.Failed,
                    ErrorMessage = "Sorry, your balance is too low for this item please Top-Up balance and try again."
                };
            }
                

            #endregion Check balance have enough money, if not return

            #region SteamUserShop updating entry values

            steamUserShop.Balance -= actualPrice;
            steamUserShop.TotalSpent += actualPrice;
            _easyShopContext.SteamUsersShops.Update(steamUserShop);

            #endregion SteamUserShop updating entry values

            #region SteamUser updating entry values

            steamUser.TotalSpent += actualPrice;
            _easyShopContext.SteamUsers.Update(steamUser);

            #endregion SteamUser updating entry values

            #region Creating entry RustPurchasedItems

            Guid rustPurchasedItemId;
            do
            {
                rustPurchasedItemId = Guid.NewGuid();
            } while (_easyShopContext.RustPurchasedItems.FirstOrDefault(x => x.Id == rustPurchasedItemId) != null);

            var newRustPurchasedItem = new RustPurchasedItem
            {
                Id = rustPurchasedItemId,
                SteamUser = steamUser,
                RustItem = rustUserItem.RustItem,
                AmountLeft = model.Amount,
                AmountOnPurchase = model.Amount,
                ItemsPerStack = rustUserItem.ItemsPerStack,
                PurchaseDateTime = DateTime.Now,
                TotalPaid = actualPrice
            };
            _easyShopContext.RustPurchasedItems.Add(newRustPurchasedItem);

            #endregion Creating entry RustPurchasedItems

            #region Creating entry RustPurchaseStats

            Guid rustPurchasedStatsId;
            do
            {
                rustPurchasedStatsId = Guid.NewGuid();
            } while (_easyShopContext.RustPurchaseStats.FirstOrDefault(x => x.Id == rustPurchasedStatsId) != null);

            var newRustPurchaseStats = new RustPurchaseStats
            {
                Id = rustPurchasedStatsId,
                AppUser = appUser,
                RustPurchasedItem = newRustPurchasedItem,
                Shop = currentShop
            };
            _easyShopContext.RustPurchaseStats.Add(newRustPurchaseStats);

            #endregion Creating entry RustPurchaseStats

            #region Try to save data into DB. Return on error

            try
            {
                await _easyShopContext.SaveChangesAsync();

                var purchaseSuccessDetails = new
                {
                    SteamUserId = steamUser.Id,
                    RustPurchasedItemId = rustPurchasedItemId,
                    RustPurchasedStatsId = rustPurchasedStatsId
                };

                _logger.LogInformation($"Purchase success:\n{JsonConvert.SerializeObject(purchaseSuccessDetails, Formatting.Indented)}");

                return new RustStorePurchaseStandardProductResultDto()
                {
                    Status = RustStorePurchaseProductResultEnum.Success,
                    RustProduct = rustUserItem
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error on purchase:\n");
                return new RustStorePurchaseStandardProductResultDto()
                {
                    Status = RustStorePurchaseProductResultEnum.Failed,
                    ErrorMessage = "Please contact support!"
                };
            }

            #endregion Try to save data into DB. Return on error
        }
    }
}
