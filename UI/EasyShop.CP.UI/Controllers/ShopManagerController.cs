using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;
using EasyShop.Interfaces.Services.CP.Shop;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> CreateShop() => View(new CreateShopViewModel());

        [HttpPost]
        public async Task<IActionResult> CreateShop(CreateShopViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _shopManager.CreateShopAsync(model);

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel", new { reason = "on shop creating" });

            return RedirectToAction("Index", "ShopManager");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteShop(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> EditShopHandler(Guid shopId)
        {
            var gameType = await _shopManager.GetShopByIdAsync(shopId);

            switch (gameType.GameType.Type)
            {
                case "Rust": return RedirectToAction("EditShop", "RustShop");
                default: return RedirectToAction("NotFoundPage", "Home");
            }
        }
    }
}