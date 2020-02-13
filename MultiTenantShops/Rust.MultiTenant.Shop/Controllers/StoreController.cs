using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OpenId.Steam;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.RustStore.Store;
using EasyShop.Domain.ViewModels.RustStore.Store.Profile;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Interfaces.Services.Rust;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rust.MultiTenant.Shop.Controllers
{
    public class StoreController : Controller
    {
        private readonly ILogger<StoreController> _logger;
        private readonly IRustShopService _rustShopService;
        private readonly EasyShopContext _easyShopContext;

        public StoreController(ILogger<StoreController> logger, IRustShopService rustShopService, EasyShopContext easyShopContext)
        {
            _logger = logger;
            _rustShopService = rustShopService;
            _easyShopContext = easyShopContext;
        }

        public async Task<IActionResult> Store()
        {
            string tenantId;

            try
            {
                tenantId = HttpContext.GetMultiTenantContext().TenantInfo.Id;
            }
            catch
            {
                return RedirectToAction("Error404", "Error");
            }

            var shopProducts = await _rustShopService.GetAllAssignedVisibleProductsToAShopByShopIdAsync(Guid.Parse(tenantId));
            var shopCategories = _rustShopService.GetAllAssignedCategoriesToShopByShopId(Guid.Parse(tenantId));
            var shop = _rustShopService.GetShopById(Guid.Parse(tenantId));

            var model = new RustStoreViewModel
            {
                ShopName = shop.ShopName,
                Products = shopProducts.Select(x => new RustStoreProductViewModel
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    Price = x.Price,
                    Discount = x.Discount,
                    BlockedTill = x.BlockedTill,
                    ImgUrl = x.RustItem.ImgUrl,
                    ItemsPerStack = x.ItemsPerStack,
                    Description = x.Description,
                    CategoryId = x.RustCategory.Id,
                    CategoryName = x.RustCategory.Name,
                    Type = x.RustItem.RustItemType.TypeName,
                    PriceAfterDiscount = x.Price - (x.Price / 100) * x.Discount
                }),
                ProductCategories = shopCategories.ToDictionary(
                    x => x.Id.ToString(), 
                    x => x.Name,
                    StringComparer.OrdinalIgnoreCase)
            };

            return View(model);
        }
    }
}