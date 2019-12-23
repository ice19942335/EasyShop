using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.StaticEntities.GameTypes;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;
using EasyShop.Interfaces.Services.CP.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class ShopManagerController : Controller
    {
        private readonly IShopManager _shopManager;

        public ShopManagerController(IShopManager shopManager)
        {
            _shopManager = shopManager;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.Name is null)
                return RedirectToAction("Login", "Account");

            var userShops = await _shopManager.UserShopsByUserEmailAsync(User.Identity.Name);

            var model = new ShopManagerViewModel { Shops = userShops };

            return View(model);
        }

        public async Task<IActionResult> CreateShop() => View(new CreateShopViewModel());

        [HttpPost]
        public async Task<IActionResult> CreateShop(CreateShopViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            var result = await _shopManager.CreateShopAsync(model);

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel", new { reason = "on shop creating" });

            return RedirectToAction("Index", "ShopManager");
        }

        [HttpGet("{shopId}")]
        public async Task<IActionResult> DeleteShop(string shopId)
        {
            var result = await _shopManager.DeleteShopAsync(Guid.Parse(shopId));

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditShopHandler(string shopId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            switch (shop.GameType.Type)
            {
                case DefaultGameTypes.GameRust: return RedirectToAction("Index", "RustShop", new { shopId = shopId });
                default: return RedirectToAction("NotFoundPage", "Home");
            }
        }

        public async Task<IActionResult> NewSecret(string shopId)
        {
            var result = await _shopManager.NewSecretAsync(Guid.Parse(shopId));

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            return RedirectToAction("MainSettings", "RustShop", new { shopId = shopId });
        }
    }
}