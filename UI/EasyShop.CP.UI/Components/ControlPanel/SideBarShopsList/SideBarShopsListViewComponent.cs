﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EasyShop.CP.UI.Components.ControlPanel.SideBarShopsList
{
    public class SideBarShopsListViewComponent : ViewComponent
    {
        private readonly IShopManager _shopManager;

        public SideBarShopsListViewComponent(IShopManager shop) => _shopManager = shop;

        public IViewComponentResult Invoke()
        {
            var userShops = _shopManager.UserShopsByUserEmailAsync(User.Identity.Name).Result;

            var model = new ShopsManagerViewModel { Shops = userShops };

            return View(model);
        }
    }
}
