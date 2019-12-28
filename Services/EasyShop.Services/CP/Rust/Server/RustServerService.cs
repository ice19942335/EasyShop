using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Enums.Rust;
using EasyShop.Domain.ViewModels.Rust.Shop;
using EasyShop.Interfaces.Services.CP.Rust.Server;

namespace EasyShop.Services.CP.Rust.Server
{
    public class RustServerService : IRustServerService
    {
        public Task<RustServer> CreateAsync(RustShopViewModel model)
        {
            throw new NotImplementedException();
        }

        public RustServer GetRustServerById(Guid serverId)
        {
            throw new NotImplementedException();
        }

        public Task<RustCreateServerResult> UpdateAsync(RustShopViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid serverId)
        {
            throw new NotImplementedException();
        }
    }
}
