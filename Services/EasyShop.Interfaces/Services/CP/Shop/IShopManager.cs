using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.GameType;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;

namespace EasyShop.Interfaces.Services.CP.Shop
{
    public interface IShopManager
    {

        string GetShopGameTypeById(Guid shopId);

        Task<IEnumerable<Domain.Entries.Shop.Shop>> UserShopsByUserEmailAsync(string userEmail);

        Task<Domain.Entries.Shop.Shop> GetShopByIdAsync(Guid shopId);

        Task<bool> NewSecretAsync(Guid shopId);
    }
}
