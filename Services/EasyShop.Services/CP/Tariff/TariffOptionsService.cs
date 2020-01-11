using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Tariff;
using EasyShop.Interfaces.Services.CP.Tariff;
using EasyShop.Services.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace EasyShop.Services.CP.Tariff
{
    public class TariffOptionsService : ITariffOptionsService
    {
        private readonly EasyShopContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<TariffOptionsService> _logger;
        private readonly HttpContext _httpContext;

        public TariffOptionsService(
            EasyShopContext context,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager,
            ILogger<TariffOptionsService> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public IEnumerable<TariffOptionDescription> GetAllOptionsAssignedToATariffById(int tariffId)
        {
            var query = from tariffOption in _context.TariffOptions
                        join optionDescription in _context.TariffOptionsDescriptions on tariffOption.TariffOptionDescriptionId equals optionDescription.Id
                        where tariffOption.TariffId == tariffId
                        select new TariffOptionDescription
                        {
                            Id = optionDescription.Id,
                            Name = optionDescription.Name,
                            Description = optionDescription.Description
                        };

            return query.AsEnumerable();
        }

        public async Task<TariffOption> CreateAsync(int tariffId, int optionDescriptionId)
        {
            var query = from option in _context.TariffOptions
                        where option.TariffId == tariffId && option.TariffOptionDescriptionId == optionDescriptionId
                        select new TariffOption
                        {
                            TariffOptionDescriptionId = option.TariffOptionDescriptionId,
                            TariffOptionDescription = option.TariffOptionDescription,
                            TariffId = option.TariffId,
                            Tariff = option.Tariff
                        };

            if (query.FirstOrDefault() != null)
                return null;

            var tariff = _context.Tariffs.FirstOrDefault(x => x.Id == tariffId);
            var tariffOptionDescription = _context.TariffOptionsDescriptions.FirstOrDefault(x => x.Id == optionDescriptionId);

            var tariffOption = new TariffOption
            {
                TariffOptionDescriptionId = optionDescriptionId,
                TariffOptionDescription = tariffOptionDescription,
                TariffId = tariffId,
                Tariff = tariff
            };

            _context.TariffOptions.Add(tariffOption);
            await _context.SaveChangesAsync();

            var userForLog = await _userManager.FindByEmailAsync(_httpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContext.Request.GetRawTarget(),
                $"An option Name:{tariffOptionDescription.Name}, Id: {tariffOptionDescription.Id} was assigned to a tariff Name: {tariff.Name}, Id: {tariff.Id}");

            return tariffOption;
        }

        public async Task<TariffOption> DeleteAsync(int tariffId, int optionDescriptionId)
        {
            var query = from tariffOption in _context.TariffOptions
                        join optionDescription in _context.TariffOptionsDescriptions on tariffOption.TariffOptionDescriptionId equals optionDescription.Id
                        where tariffOption.TariffId == tariffId && optionDescription.Id == optionDescriptionId
                        select new TariffOption
                        {
                            TariffOptionDescriptionId = tariffOption.TariffOptionDescriptionId,
                            TariffOptionDescription = tariffOption.TariffOptionDescription,
                            TariffId = tariffOption.TariffId,
                            Tariff = tariffOption.Tariff
                        };

            var queryResult = query.FirstOrDefault();

            if (queryResult is null)
                return null;

            _context.TariffOptions.Remove(queryResult);
            await _context.SaveChangesAsync();

            var tariff = _context.Tariffs.FirstOrDefault(x => x.Id == queryResult.TariffId);
            var tariffOptionDescription = _context.TariffOptionsDescriptions.FirstOrDefault(x => x.Id == queryResult.TariffOptionDescriptionId);

            var userForLog = await _userManager.FindByEmailAsync(_httpContext.User.Identity.Name);
            _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                userForLog.UserName,
                userForLog.Id,
                _httpContext.Request.GetRawTarget(),
                $"An option Name:{tariffOptionDescription.Name}, Id: {tariffOptionDescription.Id} was removed from tariff Name: {tariff.Name}, Id: {tariff.Id}");

            return queryResult;
        }
    }
}
