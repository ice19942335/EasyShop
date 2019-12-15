using System.Collections.Generic;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.ControlPanel.Tariff;

namespace EasyShop.Interfaces.Services.CP.Tariff
{
    public interface ITariffService
    {
        Task<IEnumerable<Domain.Entries.Tariff.Tariff>> GetAllAsync();

        Task<TariffViewModel> GetByIdAsync(int id);

        Task<TariffViewModel> CreateAsync(TariffViewModel model);

        Task<TariffViewModel> UpdateAsync(TariffViewModel model);

        Task<bool> DeleteByIdAsync(int id);
    }
}
