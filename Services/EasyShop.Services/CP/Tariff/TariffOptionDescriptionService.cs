using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Tariff;
using EasyShop.Domain.ViewModels.ControlPanel.Tariff;
using EasyShop.Interfaces.Services.CP.Tariff;
using EasyShop.Services.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EasyShop.Services.CP.Tariff
{
    public class TariffOptionDescriptionService : ITariffOptionDescriptionService
    {
        private readonly EasyShopContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<TariffOptionDescriptionService> _logger;
        private readonly HttpContext _httpContext;

        public TariffOptionDescriptionService(
            EasyShopContext context, 
            IHttpContextAccessor httpContextAccessor, 
            UserManager<AppUser> userManager, 
            ILogger<TariffOptionDescriptionService> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public IEnumerable<TariffOptionDescription> GetAll() => _context.TariffOptionsDescriptions;

        public TariffOptionDescriptionViewModel GetById(int id)
        {
            var tariffOptionDescription = _context.TariffOptionsDescriptions.FirstOrDefault(x => x.Id == id);

            if (tariffOptionDescription is null)
                return null;

            return new TariffOptionDescriptionViewModel
            {
                Id = tariffOptionDescription.Id,
                Name = tariffOptionDescription.Name,
                Description = tariffOptionDescription.Description
            };
        }

        public async Task<TariffOptionDescriptionViewModel> CreateAsync(TariffOptionDescriptionViewModel model)
        {
            var tariffOptionDescription = new TariffOptionDescription
            {
                Name = model.Name,
                Description = model.Description
            };

            _context.TariffOptionsDescriptions.Add(tariffOptionDescription);
            await _context.SaveChangesAsync();

            var userForLog = await _userManager.FindByEmailAsync(_httpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContext.Request.GetRawTarget(),
                $"TariffOptionDescription: {JsonConvert.SerializeObject(tariffOptionDescription)} was successfully created.");

            return model;
        }

        public async Task<TariffOptionDescriptionViewModel> UpdateAsync(TariffOptionDescriptionViewModel model)
        {
            var tariffOptionDescription = _context.TariffOptionsDescriptions.First(x => x.Id == model.Id);

            if (tariffOptionDescription is null)
                return null;

            tariffOptionDescription.Name = model.Name;
            tariffOptionDescription.Description = model.Description;

            _context.Update(tariffOptionDescription);
            await _context.SaveChangesAsync();

            var newTariffOptionDescription = new TariffOptionDescriptionViewModel
            {
                Id = tariffOptionDescription.Id,
                Name = tariffOptionDescription.Name,
                Description = tariffOptionDescription.Description
            };

            var userForLog = await _userManager.FindByEmailAsync(_httpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContext.Request.GetRawTarget(),
                $"TariffOptionDescription: {JsonConvert.SerializeObject(newTariffOptionDescription)} was successfully updated.");

            return newTariffOptionDescription;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var tariff = _context.TariffOptionsDescriptions.FirstOrDefault(x => x.Id == id);

            if (tariff is null)
                return false;

            _context.Remove(tariff);
            await _context.SaveChangesAsync();

            var userForLog = await _userManager.FindByEmailAsync(_httpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContext.Request.GetRawTarget(),
                $"TariffOptionDescription: {JsonConvert.SerializeObject(tariff)} was successfully deleted.");

            return true;
        }
    }
}
