using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Tariff;
using EasyShop.Domain.ViewModels.ControlPanel.Tariff;

namespace EasyShop.Interfaces.Services.CP.Tariff
{
    public interface ITariffOptionDescriptionService
    {
        IEnumerable<TariffOptionDescription> GetAll();

        TariffOptionDescriptionViewModel GetById(int id);

        Task<TariffOptionDescriptionViewModel> CreateAsync(TariffOptionDescriptionViewModel model);

        Task<TariffOptionDescriptionViewModel> UpdateAsync(TariffOptionDescriptionViewModel model);

        Task<bool> DeleteByIdAsync(int id);
    }
}
