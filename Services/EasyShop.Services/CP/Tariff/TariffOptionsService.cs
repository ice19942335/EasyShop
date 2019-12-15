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
        public async Task<IEnumerable<TariffOptionDescription>> GetAllAssignedToTariffByIdOptionDescriptionsAsync(int tariffId)
        {
            var query = from tariffOption in _context.TariffOptions
                join optionDescription in _context.TariffOptionsDescriptions on tariffOption.TariffId equals tariffId
                select new
                {
                    Id = optionDescription.Id,
                    Name = optionDescription.Name,
                    Description = optionDescription.Description
                };

            return query.Select(x => new TariffOptionDescription
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            });
        }
    }
}
