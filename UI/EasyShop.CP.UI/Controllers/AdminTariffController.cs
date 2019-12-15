using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.ControlPanel.Tariff;
using EasyShop.Interfaces.Services.CP;
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

        public AdminTariffController(ITariffService tariffService) => _tariffService = tariffService;

        public async Task<IActionResult> TariffManager()
        {
            var tariffs = await _tariffService.GetAllAsync();

            var model = new TariffManagerViewModel { Tariffs = tariffs };

            return View(model);
        }

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

        [HttpGet]
        public async Task<IActionResult> DeleteTariff(int id)
        {
            var result = await _tariffService.DeleteByIdAsync(id);

            if (result)
                return RedirectToAction("TariffManager", "AdminTariff");

            return View("SomethingWentWrong", "tariff deletion");
        }

        public IActionResult SomethingWentWrong() => View();
    }
}