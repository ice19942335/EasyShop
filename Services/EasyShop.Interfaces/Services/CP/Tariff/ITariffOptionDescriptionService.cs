using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.ControlPanel.Tariff;

namespace EasyShop.Interfaces.Services.CP.Tariff
{
    public interface ITariffOptionDescriptionService
    {
        Task<IEnumerable<Domain.Entries.Tariff.TariffOptionDescription>> GetAllAsync();

        Task<TariffOptionDescriptionViewModel> GetByIdAsync(int id);

        Task<TariffOptionDescriptionViewModel> CreateAsync(TariffOptionDescriptionViewModel model);

        Task<TariffOptionDescriptionViewModel> UpdateAsync(TariffOptionDescriptionViewModel model);

        Task<bool> DeleteByIdAsync(int id);
    }
}
