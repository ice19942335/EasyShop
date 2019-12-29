﻿using System;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Enums.Rust;
using EasyShop.Domain.ViewModels.Rust.Category;
using EasyShop.Domain.ViewModels.Rust.Product;
using EasyShop.Domain.ViewModels.Rust.Server;
using EasyShop.Domain.ViewModels.Rust.Shop;
using EasyShop.Interfaces.Services.CP.Rust.Server;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
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
        private readonly IRustServerService _rustServerService;

        public RustShopController(IShopManager shopManager,
            IRustShopService rustShopService,
            IHttpContextAccessor httpContextAccessor,
            IRustServerService rustServerService)
        {
            _shopManager = shopManager;
            _rustShopService = rustShopService;
            _httpContextAccessor = httpContextAccessor;
            _rustServerService = rustServerService;
        }


        #region Shop statis

        [HttpGet]
        public IActionResult ShopStats(string shopId)
        {
            var shop = _shopManager.GetShopById(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = shop.CreateRustShopViewModel();

            return View(model);
        }

        #endregion Shop statis

        #region Main settings

        [HttpGet]
        public IActionResult EditMainSettings(string shopId)
        {
            var shop = _shopManager.GetShopById(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = shop.CreateRustShopViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditMainSettings([FromForm] RustShopViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));

                var shop = _shopManager.GetShopById(Guid.Parse(model.Id));
                model.RustShopEditMainSettingsViewModel.Secret = shop.Secret;

                model.RustShopEditMainSettingsViewModel.Status = RustEditMainSettingsResult.Failed;
                return View(model);
            }

            var result = await _rustShopService.UpdateShopAsync(model.RustShopEditMainSettingsViewModel);

            if (result is null)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            model = result.CreateRustShopViewModel();
            model.RustShopEditMainSettingsViewModel.Status = RustEditMainSettingsResult.Success;

            return View(model);
        }

        #endregion Main settings

        #region Categories

        [HttpGet]
        public IActionResult CategoriesManager(string shopId)
        {
            var shop = _shopManager.GetShopById(Guid.Parse(shopId));

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
        public IActionResult CreateCategory(string shopId)
        {
            return RedirectToAction("EditCategory", "RustShop", new { shopId = shopId });
        }

        [HttpGet]
        public IActionResult EditCategory(string shopId, string categoryId, bool created = false)
        {
            var shop = _shopManager.GetShopById(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            var model = shop.CreateRustShopViewModel();

            if (categoryId is null)
            {
                model.RustCategoryEditViewModel = new RustCategoryEditViewModel();
                return View(model);
            }

            var category = _rustShopService.GetCategoryById(Guid.Parse(categoryId));

            model.RustCategoryEditViewModel.Category =
                category.CreateRustCategoryViewModel(_rustShopService.GetAssignedUserItemsCountToACategoryInShop(category.Id, shop.Id));

            if (created)
                model.RustCategoryEditViewModel.Status = RustEditCategoryResult.Created;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory([FromForm] RustShopViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));
                model.RustCategoryEditViewModel.Status = RustEditCategoryResult.Failed;
                return View(model);
            }

            var result = await _rustShopService.UpdateCategoryAsync(model);
            model.RustCategoryEditViewModel.Status = result.Item2;

            switch (result.Item2)
            {
                case RustEditCategoryResult.Success:
                    return View(model);

                case RustEditCategoryResult.Created:
                    return RedirectToAction("EditCategory", "RustShop", new { shopId = model.Id, categoryId = result.Item1.Id, created = true });

                case RustEditCategoryResult.Failed:
                    return View(model);

                default: return RedirectToAction("SomethingWentWrong", "ControlPanel");
            }
        }

        [HttpGet(template: "{shopId}&{categoryId}")]
        public async Task<IActionResult> DeleteCategory(string shopId, string categoryId)
        {
            var result = await _rustShopService.DeleteCategory(Guid.Parse(categoryId));

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            var shop = _shopManager.GetShopById(Guid.Parse(shopId));
            var model = shop.CreateRustShopViewModel();

            return RedirectToAction("CategoriesManager", "RustShop", new { shopId = shopId });
        }

        [HttpGet("SetDefaultCategoriesAndProducts/{shopId}")]
        public async Task<IActionResult> SetDefaultCategoriesAndProducts(string shopId)
        {
            var shop = _shopManager.GetShopById(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            var result = await _rustShopService.SetDefaultProductsAsync(shop);

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            var model = shop.CreateRustShopViewModel();
            return View("EditMainSettings", model);
        }

        #endregion Categories

        #region Products

        [HttpGet]
        public IActionResult ProductsManager(string shopId)
        {
            var shop = _shopManager.GetShopById(Guid.Parse(shopId));

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

        public IActionResult EditProduct(string shopId, string productId)
        {
            var shop = _shopManager.GetShopById(Guid.Parse(shopId));
            var product = _rustShopService.GetProductById(Guid.Parse(productId));

            if (shop is null || product is null)
                return RedirectToAction("NotFoundPage", "Home");

            var userCategories = _rustShopService.GetAllAssignedCategoriesToShopByShopId(Guid.Parse(shopId));

            var model = shop.CreateRustShopViewModel();
            model.RustProductEditViewModel = product.CreateRustEditProductViewModel(userCategories);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(RustShopViewModel model)
        {
            var userCategories = _rustShopService.GetAllAssignedCategoriesToShopByShopId(Guid.Parse(model.Id));
            var product = _rustShopService.GetProductById(Guid.Parse(model.RustProductEditViewModel.Id));

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));

                model.RustProductEditViewModel = product.CreateRustEditProductViewModel(userCategories);
                model.RustProductEditViewModel.Status = RustEditProductResult.Failed;

                return View(model);
            }

            var result = await _rustShopService.UpdateRustProductAsync(model);

            var updatedProduct = _rustShopService.GetProductById(Guid.Parse(model.RustProductEditViewModel.Id));
            model.RustProductEditViewModel = updatedProduct.CreateRustEditProductViewModel(userCategories);


            if (result == RustEditProductResult.Success)
            {
                model.RustProductEditViewModel.Status = RustEditProductResult.Success;
                return View(model);
            }
            else if (result == RustEditProductResult.NotFound)
            {
                return RedirectToAction("NotFoundPage", "Home");
            }

            return RedirectToAction("SomethingWentWrong", "ControlPanel");
        }

        #endregion Products

        #region Servers

        public IActionResult ServersManager(string shopId)
        {
            var shop = _shopManager.GetShopById(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var shopServers = _rustServerService.GetAllShopServersById(Guid.Parse(shopId));

            var model = shop.CreateRustShopViewModel();

            model.RustServerManagerViewModel = new RustServerManagerViewModel
            {
                RustServers = shopServers.Select(x => x.CreateRustServerViewModel())
            };

            return View(model);
        }

        [HttpGet("CreateServer/{shopId}")]
        public IActionResult CreateServer(string shopId)
        {
            return RedirectToAction("EditServer", "RustShop", new { shopId = shopId });
        }

        public IActionResult EditServer(string shopId, string serverId, RustEditServerResult status = RustEditServerResult.Default)
        {
            var shop = _shopManager.GetShopById(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = shop.CreateRustShopViewModel();

            if (serverId is null)
            {
                model.RustServerEditViewModel = new RustServerEditViewModel
                {
                    ShowInShop = true,
                    MapsDict = _rustServerService.GetAllMaps()
                };
                return View(model);
            }

            var server = _rustServerService.GetRustServerById(Guid.Parse(serverId));
            if (server is null)
                return RedirectToAction("NotFoundPage", "Home");

            model.RustServerEditViewModel = new RustServerEditViewModel
            {
                Id = server.Id.ToString(),
                Name = server.Name,
                NameInShop = server.NameInShop,
                Index = server.Index,
                IpAddress = server.IpAddress,
                Port = server.Port,
                MapId = server.ServerMap.Id.ToString(),
                ShowInShop = server.ShowInShop,
                MapsDict = _rustServerService.GetAllMaps(),
                Status = status,
                CurrentMap = server.ServerMap.Type
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditServer([FromForm] RustShopViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));

                model.RustServerEditViewModel.Status = RustEditServerResult.Failed;
                model.RustServerEditViewModel.MapsDict = _rustServerService.GetAllMaps();
                return View(model);
            }

            var resultPair = await _rustServerService.UpdateAsync(model);
            var status = resultPair.Item1;
            var serverId = resultPair.Item2;

            model.RustServerEditViewModel.MapsDict = _rustServerService.GetAllMaps();

            if (status == RustEditServerResult.Updated)
            {
                return RedirectToAction("EditServer",
                    new { shopId = model.Id, serverId = serverId, status = RustEditServerResult.Updated });
            }
            else if (status == RustEditServerResult.Created)
            {
                return RedirectToAction("EditServer",
                    new { shopId = model.Id, serverId = serverId, status = RustEditServerResult.Created });
            }

            return RedirectToAction("SomethingWentWrong", "ControlPanel");
        }

        [HttpGet("DeleteServer/{shopId}&{serverId}")]
        public async Task<IActionResult> DeleteServer(string shopId, string serverId)
        {
            var result = await _rustServerService.DeleteAsync(Guid.Parse(serverId));

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            return RedirectToAction("ServersManager", "RustShop", new { shopId = shopId });
        }

        #endregion Servers
    }
}