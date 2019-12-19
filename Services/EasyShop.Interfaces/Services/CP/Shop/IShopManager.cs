using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;

namespace EasyShop.Interfaces.Services.CP.Shop
{
    public interface IShopManager
    {
        Task<bool> CreateShopAsync(CreateShopViewModel model);

        Task<IEnumerable<Domain.Entries.Shop.Shop>> UserShopsByUserEmailAsync(string userEmail);

        Task<Domain.Entries.Shop.Shop> GetShopByIdAsync(Guid shopId);
    }
}
