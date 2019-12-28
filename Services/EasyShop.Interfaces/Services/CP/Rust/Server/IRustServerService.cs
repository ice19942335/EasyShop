using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Enums.Rust;
using EasyShop.Domain.ViewModels.Rust.Shop;

namespace EasyShop.Interfaces.Services.CP.Rust.Server
{
    public interface IRustServerService
    {
        Task<RustServer> CreateAsync(RustShopViewModel model);

        RustServer GetRustServerById(Guid serverId);

        IEnumerable<RustServer> GetAllShopServersById(Guid shopId);

        Task<RustCreateServerResult> UpdateAsync(RustShopViewModel model);

        Task<bool> DeleteAsync(Guid serverId);
    }
}
