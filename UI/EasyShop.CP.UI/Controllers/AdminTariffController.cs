using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.ControlPanel.Tariff;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Interfaces.Services.CP.Tariff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTariffController : Controller
    {
        private readonly ITariffService _tariffService;
        private readonly ITariffOptionDescriptionService _tariffOptionDescriptionService;

        public AdminTariffController(
            ITariffService tariffService,
            ITariffOptionDescriptionService tariffOptionDescriptionService)
        {
            _tariffService = tariffService;
            _tariffOptionDescriptionService = tariffOptionDescriptionService;
        }

        public async Task<IActionResult> TariffManager()
        {
            var tariffs = await _tariffService.GetAllAsync();
            var tariffsOptions = await _tariffOptionDescriptionService.GetAllAsync();

            var model = new TariffManagerViewModel
            {
                Tariffs = tariffs.Select(x => new TariffViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    DaysActive = x.DaysActive,
                    Description = x.Description
                }),
                TariffOptionDescriptions = tariffsOptions.Select(x => new TariffOptionDescriptionViewModel()
                {
                    Id = x.Id,
                    Description = x.Description
                }),
            };

            return View(model);
        }

        #region Tariff

        [HttpGet]
        public async Task<IActionResult> EditTariff(int? id)
        {
            if (id != null)
            {
                var model = await _tariffService.GetByIdAsync((int)id);

                if (model is null)
                    return View("SomethingWentWrong", "on getting tariff by id");

                return View(model);
            }

            return View("EditTariff", new TariffViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> EditTariff([FromForm] TariffViewModel model)
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
                return RedirectToAction("TariffManager", "AdminTariff");
            }

            var tariffUpdated = await _tariffService.UpdateAsync(model);

            if (tariffUpdated is null)
                return View("SomethingWentWrong", "on updating existing tariff");

            return View(tariffUpdated);
        }

        public async Task<IActionResult> DeleteTariff(int id)
        {
            var result = await _tariffService.DeleteByIdAsync(id);

            if (result)
                return RedirectToAction("TariffManager", "AdminTariff");

            return View("SomethingWentWrong", "tariff deletion");
        }

        #endregion

        #region TariffOptionDescription

        [HttpGet]
        public async Task<IActionResult> EditTariffOptionDescription(int? id)
        {
            if (id != null)
            {
                var model = await _tariffOptionDescriptionService.GetByIdAsync((int)id);

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
                return RedirectToAction("TariffManager", "AdminTariff");
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
                return RedirectToAction("TariffManager", "AdminTariff");

            return View("SomethingWentWrong", "tariff option deletion");
        }

        #endregion

        public IActionResult SomethingWentWrong() => View();
    }
}