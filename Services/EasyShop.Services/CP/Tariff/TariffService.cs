using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.ViewModels.ControlPanel.Tariff;
using EasyShop.Interfaces.Services.CP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace EasyShop.Services.CP.Tariff
{
    public class TariffService : ITariffService
    {
        private readonly EasyShopContext _context;

        public TariffService(EasyShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TariffViewModel>> GetAllAsync()
        {
            var tariffs = _context.Tariffs.Select(x => new TariffViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                DaysActive = x.DaysActive,
                Description = x.Description
            });

            return tariffs;
        }

        public async Task<TariffViewModel> GetByIdAsync(int id)
        {
            var tariff = _context.Tariffs.FirstOrDefault(x => x.Id == id);

            if (tariff is null)
                return null;

            return new TariffViewModel
            {
                Id = tariff.Id,
                Name = tariff.Name,
                Price = tariff.Price,
                DaysActive = tariff.DaysActive,
                Description = tariff.Description
            };
        }

        public async Task<TariffViewModel> CreateAsync(TariffViewModel model)
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

            return model;
        }

        public async Task<TariffViewModel> UpdateAsync(TariffViewModel model)
        {
            var tariff = _context.Tariffs.Include(x => x.TariffOptions).First(x => x.Id == model.Id);

            if (tariff is null)
                return null;

            tariff.Name = model.Name;
            tariff.Price = model.Price;
            tariff.DaysActive = model.DaysActive;
            tariff.Description = model.Description;

            _context.Update(tariff);
            await _context.SaveChangesAsync();

            return new TariffViewModel
            {
                Id = tariff.Id,
                Name = tariff.Name,
                Price = tariff.Price,
                DaysActive = tariff.DaysActive,
                Description = tariff.Description
            };
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var tariff = _context.Tariffs.FirstOrDefault(x => x.Id == id);

            if (tariff is null)
                return false;

            _context.Remove(tariff);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
