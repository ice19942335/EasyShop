using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.ControlPanel.Tariff;

namespace EasyShop.Interfaces.Services.CP
{
    public interface ITariffService
    {
        Task<IEnumerable<TariffViewModel>> GetAllAsync();

        Task<TariffViewModel> GetByIdAsync(int id);

        Task<TariffViewModel> CreateAsync(TariffViewModel model);

        Task<TariffViewModel> UpdateAsync(TariffViewModel model);

        Task<bool> DeleteByIdAsync(int id);
    }
}
