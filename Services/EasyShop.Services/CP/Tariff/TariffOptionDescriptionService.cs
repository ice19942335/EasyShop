using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Tariff;
using EasyShop.Domain.ViewModels.ControlPanel.Tariff;
using EasyShop.Interfaces.Services.CP.Tariff;

namespace EasyShop.Services.CP.Tariff
{
    public class TariffOptionDescriptionService : ITariffOptionDescriptionService
    {
        private readonly EasyShopContext _context;

        public TariffOptionDescriptionService(EasyShopContext context) => _context = context;

        public async Task<IEnumerable<TariffOptionDescription>> GetAllAsync() => _context.TariffOptionsDescriptions;

        public async Task<TariffOptionDescriptionViewModel> GetByIdAsync(int id)
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
                Description = model.Description
            };

            _context.TariffOptionsDescriptions.Add(tariffOptionDescription);
            await _context.SaveChangesAsync();

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

            return new TariffOptionDescriptionViewModel
            {
                Id = tariffOptionDescription.Id,
                Name = tariffOptionDescription.Name,
                Description = tariffOptionDescription.Description
            };
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var tariff = _context.TariffOptionsDescriptions.FirstOrDefault(x => x.Id == id);

            if (tariff is null)
                return false;

            _context.Remove(tariff);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
