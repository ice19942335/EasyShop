using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Tariff;
using EasyShop.Interfaces.Services.CP.Tariff;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Services.CP.Tariff
{
    public class TariffOptionsService : ITariffOptionsService
    {
        private readonly EasyShopContext _context;

        public TariffOptionsService(EasyShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TariffOptionDescription>> GetAllOptionsAssignedToATariffByIdAsync(int tariffId)
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

            return queryResult;
        }
    }
}
