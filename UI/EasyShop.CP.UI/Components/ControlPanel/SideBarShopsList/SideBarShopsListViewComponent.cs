using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Interfaces.Services.CP.Shop;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EasyShop.CP.UI.Components.ControlPanel.SideBarShopsList
{
    public class SideBarShopsListViewComponent : ViewComponent
    {
        private readonly IShopManagerService _shopManager;

        public SideBarShopsListViewComponent(IShopManagerService shopManager) => _shopManager = shopManager;

        public IViewComponentResult Invoke()
        {
            var userShops = _shopManager.UserShopsByUserEmail(User.Identity.Name).Result;

            var model = new ShopManagerViewModel { Shops = userShops };

            return View(model);
        }
    }
}
