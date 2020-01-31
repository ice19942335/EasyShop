using System;
using System.Collections.Generic;
using System.Linq;
using EasyShop.Domain.ViewModels.RustStore.Store;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rust.MultiTenant.Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRustShopService _rustShopService;

        public HomeController(ILogger<HomeController> logger, IRustShopService rustShopService)
        {
            _logger = logger;
            _rustShopService = rustShopService;
        }

        public ActionResult Store()
        {
            var tenantId = HttpContext.GetMultiTenantContext().TenantInfo.Id;
            var shopProducts = _rustShopService.GetAllAssignedProductsToAShopByShopId(Guid.Parse(tenantId));
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
                    ItemsInSet = x.Amount,
                    Description = x.Description,
                    CategoryId = x.RustCategory.Id,
                    CategoryName = x.RustCategory.Name,
                    Type = x.RustItem.RustItemType.TypeName
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