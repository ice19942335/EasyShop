using EasyShop.Domain.ViewModels.CP.ControlPanel.Shop;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using Microsoft.AspNetCore.Mvc;

namespace ServerMonetization.CP.Components.ControlPanel.SideNavigationShopsList
{
    public class SideNavigationShopsListViewComponent : ViewComponent
    {
        private readonly IShopService _shopService;

        public SideNavigationShopsListViewComponent(IShopService shop) => _shopService = shop;

        public IViewComponentResult Invoke()
        {
            var userShops = _shopService.UserShopsByUserEmailAsync(User.Identity.Name).Result;

            var model = new ShopsManagerViewModel { Shops = userShops };

            return View("ShopsList", model);
        }
    }
}
