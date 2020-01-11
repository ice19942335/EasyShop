using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.CP.ContactUs;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BugReport()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult BugReport([FromForm] CreateBugReportViewModel model)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult RustShopReport()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult RustShopReport([FromForm] CreateRustShopReportViewModel model)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GeneralSupport()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult GeneralSupport([FromForm] CreateGeneralReportViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}