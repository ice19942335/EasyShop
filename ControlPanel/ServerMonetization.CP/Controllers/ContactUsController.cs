using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.ControlPanel.ContactUs;
using EasyShop.Interfaces.Services.CP.ContactUs;
using Microsoft.AspNetCore.Mvc;

namespace ServerMonetization.CP.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IBugReportService _bugReportService;

        public ContactUsController(IBugReportService bugReportService)
        {
            _bugReportService = bugReportService;
        }

        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult CreateBugReport() => View(new CreateBugReportViewModel());

        [HttpPost]
        public async Task<IActionResult> CreateBugReport([FromForm] CreateBugReportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            var result = await _bugReportService.CreateBugReport(model, Url);

            if (!result)
                return RedirectToAction("SomethingWentWrong", "Home");

            return View("BugReportWasSuccessfullySent");

        }

        public IActionResult BugReportWasSuccessfullySent() => View();

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