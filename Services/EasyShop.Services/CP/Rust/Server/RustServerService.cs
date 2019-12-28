using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Enums.Rust;
using EasyShop.Domain.ViewModels.Rust.Shop;
using EasyShop.Interfaces.Services.CP.Rust.Server;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Services.CP.Rust.Server
{
    public class RustServerService : IRustServerService
    {
        private readonly EasyShopContext _context;

        public RustServerService(EasyShopContext context)
        {
            _context = context;
        }

        public Task<RustServer> CreateAsync(RustShopViewModel model)
        {
            throw new NotImplementedException();
        }

        public RustServer GetRustServerById(Guid serverId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RustServer> GetAllShopServersById(Guid shopId)
        {
            return _context.RustServers.Include(x => x.Shop).Where(x => x.Shop.Id == shopId);
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
