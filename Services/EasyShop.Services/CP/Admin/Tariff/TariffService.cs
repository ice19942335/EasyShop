using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Tariff;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Interfaces.Services.CP.Admin.Tariff;
using EasyShop.Services.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace EasyShop.Services.CP.Tariff
{
    public class TariffService : ITariffService
    {
        private readonly EasyShopContext _context;
        private readonly ITariffOptionDescriptionService _tariffOptionDescriptionService;
        private readonly ITariffOptionsService _tariffOptionsService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<TariffService> _logger;
        private readonly HttpContext _httpContext;

        public TariffService(EasyShopContext context, 
            ITariffOptionDescriptionService tariffOptionDescriptionService, 
            ITariffOptionsService tariffOptionsService,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager,
            ILogger<TariffService> logger)
        {
            _context = context;
            _tariffOptionDescriptionService = tariffOptionDescriptionService;
            _tariffOptionsService = tariffOptionsService;
            _userManager = userManager;
            _logger = logger; 
            _httpContext = httpContextAccessor.HttpContext;
        }

        public IEnumerable<Domain.Entries.Tariff.Tariff> GetAll() => _context.Tariffs;

        public EditTariffViewModel GetById(int id)
        {
            var tariff = _context.Tariffs.FirstOrDefault(x => x.Id == id);

            if (tariff is null)
                return null;

            return new EditTariffViewModel
            {
                Id = tariff.Id,
                Name = tariff.Name,
                Price = tariff.Price,
                DaysActive = tariff.DaysActive,
                Description = tariff.Description,
                AllOptions = _tariffOptionDescriptionService.GetAll(),
                AssignedOptions = _tariffOptionsService.GetAllOptionsAssignedToATariffById(id)
            };
        }

        public async Task<EditTariffViewModel> CreateAsync(EditTariffViewModel model)
        {

            var newTariff = new Domain.Entries.Tariff.Tariff
            {
                Name = model.Name,
                Price = model.Price,
                DaysActive = model.DaysActive,
                Description = model.Description
            };

            _context.Tariffs.Add(newTariff);
            await _context.SaveChangesAsync();

            var userForLog = await _userManager.FindByEmailAsync(_httpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContext.Request.GetRawTarget(),
                $"Tariff: {JsonConvert.SerializeObject(newTariff)} was successfully created.");

            return model;
        }

        public async Task<EditTariffViewModel> UpdateAsync(EditTariffViewModel model)
        {
            var tariff = _context.Tariffs.First(x => x.Id == model.Id);

            if (tariff is null)
                return null;

            tariff.Name = model.Name;
            tariff.Price = model.Price;
            tariff.DaysActive = model.DaysActive;
            tariff.Description = model.Description;

            _context.Update(tariff);
            await _context.SaveChangesAsync();

            var updatedTariff = new EditTariffViewModel
            {
                Id = tariff.Id,
                Name = tariff.Name,
                Price = tariff.Price,
                DaysActive = tariff.DaysActive,
                Description = tariff.Description
            };

            var userForLog = await _userManager.FindByEmailAsync(_httpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContext.Request.GetRawTarget(),
                $"Tariff: {JsonConvert.SerializeObject(updatedTariff)} was successfully updated.");

            return updatedTariff;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var tariff = _context.Tariffs.FirstOrDefault(x => x.Id == id);

            if (tariff is null)
                return false;

            _context.Remove(tariff);
            await _context.SaveChangesAsync();

            var userForLog = await _userManager.FindByEmailAsync(_httpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContext.Request.GetRawTarget(),
                $"Tariff: {JsonConvert.SerializeObject(tariff)} was successfully deleted.");

            return true;
        }
    }
}
