using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Enums.RustStore;
using EasyShop.Domain.ViewModels.RustStore.Store.Order;
using EasyShop.Domain.ViewModels.RustStore.Store.Purchase;
using EasyShop.Interfaces.Services.Rust.StandardProductPurchase;
using EasyShop.Services.Mappers.ViewModels.Rust;
using Microsoft.AspNetCore.Mvc;

namespace Rust.MultiTenant.Shop.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IRustStoreStandardProductPurchaseService _rustStoreStandardProductPurchaseService;

        public PurchaseController(IRustStoreStandardProductPurchaseService rustStoreStandardProductPurchaseService)
        {
            _rustStoreStandardProductPurchaseService = rustStoreStandardProductPurchaseService;
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
    }
}