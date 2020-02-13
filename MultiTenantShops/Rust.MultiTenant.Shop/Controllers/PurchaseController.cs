using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Enums.RustStore;
using EasyShop.Domain.ViewModels.RustStore.Store.Order;
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

                if (purchaseResult.Status == RustStorePurchaseProductResultEnum.Failed)
                    return RedirectToAction("PurchaseFailed", "Purchase", new { message = purchaseResult.ErrorMessage });

                return View("PurchaseSuccess", purchaseResult.RustProduct);
            }

            return RedirectToAction("UserHaveToBeLoggedIn", "Authentication");
        }

        public IActionResult PurchaseSuccess() => View();

        public IActionResult PurchaseFailed(string message) => View("PurchaseFailed", message);
    }
}