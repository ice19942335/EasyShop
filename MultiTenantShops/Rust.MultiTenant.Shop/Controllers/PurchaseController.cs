using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Enums.RustStore;
using EasyShop.Domain.ViewModels.RustStore.Store.Order;
using EasyShop.Domain.ViewModels.RustStore.Store.Purchase;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Interfaces.Services.Rust;
using EasyShop.Interfaces.Services.Rust.StandardProductPurchase;
using EasyShop.Interfaces.SqlServices.Rust.Stats;
using EasyShop.Interfaces.SteamUsers;
using EasyShop.Services.Mappers.ViewModels.Rust;
using Microsoft.AspNetCore.Mvc;

namespace Rust.MultiTenant.Shop.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IRustStoreStandardProductPurchaseService _rustStoreStandardProductPurchaseService;
        private readonly IRustPurchaseStatsServiceSql _rustPurchaseStatsServiceSql;
        private readonly IRustShopService _rustShopService;
        private readonly ISteamUserService _steamUserService;

        public PurchaseController(
            IRustStoreStandardProductPurchaseService rustStoreStandardProductPurchaseService,
            IRustPurchaseStatsServiceSql rustPurchaseStatsServiceSql,
            IRustShopService rustShopService,
            ISteamUserService steamUserService)
        {
            _rustStoreStandardProductPurchaseService = rustStoreStandardProductPurchaseService;
            _rustPurchaseStatsServiceSql = rustPurchaseStatsServiceSql;
            _rustShopService = rustShopService;
            _steamUserService = steamUserService;
        }

        [HttpPost]
        public async Task<IActionResult> RustStandardItem([FromForm] RustStoreStandardItemOrder model)
        {
            if (User.Identity.IsAuthenticated)
            {
                var purchaseResult = await _rustStoreStandardProductPurchaseService.TryPurchaseAsync(model);

                if (purchaseResult.Status == RustStorePurchaseProductResultEnum.ContactSupport)
                    return RedirectToAction("PurchaseFailed", "Purchase", new { message = purchaseResult.ErrorMessage, contactSupport = true });

                if (purchaseResult.Status == RustStorePurchaseProductResultEnum.Failed)
                    return RedirectToAction("PurchaseFailed", "Purchase", new { message = purchaseResult.ErrorMessage });

                return RedirectToAction("PurchaseSuccess", "Purchase", new { imgUrl = purchaseResult.RustProduct.RustItem.ImgUrl });
            }

            return RedirectToAction("UserHaveToBeLoggedIn", "Authentication");
        }

        public IActionResult PurchaseSuccess(string imgUrl) => View("PurchaseSuccess", imgUrl);

        public IActionResult PurchaseFailed(string message, bool contactSupport = false) 
            => View("PurchaseFailed", new RustStorePurchaseFailedViewModel { ErrorMessage = message, ContactSupport = contactSupport});

        public IActionResult History()
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentShop = _rustShopService.GetCurrentRequestShopInRustStore();
                var steamUser = _steamUserService.GetCurrentRequestSteamUser();

                var model = new RustStorePurchaseHistoryViewModel()
                {
                    PurchasedProducts = _rustPurchaseStatsServiceSql.GetAllByShopIdAndSteamUserId(currentShop.Id, steamUser.Id)
                        .Select(x => new RustPurchasedProductViewModel
                        {
                            Name = x.RustPurchasedItem.RustItem.Name,
                            ImgUrl = x.RustPurchasedItem.RustItem.ImgUrl,
                            PaidTotal = x.RustPurchasedItem.TotalPaid,
                            AmountOnPurchase = x.RustPurchasedItem.AmountOnPurchase,
                            AmountLeft = x.RustPurchasedItem.AmountLeft,
                            PurchaseDateTime = x.RustPurchasedItem.PurchaseDateTime
                        })
                };

                return View(model);
            }

            return RedirectToAction("UserHaveToBeLoggedIn", "Authentication");
        }
    }
}