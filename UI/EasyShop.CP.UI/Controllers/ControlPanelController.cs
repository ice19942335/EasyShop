using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize]
    public class ControlPanelController : Controller
    {
        public IActionResult Dashboard() => View();

        public IActionResult SomethingWentWrong(string reason) => View(reason);
    }
}