using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.User.UserData;
using EasyShop.Services.Data.FirstRunIdentityInitialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Components.ControlPanel.NavBar
{
    public class ControlPanelUserStatusViewComponent : ViewComponent
    {
        private readonly IUserStore<AppUser> _userStore;
        private readonly UserManager<AppUser> _userManager;

        public ControlPanelUserStatusViewComponent(IUserStore<AppUser> userStore, UserManager<AppUser> userManager)
        {
            _userStore = userStore;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var appUser = _userStore.FindByNameAsync(User.Identity.Name, default).Result;

            if (appUser is null)
                return View(new ApplicationUserViewModel { FirstName = User.Identity.Name });

            var model = new ApplicationUserViewModel
            {
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                BirthDate = appUser.BirthDate,
                Gender = appUser.Gender,
                TransactionPercent = appUser.TransactionPercent,
                ShopsAllowed = appUser.ShopsAllowed,
                ProfileImage = appUser.ProfileImage
            };

            if (_userManager.IsInRoleAsync(appUser, DefaultIdentity.RoleAdmin).Result)
                return View("Admin", model);

            return View(model);
        }
    }
}
