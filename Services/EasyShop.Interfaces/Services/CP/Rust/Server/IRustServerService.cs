using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Enums.CP.Rust;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Shop;

namespace EasyShop.Interfaces.Services.CP.Rust.Server
{
    public interface IRustServerService
    {
        Task<(RustEditServerResult, string)> UpdateAsync(RustShopViewModel model);

        RustServer GetRustServerById(Guid serverId);

        IEnumerable<RustServer> GetAllShopServersById(Guid shopId);

        Task<bool> DeleteAsync(Guid serverId);

        Dictionary<string, string> GetAllMaps();
    }
}
