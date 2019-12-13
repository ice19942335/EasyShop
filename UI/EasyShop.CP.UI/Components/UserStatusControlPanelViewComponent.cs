using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.User.UserData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Components
{
    [ViewComponent(Name = "UserStatusControlPanel")]
    public class UserStatusControlPanelViewComponent : ViewComponent
    {
        private IUserStore<AppUser> _userStore;
        public UserStatusControlPanelViewComponent(IUserStore<AppUser> userStore) => _userStore = userStore;
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
                ShopsAllowed = appUser.ShopsAllowed
            };

            return View(model);
        }
    }
}
