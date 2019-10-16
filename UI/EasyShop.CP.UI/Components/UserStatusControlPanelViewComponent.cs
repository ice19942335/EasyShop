using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Components
{
    [ViewComponent(Name = "UserStatusControlPanel")]
    public class UserStatusControlPanelViewComponent : ViewComponent
    {
        private readonly EasyShopContext _context;

        public UserStatusControlPanelViewComponent(EasyShopContext context) => _context = context;

        public IViewComponentResult Invoke()
        {
            var appUser = _context.Users.FirstOrDefault(user => user.UserName == User.Identity.Name);

            if (appUser is null)
                return View(new UserDataViewModel { FirstName = User.Identity.Name });

            var model = new UserDataViewModel
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
