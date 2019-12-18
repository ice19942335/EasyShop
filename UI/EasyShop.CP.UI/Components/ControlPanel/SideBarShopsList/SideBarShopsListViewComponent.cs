using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace EasyShop.CP.UI.Components.ControlPanel.SideBarShopsList
{
    public class SideBarShopsListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new Dictionary<string, int> {{"ShopName", 1}};
            return View(model);
        }
    }
}
