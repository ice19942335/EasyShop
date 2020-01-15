using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.CP.Admin.BugReport;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Tariff;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Interfaces.Services.CP.Admin.BugReport;
using EasyShop.Interfaces.Services.CP.Admin.Tariff;
using EasyShop.Services.Mappers.ViewModels.Admin.BugReport;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ITariffService _tariffService;
        private readonly ITariffOptionDescriptionService _tariffOptionDescriptionService;
        private readonly ITariffOptionsService _tariffOptionsService;
        private readonly IAdminBugReportsService _bugReportsService;

        public AdminController(
            ITariffService tariffService,
            ITariffOptionDescriptionService tariffOptionDescriptionService,
            ITariffOptionsService tariffOptionsService,
            IAdminBugReportsService bugReportsService)
        {
            _tariffService = tariffService;
            _tariffOptionDescriptionService = tariffOptionDescriptionService;
            _tariffOptionsService = tariffOptionsService;
            _bugReportsService = bugReportsService;
        }

        public IActionResult TariffManager()
        {
            var tariffs = _tariffService.GetAll();
            var tariffsOptions = _tariffOptionDescriptionService.GetAll();

            var model = new TariffManagerViewModel
            {
                Tariffs = tariffs.Select(x => new EditTariffViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    DaysActive = x.DaysActive,
                    Description = x.Description
                }),
                TariffOptionDescriptions = tariffsOptions.Select(x => new TariffOptionDescriptionViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }),
            };

            return View(model);
        }

        public IActionResult SomethingWentWrong() => View();

        #region Tariff
        [HttpGet]
        public IActionResult EditTariff(int? id)
        {
            if (id != null)
            {
                var model = _tariffService.GetById((int)id);
                if (model is null)
                    return View("SomethingWentWrong", "on getting tariff by id");

                model.AllOptions = _tariffOptionDescriptionService.GetAll();
                model.AssignedOptions = _tariffOptionsService.GetAllOptionsAssignedToATariffById((int)id);
                return View(model);
            }

            return View("EditTariff", new EditTariffViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> EditTariff([FromForm] EditTariffViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            if (model.Id is null)
            {
                await _tariffService.CreateAsync(model);
                return RedirectToAction("TariffManager");
            }

            var tariffUpdated = await _tariffService.UpdateAsync(model);

            if (tariffUpdated is null)
                return View("SomethingWentWrong", "on updating existing tariff");


            tariffUpdated.AllOptions = _tariffOptionDescriptionService.GetAll();
            tariffUpdated.AssignedOptions = _tariffOptionsService.GetAllOptionsAssignedToATariffById((int)model.Id);
            return View(tariffUpdated);
        }

        public async Task<IActionResult> DeleteTariff(int id)
        {
            var result = await _tariffService.DeleteByIdAsync(id);

            if (result)
                return RedirectToAction("TariffManager");

            return View("SomethingWentWrong", "tariff deletion");
        }
        #endregion

        #region TariffOptionDescription
        [HttpGet]
        public IActionResult EditTariffOptionDescription(int? id)
        {
            if (id != null)
            {
                var model = _tariffOptionDescriptionService.GetById((int)id);

                if (model is null)
                    return View("SomethingWentWrong", "on getting tariff option by id");

                return View(model);
            }

            return View("EditTariffOptionDescription", new TariffOptionDescriptionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> EditTariffOptionDescription([FromForm] TariffOptionDescriptionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            if (model.Id is null)
            {
                await _tariffOptionDescriptionService.CreateAsync(model);
                return RedirectToAction("TariffManager");
            }

            var tariffUpdated = await _tariffOptionDescriptionService.UpdateAsync(model);

            if (tariffUpdated is null)
                return View("SomethingWentWrong", "on updating existing tariff option");

            return View(tariffUpdated);
        }

        public async Task<IActionResult> DeleteTariffOptionDescription(int id)
        {
            var result = await _tariffOptionDescriptionService.DeleteByIdAsync(id);

            if (result)
                return RedirectToAction("TariffManager");

            return View("SomethingWentWrong", "tariff option deletion");
        }
        #endregion

        #region TarifOptionManipulation
        [HttpGet]
        public async Task<IActionResult> AddAnOptionToATariff(int tariffId, int optionId)
        {
            var result = await _tariffOptionsService.CreateAsync(tariffId, optionId);

            var tariffModel = _tariffService.GetById(tariffId);

            if (result is null)
                return View("EditTariff", tariffModel);

            return View("EditTariff", tariffModel);
        }

        public async Task<IActionResult> RemoveAnOptionFromATariff(int tariffId, int optionId)
        {
            var result = await _tariffOptionsService.DeleteAsync(tariffId, optionId);

            var tariffModel = _tariffService.GetById(tariffId);

            if (result is null)
                return View("EditTariff", tariffModel);

            return View("EditTariff", tariffModel);
        }

        public IActionResult Index() => View();
        #endregion

        #region BugReports

        public IActionResult BugReportsList()
        {
            var result = _bugReportsService.GetAllBugReports();

            if (result is null)
                return View(new BugReportsListViewModel());

            var model = new BugReportsListViewModel { BugReports = result.Select(x => x.CreateBugReportViewModel()) };

            return View(model);
        }

        public IActionResult EditBugReport(string bugId, bool updateResult = false)
        {
            var result = _bugReportsService.GetReportById(Guid.Parse(bugId));

            if (result is null)
                return RedirectToAction("NotFoundPage", "Home");

            var model = result.CreateBugReportViewModel();
            model.UpdateResult = updateResult;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditBugReport([FromForm] BugReportViewModel model)
        {
            var result = await _bugReportsService.UpdateBugReportStatus(model, Url);

            if (!result)
                return RedirectToAction("SomethingWentWrong");

            return RedirectToAction("EditBugReport", "Admin", new { bugId = model.Id, updateResult = true });
        }

        #endregion BugReports
    }
}