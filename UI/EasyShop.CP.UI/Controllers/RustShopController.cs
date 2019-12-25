using System;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.Shop.Rust;
using EasyShop.Interfaces.Services.CP.Shop;
using EasyShop.Interfaces.Services.CP.Shop.Rust;
using EasyShop.Services.Mappers.ViewModels.Rust;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class RustShopController : Controller
    {
        private readonly IShopManager _shopManager;
        private readonly IRustShopService _rustShopService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RustShopController(IShopManager shopManager, IRustShopService rustShopService, IHttpContextAccessor httpContextAccessor)
        {
            _shopManager = shopManager;
            _rustShopService = rustShopService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> ShopStats(string shopId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = shop.CreateRustShopViewModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MainSettings(string shopId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = shop.CreateRustShopViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MainSettings([FromForm] RustShopViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            var result = await _rustShopService.UpdateShopAsync(model.RustShopMainSettingsViewModel);

            if (result is null)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            model = result.CreateRustShopViewModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CategoriesManager(string shopId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = shop.CreateRustShopViewModel();

            var categories = await _rustShopService.GetAllAssignedItemsToShopByIdAsync(Guid.Parse(shopId));
            var categoriesViewModelListTasks = categories
                .Select(x => x.CreateRustCategoryViewModel(_rustShopService.GetAssignedUserItemsCountToACategoryInShop(x.Id, shop.Id)));

            model.RustShopCategories = new RustShopCategoriesViewModel
            {
                Categories = categoriesViewModelListTasks
            };

            return View(model);
        }

        [HttpGet("CreateCategory/{shopId}")]
        public async Task<IActionResult> CreateCategory(string shopId)
        {
            return RedirectToAction("EditCategory", "RustShop", new {shopId = shopId});
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(string shopId, string categoryId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            var model = shop.CreateRustShopViewModel();

            if (categoryId is null)
            {
                model.RustEditCategoryViewModel = new RustEditCategoryViewModel();
                return View(model);
            }

            var category = _rustShopService.GetCategoryById(Guid.Parse(categoryId));

            model.RustEditCategoryViewModel.Category =
                category.CreateRustCategoryViewModel(_rustShopService.GetAssignedUserItemsCountToACategoryInShop(category.Id, shop.Id));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory([FromForm] RustShopViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            var result = await _rustShopService.UpdateCategoryAsync(model);

            if (result is null)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            return View(model);
        }

        [HttpGet(template: "{shopId}&{categoryId}")]
        public async Task<IActionResult> DeleteCategory(string shopId, string categoryId)
        {
            var result = await _rustShopService.DeleteCategory(Guid.Parse(categoryId));

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));
            var model = shop.CreateRustShopViewModel();

            return RedirectToAction("CategoriesManager", "RustShop", new { shopId = shopId });
        }

        [HttpGet("SetDefaultCategoriesAndProducts/{shopId}")]
        public async Task<IActionResult> SetDefaultCategoriesAndProducts(string shopId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            var result = await _rustShopService.SetDefaultProductsAsync(shop);

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            var model = shop.CreateRustShopViewModel();
            return View("MainSettings", model);
        }

        [HttpGet]
        public async Task<IActionResult> ProductsManager(string shopId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = shop.CreateRustShopViewModel();

            return View(model);
        }


    }
}