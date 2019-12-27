using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.Enums;
using EasyShop.Domain.Enums.Rust;
using EasyShop.Domain.StaticEntities.GameTypes;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;
using EasyShop.Interfaces.Services.CP.Shop;
using EasyShop.Interfaces.Services.CP.Shop.Rust;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class ShopManagerController : Controller
    {
        private readonly IShopManager _shopManager;
        private readonly IRustShopService _rustShopService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public ShopManagerController(IShopManager shopManager, IRustShopService rustShopService, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _shopManager = shopManager;
            _rustShopService = rustShopService;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IActionResult> ShopsManager()
        {
            if (User.Identity.Name is null)
                return RedirectToAction("Login", "Account");

            var userShops = await _shopManager.UserShopsByUserEmailAsync(User.Identity.Name);

            var model = new ShopsManagerViewModel { Shops = userShops };

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

            RustCreateShopResult result = default;
            switch (model.GameType)
            {
                case "Rust":
                    result = await _rustShopService.CreateShopAsync(model);
                    break;
            }

            if (result == RustCreateShopResult.Success)
            {
                return RedirectToAction("ShopsManager", "ShopManager");
            }
            else if (result == RustCreateShopResult.MaxShopLimitIsReached)
            {
                return View("AllowedShopsLimitIsReached");
            }
            else if (result == RustCreateShopResult.SomethingWentWrong)
            {
                return RedirectToAction("SomethingWentWrong", "ControlPanel", new { reason = "on shop creating" });
            }
            else
            {
                return RedirectToAction("SomethingWentWrong", "ControlPanel", new { reason = "on shop creating" });
            }
        }

        [HttpGet("{shopId}")]
        public async Task<IActionResult> DeleteShop(string shopId)
        {
            bool result = default;

            string gameType = _shopManager.GetShopGameTypeById(Guid.Parse(shopId));

            switch (gameType)
            {
                case "Rust":
                    result = await _rustShopService.DeleteShopAsync(Guid.Parse(shopId));
                    break;
                default: throw new ApplicationException($"Game type <{gameType}> not exist!");
            }

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            return RedirectToAction("ShopsManager");
        }

        public async Task<IActionResult> EditShopHandler(string shopId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            switch (shop.GameType.Type)
            {
                case DefaultGameTypes.GameRust: return RedirectToAction("ShopStats", "RustShop", new { shopId = shopId });
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