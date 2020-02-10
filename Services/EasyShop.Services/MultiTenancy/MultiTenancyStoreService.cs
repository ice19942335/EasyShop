using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Interfaces.MultiTenancy;
using Finbuckle.MultiTenant;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShop.Services.MultiTenancy
{
    public class MultiTenancyStoreService : IMultiTenancyStoreService
    {
        private readonly RustShopMultiTenantStoreContext _tenantStoreContext;
        private readonly IMultiTenantStore _tenantStore;

        public MultiTenancyStoreService(IServiceProvider serviceProvider, RustShopMultiTenantStoreContext tenantStoreContext)
        {
            _tenantStoreContext = tenantStoreContext;
            _tenantStore = serviceProvider.GetRequiredService<IMultiTenantStore>();
        }

        public async Task<bool> TryAddAsync(string id, string identifier, string name, string connectionString)
        {
            if (connectionString is null)
                connectionString = "ConnectionString";

            return await _tenantStore.TryAddAsync(
                new TenantInfo(
                    id,
                    id.Replace("-", ""),
                    name,
                    connectionString,
                    null));
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var tenantDeletionResult = await _tenantStore.TryRemoveAsync(id);

            if (!tenantDeletionResult)
            {
                var tenant = _tenantStoreContext.TenantInfo.First(x => x.Id == id);

                _tenantStoreContext.Remove(tenant);

                var forceDeleteResult = await _tenantStoreContext.SaveChangesAsync();

                if (forceDeleteResult < 1)
                    return false;
                else
                    return true;
            }

            return true;
        }

        public async Task<TenantInfo> TryGetAsync(string id) => await _tenantStore.TryGetAsync(id);
    }
}
