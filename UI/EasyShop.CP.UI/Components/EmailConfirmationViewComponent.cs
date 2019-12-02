using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Components
{
    public class EmailConfirmationViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public EmailConfirmationViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            if (user is null)
                return View(EmailConfirmationEnum.SomethingWentWrong);

            return View(user.EmailConfirmed ? EmailConfirmationEnum.EmailIsConfirmed : EmailConfirmationEnum.EmailNotConfirmed);
        }
    }
}
