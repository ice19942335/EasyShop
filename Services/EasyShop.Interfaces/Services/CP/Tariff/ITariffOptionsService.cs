using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Tariff;

namespace EasyShop.Interfaces.Services.CP.Tariff
{
    public interface ITariffOptionsService
    {
        Task<IEnumerable<TariffOptionDescription>> GetAllAssignedToTariffByIdOptionDescriptionsAsync(int tariffId);
    }
}
