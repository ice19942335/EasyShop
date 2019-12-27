﻿using System;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Enums.Rust;
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


        #region Shop statis

        [HttpGet]
        public async Task<IActionResult> ShopStats(string shopId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = shop.CreateRustShopViewModel();

            return View(model);
        }

        #endregion Shop statis

        #region Main settings

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

        #endregion Main settings

        #region Categories

        [HttpGet]
        public async Task<IActionResult> CategoriesManager(string shopId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = shop.CreateRustShopViewModel();

            var categories = _rustShopService.GetAllAssignedCategoriesToShopByShopId(Guid.Parse(shopId));
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
            return RedirectToAction("EditCategory", "RustShop", new { shopId = shopId });
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

        #endregion Categories

        #region Products

        [HttpGet]
        public async Task<IActionResult> ProductsManager(string shopId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = shop.CreateRustShopViewModel();
            model.RustProductsManagerViewModel = new RustProductsManagerViewModel();

            var allAssignedUserProducts = _rustShopService.GetAllAssignedProductsToAShopByShopId(Guid.Parse(shopId));

            model.RustProductsManagerViewModel.Products = allAssignedUserProducts.Select(x =>
            {
                var rustProductViewModel = new RustProductViewModel
                {
                    Id = x.Id.ToString(),
                    Name = x.RustItem.Name,
                    Price = x.Price,
                    Amount = x.Amount,
                    ImgUrl = x.RustItem.ImgUrl,
                    Description = x.Description,
                    BlockedTill = x.BlockedTill,
                    CategoryViewModel = x.RustCategory
                        .CreateRustCategoryViewModel(
                            _rustShopService.GetAssignedUserItemsCountToACategoryInShop(x.RustCategory.Id, Guid.Parse(shopId))),
                    Discount = x.Discount,
                    ShopInShop = x.ShowInShop
                };

                return rustProductViewModel;
            });

            return View(model);
        }

        public async Task<IActionResult> EditProduct(string shopId, string productId)
        {
            var shop = await _shopManager.GetShopByIdAsync(Guid.Parse(shopId));
            var product = await _rustShopService.GetProductByIdAsync(Guid.Parse(productId));

            if (shop is null || product is null)
                return RedirectToAction("NotFoundPage", "Home");

            var userCategories = _rustShopService.GetAllAssignedCategoriesToShopByShopId(Guid.Parse(shopId));

            var model = shop.CreateRustShopViewModel();
            model.RustEditProductViewModel = product.CreateRustEditProductViewModel(userCategories);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(RustShopViewModel model)
        {
            var userCategories = _rustShopService.GetAllAssignedCategoriesToShopByShopId(Guid.Parse(model.Id));
            var product = await _rustShopService.GetProductByIdAsync(Guid.Parse(model.RustEditProductViewModel.Id));

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));

                model.RustEditProductViewModel = product.CreateRustEditProductViewModel(userCategories);
                model.RustEditProductViewModel.Success = RustEditProductResult.Failed;

                return View(model);
            }

            var result = await _rustShopService.UpdateRustProductAsync(model);

            var updatedProduct = await _rustShopService.GetProductByIdAsync(Guid.Parse(model.RustEditProductViewModel.Id));
            model.RustEditProductViewModel = updatedProduct.CreateRustEditProductViewModel(userCategories);

            switch (result)
            {
                case RustEditProductResult.Success:
                {
                    model.RustEditProductViewModel.Success = RustEditProductResult.Success;
                    return View(model);
                }
                case RustEditProductResult.NotFound: return RedirectToAction("NotFoundPage", "Home");

                default: return RedirectToAction("SomethingWentWrong", "ControlPanel");
            }
        }

        #endregion Products
    }
}