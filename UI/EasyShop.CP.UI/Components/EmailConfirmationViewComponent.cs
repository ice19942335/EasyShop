using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Components
{
    public class EmailConfirmationViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public EmailConfirmationViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            if (user is null)
                return View(false);

            return View(user.EmailConfirmed);
        }
    }
}
