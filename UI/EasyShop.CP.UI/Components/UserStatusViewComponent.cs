using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Components
{
    [ViewComponent(Name = "UserStatus")]
    public class UserStatusViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (User.Identity.IsAuthenticated)
                return View("SignedIn");

            return View();
        }
    }
}
