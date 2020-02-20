using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyShop.Interfaces.Services.CP.Shop
{
    public interface IShopService
    {

        string GetShopGameTypeById(Guid shopId);

        Task<IEnumerable<Domain.Entries.Shop.Shop>> UserShopsByUserEmailAsync(string userEmail);

        Domain.Entries.Shop.Shop GetShopById(Guid shopId);

        Task<bool> NewSecretAsync(Guid shopId);
    }
}
