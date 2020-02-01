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
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rust.MultiTenant.Shop.Controllers
{
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRustShopService _rustShopService;
        private readonly EasyShopContext _easyShopContext;

        public HomeController(ILogger<HomeController> logger, IRustShopService rustShopService, EasyShopContext easyShopContext)
        {
            _logger = logger;
            _rustShopService = rustShopService;
            _easyShopContext = easyShopContext;
        }

        //[AllowAnonymous]
        public IActionResult Store()
        {
            var tenantId = HttpContext.GetMultiTenantContext().TenantInfo.Id;
            var shopProducts = _rustShopService.GetAllAssignedVisibleProductsToAShopByShopId(Guid.Parse(tenantId));
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

        public IActionResult Profile()
        {
            if (User.Identity.IsAuthenticated)
            {
                var tenantInfo = HttpContext.GetMultiTenantContext().TenantInfo;
                var userClaims = User.Claims.ToList();

                var userName = userClaims.First(x => x.Type == ClaimTypes.Name).Value;
                var uid = userClaims.First(xx => xx.Type == SteamAuthenticationConstants.Parameters.UserUid).Value;
                var avatar = userClaims.First(x => x.Type == SteamAuthenticationConstants.Parameters.AvatarFull).Value;

                var steamUser = _easyShopContext.SteamUsers.First(x => x.Uid == uid);
                var userShop = _easyShopContext.SteamUsersShops.First(x =>
                    x.ShopId == Guid.Parse(tenantInfo.Id) && x.SteamUserId == steamUser.Id);

                var model = new RustStoreSteamUserViewModel
                {
                    UserName = userName,
                    ImgUrl = avatar,
                    Uid = uid,
                    Balance = userShop.Balance
                };

                return View(model);
            }

            return View("UserHaveToBeLoggedIn");
        }

        public IActionResult UserHaveToBeLoggedIn() => View();
    }
}