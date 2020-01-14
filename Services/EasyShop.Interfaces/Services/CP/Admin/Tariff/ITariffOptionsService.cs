using System.Collections.Generic;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Tariff;

namespace EasyShop.Interfaces.Services.CP.Admin.Tariff
{
    public interface ITariffOptionsService
    {
        IEnumerable<TariffOptionDescription> GetAllOptionsAssignedToATariffById(int tariffId);

        Task<TariffOption> CreateAsync(int tariffId, int optionDescriptionId);

        Task<TariffOption> DeleteAsync(int tariffId, int optionDescriptionId);
    }
}
