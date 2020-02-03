using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rust.MultiTenant.Shop.Controllers
{
    public class PaymentController : Controller
    {
        public PaymentController()
        {
            
        }

        [HttpPost]
        public IActionResult Buy()
        {
            return RedirectToAction("Store", "Home");
        }
    }
}