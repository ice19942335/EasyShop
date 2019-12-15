using System.Collections.Generic;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.ControlPanel.Tariff;

namespace EasyShop.Interfaces.Services.CP.Tariff
{
    public interface ITariffService
    {
        Task<IEnumerable<Domain.Entries.Tariff.Tariff>> GetAllAsync();

        Task<EditTariffViewModel> GetByIdAsync(int id);

        Task<EditTariffViewModel> CreateAsync(EditTariffViewModel model);

        Task<EditTariffViewModel> UpdateAsync(EditTariffViewModel model);

        Task<bool> DeleteByIdAsync(int id);
    }
}
