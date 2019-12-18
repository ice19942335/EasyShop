using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyShop.Interfaces.Services.CP.Shop
{
    public interface IShopManagerService
    {
        Task<IEnumerable<Domain.Entries.Shop.Shop>> UserShopsByUserEmail(string userEmail);
    }
}
