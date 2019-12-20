using System;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.Shop.Rust;
using EasyShop.Interfaces.Services.CP.Shop;
using EasyShop.Interfaces.Services.CP.Shop.Rust;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class RustShopController : Controller
    {
        private readonly IShopManager _shopManager;
        private readonly IRustShopService _rustShopService;

        public RustShopController(IShopManager shopManager, IRustShopService rustShopService)
        {
            _shopManager = shopManager;
            _rustShopService = rustShopService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string shopId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = new RustShopViewModel
            {
                RustShopStatsViewModel = new RustShopStatsViewModel
                {
                    Id = shop.Id,
                    ShopName = shop.ShopName,
                    ShopTitle = shop.ShopTitle,
                    ShopLink = shop.ShopTitle + shop.Id
                },
                EditMainSettingsRustShopViewModel = new EditMainSettingsRustShopViewModel
                {
                    Id = shop.Id,
                    ShopName = shop.ShopName,
                    ShopTitle = shop.ShopTitle,
                    StartBalance = shop.StartBalance,
                }
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditMainSettings(string shopId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = new RustShopViewModel
            {
                RustShopStatsViewModel = new RustShopStatsViewModel
                {
                    Id = shop.Id,
                    ShopName = shop.ShopName,
                    ShopTitle = shop.ShopTitle,
                    ShopLink = "http://www.site.birula.com/monetization/" + shop.ShopTitle
                },
                EditMainSettingsRustShopViewModel = new EditMainSettingsRustShopViewModel
                {
                    Id = shop.Id,
                    ShopName = shop.ShopName,
                    ShopTitle = shop.ShopTitle,
                    StartBalance = shop.StartBalance,
                }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditMainSettings(RustShopViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            var result = await _rustShopService.UpdateShopAsync(model.EditMainSettingsRustShopViewModel);

            if (result is null)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            model.EditMainSettingsRustShopViewModel = result;
            model.RustShopStatsViewModel = new RustShopStatsViewModel
            {
                Id = result.Id,
                ShopName = result.ShopName,
                ShopTitle = result.ShopTitle,
                ShopLink = result.ShopTitle + result.Id
            };
            return View(model);
        }
    }
}