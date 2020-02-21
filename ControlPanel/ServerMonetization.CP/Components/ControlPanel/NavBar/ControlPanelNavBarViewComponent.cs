using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums;
using EasyShop.Domain.ViewModels.ControlPanel.User.UserData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ServerMonetization.CP.Components.ControlPanel.NavBar
{
    public class ControlPanelNavBarViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public ControlPanelNavBarViewComponent(UserManager<AppUser> userManager) => _userManager = userManager;

        public IViewComponentResult Invoke()
        {
            var appUser = _userManager.FindByEmailAsync(User.Identity.Name).Result;

            if (appUser is null)
                return View("ControlPanelNavBar", new AppUserViewModel { FirstName = User.Identity.Name });

            var model = new AppUserViewModel
            {
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                BirthDate = appUser.BirthDate,
                Gender = appUser.Gender,
                TransactionPercent = appUser.TransactionPercent,
                ShopsAllowed = appUser.ShopsAllowed,
                ProfileImage = appUser.ProfileImage,
                Roles = _userManager.GetRolesAsync(appUser).Result
            };

            return View("ControlPanelNavBar", model);
        }
    }
}
