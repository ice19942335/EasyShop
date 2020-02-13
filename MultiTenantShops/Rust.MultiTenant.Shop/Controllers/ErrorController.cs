using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rust.MultiTenant.Shop.Controllers
{
    public class ErrorController : Controller
    {
        [Route("{*url}", Order = 999)]
        public IActionResult CatchAll()
        {
            Response.StatusCode = 404;
            return View(nameof(Error404));
        }

        [Route("/Error/ShopNotFound")]
        public IActionResult ShopNotFound() => View();


        [Route("/Error/ErrorHandler/{code}")]
        public IActionResult ErrorHandler(int? code)
        {
            switch (code)
            {
                case 404: return View(nameof(Error404));
                case 500: return View(nameof(Error500));

                default: return View(nameof(Error500));
            }
        }

        public IActionResult Error404() => View();

        public IActionResult Error500() => View();
    }
}