using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Interfaces.Services.CP.Shop;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    public class ShopManagerController : Controller
    {
        private readonly IShopManagerService _shopManager;

        public ShopManagerController(IShopManagerService shopManager)
        {
            _shopManager = shopManager;
        }

        public IActionResult Index()
        {
            var userShops = _shopManager.UserShopsByUserEmail(User.Identity.Name).Result;

            var model = new ShopManagerViewModel { Shops = userShops };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditShop(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> EditShop(EditShopViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}