using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerMonetization.CP.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NotFoundPage() => View();

        public IActionResult ServerErrorPage() => View();

        public IActionResult ErrorStatus(string id)
        {
            switch (id)
            {
                case "404":
                    return RedirectToAction(nameof(NotFoundPage));
                default:
                    return RedirectToAction(nameof(ServerErrorPage), "Home", new {statusCode = id});
            }
        }

        public IActionResult SomethingWentWrong() => View();
    }
}