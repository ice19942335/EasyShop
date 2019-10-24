using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Security() => View();
    }
}