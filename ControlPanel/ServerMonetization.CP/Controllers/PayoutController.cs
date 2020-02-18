using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServerMonetization.CP.Controllers
{
    public class PayoutController : Controller
    {
        public IActionResult Summary()
        {
            return View();
        }

        public IActionResult Withdraw()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }
    }
}