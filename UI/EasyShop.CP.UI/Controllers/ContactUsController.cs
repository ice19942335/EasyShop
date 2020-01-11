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
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult BugReport() => View(new CreateBugReportViewModel());

        [HttpPost]
        public IActionResult BugReport([FromForm] CreateBugReportViewModel model)
        {
            var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
            errors.ForEach(x => ModelState.AddModelError("", x));
            return View(model);
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

        [HttpGet]
        public IActionResult Collaboration()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Collaboration([FromForm] CreateRustShopReportViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}