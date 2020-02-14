using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Interfaces.Services.Rust;
using EasyShop.Services.Rust;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;

namespace Rust.MultiTenant.Shop.Components
{
    public class TenantNavBarViewComponent : ViewComponent
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRustShopService _rustShopService;

        public TenantNavBarViewComponent(IHttpContextAccessor httpContextAccessor, IRustShopService rustShopService)
        {
            _httpContextAccessor = httpContextAccessor;
            _rustShopService = rustShopService;
        }

        public IViewComponentResult Invoke()
        {
            var tenantInfoIdentifier = _httpContextAccessor.HttpContext.GetMultiTenantContext().TenantInfo.Identifier;

            var shop = _rustShopService.GetShopById(
                Guid.Parse(_httpContextAccessor.HttpContext.GetMultiTenantContext().TenantInfo.Id));
            var shopTitle = shop.ShopTitle;

            return View("TenantNavBar", (tenantInfoIdentifier, shopTitle));
        }
    }
}
