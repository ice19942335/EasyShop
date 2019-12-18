using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    public class ShopManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}