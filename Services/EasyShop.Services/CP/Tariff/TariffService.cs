using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.ViewModels.ControlPanel.Tariff;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Interfaces.Services.CP.Tariff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace EasyShop.Services.CP.Tariff
{
    public class TariffService : ITariffService
    {
        private readonly EasyShopContext _context;
        private readonly ITariffOptionDescriptionService _tariffOptionDescriptionService;
        private readonly ITariffOptionsService _tariffOptionsService;

        public TariffService(EasyShopContext context, ITariffOptionDescriptionService tariffOptionDescriptionService, ITariffOptionsService tariffOptionsService)
        {
            _context = context;
            _tariffOptionDescriptionService = tariffOptionDescriptionService;
            _tariffOptionsService = tariffOptionsService;
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

            return new EditTariffViewModel
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
