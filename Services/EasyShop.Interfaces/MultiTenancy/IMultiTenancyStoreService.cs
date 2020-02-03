using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Finbuckle.MultiTenant;

namespace EasyShop.Interfaces.MultiTenancy
{
    public interface IMultiTenancyStoreService
    {
        Task<bool> TryAddAsync(string id, string identifier, string name, string connectionString);

        Task<bool> RemoveAsync(string id);

        Task<TenantInfo> TryGetAsync(string id);
    }
}

