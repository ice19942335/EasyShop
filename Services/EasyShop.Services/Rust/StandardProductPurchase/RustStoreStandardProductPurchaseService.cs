using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace EasyShop.Services.Rust.StandardProductPurchase
{
    public class RustStoreStandardProductPurchaseService : IRustStoreStandardProductPurchaseService
    {
        private readonly ISteamUserService _steamUserService;
        private readonly EasyShopContext _easyShopContext;
        private readonly IRustShopService _rustShopService;
        private readonly UserManager<AppUser> _userManager;

        public RustStoreStandardProductPurchaseService(
            ISteamUserService steamUserService, 
            EasyShopContext easyShopContext,
            IRustShopService rustShopService,
            UserManager<AppUser> userManager)
        {
            _steamUserService = steamUserService;
            _easyShopContext = easyShopContext;
            _rustShopService = rustShopService;
            _userManager = userManager;
        }

        public async Task<RustStorePurchaseStandardProductResultDto> TryPurchaseAsync(RustStoreStandardItemOrder model)
        {
            var steamUser = _steamUserService.GetCurrentRequestSteamUser();
            var steamUserShop = _steamUserService.GetCurrentRequestSteamUserShop();
            var currentShop = _rustShopService.GetCurrentRequestShop();
            var currentUserShop = _easyShopContext.UserShops.First(x => x.ShopId == currentShop.Id);
            var currentShopOwner = await _userManager.FindByIdAsync(currentUserShop.AppUserId);

            var rustUserItem = _easyShopContext.RustUserItems
                .Include(x => x.RustItem)
                .FirstOrDefault(x => x.Id == Guid.Parse(model.ItemId));

            if (rustUserItem is null)
                return new RustStorePurchaseStandardProductResultDto()
                {
                    Status = RustStorePurchaseProductResultEnum.Failed,
                    ErrorMessage = "Item not found"
                };

            //Price calculation
            decimal actualPrice;
            if (rustUserItem.Discount > 0)
                actualPrice = rustUserItem.Price - (rustUserItem.Price / 100) * rustUserItem.Discount;
            else
                actualPrice = rustUserItem.Price;

            actualPrice *= model.Amount;

            //Check balance have enough money
            if (steamUserShop.Balance < actualPrice)
                return new RustStorePurchaseStandardProductResultDto()
                {
                    Status = RustStorePurchaseProductResultEnum.Failed,
                    ErrorMessage = "Sorry, your balance is too low for this item please Top-Up balance and try again."
                };

            //SteamUserShop
            steamUserShop.Balance -= actualPrice;
            steamUserShop.TotalSpent += actualPrice;
            _easyShopContext.SteamUsersShops.Update(steamUserShop);

            //SteamUser
            steamUser.TotalSpent += actualPrice;
            _easyShopContext.SteamUsers.Update(steamUser);

            //RustPurchasedItem
            Guid rustPurchasedItemId;
            do
            {
                rustPurchasedItemId = Guid.NewGuid();
            } while (_easyShopContext.RustPurchasedItems.FirstOrDefault(x => x.Id == rustPurchasedItemId) != null);

            //Creating DB entry RustPurchasedItem
            var newRustPurchasedItem = new RustPurchasedItem
            {
                Id = rustPurchasedItemId,
                SteamUser = steamUser,
                RustItem = rustUserItem.RustItem,
                HasBeenUsed = false,
                AmountLeft = model.Amount,
                AmountOnPurchase = model.Amount,
                ItemsPerStack = rustUserItem.ItemsPerStack,
                PurchaseDateTime = DateTime.Now,
                TotalPaid = actualPrice
            };
            _easyShopContext.RustPurchasedItems.Add(newRustPurchasedItem);

            //Creating DB entry RustPurchaseStats
            Guid rustPurchasedStatsId;
            do
            {
                rustPurchasedStatsId = Guid.NewGuid();
            } while (_easyShopContext.RustPurchaseStats.FirstOrDefault(x => x.Id == rustPurchasedStatsId) != null);

            var newRustPurchaseStats = new RustPurchaseStats
            {
                Id = rustPurchasedStatsId,
                AppUser = currentShopOwner,
                RustPurchasedItem = newRustPurchasedItem,
                Shop = currentShop
            };
            _easyShopContext.RustPurchaseStats.Add(newRustPurchaseStats);

            //Saving purchase
            try
            {
                await _easyShopContext.SaveChangesAsync();

                return new RustStorePurchaseStandardProductResultDto()
                {
                    Status = RustStorePurchaseProductResultEnum.Success,
                    RustProduct = rustUserItem
                };
            }
            catch (Exception e)
            {
                return new RustStorePurchaseStandardProductResultDto()
                {
                    Status = RustStorePurchaseProductResultEnum.Failed,
                    ErrorMessage = "Please contact support!"
                };
            }
        }
    }
}
