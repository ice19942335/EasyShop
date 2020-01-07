using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.CP.Rust;
using EasyShop.Domain.Enums.CP.Rust.RedirectEnums;
using EasyShop.Domain.ViewModels.ControlPanel.Rust.Category;
using EasyShop.Domain.ViewModels.ControlPanel.Rust.Product;
using EasyShop.Domain.ViewModels.ControlPanel.Rust.Server;
using EasyShop.Domain.ViewModels.ControlPanel.Rust.Shop;
using EasyShop.Interfaces.Services.CP.Rust.Server;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Services.Mappers.ViewModels.Rust;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IRustShopStatsService _rustShopStatsService;

        public RustShopController(
            IShopManager shopManager,
            IRustShopService rustShopService,
            IHttpContextAccessor httpContextAccessor,
            IRustServerService rustServerService,
            UserManager<AppUser> userManager,
            IRustShopStatsService rustShopStatsService)
        {
            _shopManager = shopManager;
            _rustShopService = rustShopService;
            _httpContextAccessor = httpContextAccessor;
            _rustServerService = rustServerService;
            _userManager = userManager;
            _rustShopStatsService = rustShopStatsService;
        }


        #region Shop statis

        [HttpGet]
        public IActionResult ShopStats(string shopId, RustShopStatsPeriodEnum statsPeriod = RustShopStatsPeriodEnum.Over_the_last_week)
        {
            var shop = _shopManager.GetShopById(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var stats = statsPeriod switch
            {
                RustShopStatsPeriodEnum.Today => _rustShopStatsService.GetTodayStats(Guid.Parse(shopId)),
                RustShopStatsPeriodEnum.Over_the_last_week => _rustShopStatsService.GetOverTheLastWeekStats(Guid.Parse(shopId)),
                RustShopStatsPeriodEnum.Over_the_last_30_days => _rustShopStatsService.GetOverTheLast30DaysStats(Guid.Parse(shopId)),
                RustShopStatsPeriodEnum.Over_the_last_90_days => _rustShopStatsService.GetOverTheLast90DaysStats(Guid.Parse(shopId)),
                RustShopStatsPeriodEnum.Over_the_last_180_days => _rustShopStatsService.GetOverTheLast180DaysStats(Guid.Parse(shopId)),
                RustShopStatsPeriodEnum.Over_the_last_year => _rustShopStatsService.GetOverTheLastYearStats(Guid.Parse(shopId)),
            };

            var model = shop.CreateRustShopViewModel();
            model.StatsPeriod = statsPeriod;
            model.Stats = stats;

            return View(model);
        }



        #endregion Shop statis

        #region Main settings

        [HttpGet]
        public IActionResult EditMainSettings(string shopId, RustEditMainSettingsResult status = RustEditMainSettingsResult.Default)
        {
            var shop = _shopManager.GetShopById(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = shop.CreateRustShopViewModel();
            if (status != RustEditMainSettingsResult.Default)
                model.RustShopEditMainSettingsViewModel.Status = status;

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
            model.RustShopEditMainSettingsViewModel.Status = RustEditMainSettingsResult.Updated;

            return View(model);
        }

        public async Task<IActionResult> NewSecret(string shopId)
        {
            var result = await _shopManager.NewSecretAsync(Guid.Parse(shopId));

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            return RedirectToAction("EditMainSettings", "RustShop", new { shopId = shopId, status = RustEditMainSettingsResult.SecurityKeyUpdated });
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

        [HttpGet("DeleteCategory/{shopId}&{categoryId}")]
        public async Task<IActionResult> DeleteCategory(string shopId, string categoryId)
        {
            var result = await _rustShopService.DeleteCategory(Guid.Parse(categoryId));

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            var shop = _shopManager.GetShopById(Guid.Parse(shopId));
            var model = shop.CreateRustShopViewModel();

            return RedirectToAction("CategoriesManager", "RustShop", new { shopId = shopId });
        }

        [HttpGet("SetDefaultCategoriesAndProducts/{shopId}&{redirectTo}")]
        public async Task<IActionResult> SetDefaultCategoriesAndProducts(string shopId, RustSetDefaultCategoriesAndProductsRedirect redirectTo)
        {
            var shop = _shopManager.GetShopById(Guid.Parse(shopId));

            if (shop is null)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            var result = await _rustShopService.SetDefaultProductsAsync(await _userManager.FindByEmailAsync(User.Identity.Name), shop);

            if (!result)
                return RedirectToAction("SomethingWentWrong", "ControlPanel");

            var model = shop.CreateRustShopViewModel();
            model.RustShopEditMainSettingsViewModel.Status = RustEditMainSettingsResult.CategoriesReseted;

            if (redirectTo == RustSetDefaultCategoriesAndProductsRedirect.Categories)
                return RedirectToAction("CategoriesManager", "RustShop", new { shopId = model.Id });

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
                    ShowInShop = x.ShowInShop,
                    Index = x.Index
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

                bool showInShopValue = model.RustProductEditViewModel.ShowInShop;
                model.RustProductEditViewModel = product.CreateRustEditProductViewModel(userCategories);
                model.RustProductEditViewModel.Status = RustEditProductResult.Failed;
                model.RustProductEditViewModel.ShowInShop = showInShopValue;

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
            else if (result == RustEditProductResult.DateHaveToBeBiggerThanCurrentMoment)
            {
                model.RustProductEditViewModel.Status = RustEditProductResult.DateHaveToBeBiggerThanCurrentMoment;
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
                    MapsDict = _rustServerService.GetAllMaps(),
                    IsNewServer = true
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
                model.RustServerEditViewModel.IsNewServer = true;
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