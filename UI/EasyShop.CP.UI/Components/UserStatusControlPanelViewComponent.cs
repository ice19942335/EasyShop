using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Components
{
    [ViewComponent(Name = "UserStatusControlPanel")]
    public class UserStatusControlPanelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = new UserViewModel
            {
                FirstName = User.Identity.Name
            };

            return View(model);
        }
    }
}
