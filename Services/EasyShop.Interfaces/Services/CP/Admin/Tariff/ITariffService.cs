using System.Collections.Generic;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Tariff;

namespace EasyShop.Interfaces.Services.CP.Admin.Tariff
{
    public interface ITariffService
    {
        IEnumerable<Domain.Entries.Tariff.Tariff> GetAll();

        EditTariffViewModel GetById(int id);

        Task<EditTariffViewModel> CreateAsync(EditTariffViewModel model);

        Task<EditTariffViewModel> UpdateAsync(EditTariffViewModel model);

        Task<bool> DeleteByIdAsync(int id);
    }
}
