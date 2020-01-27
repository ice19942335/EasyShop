using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Interfaces.MultiTenancy;
using Finbuckle.MultiTenant;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShop.Services.MultiTenancy
{
    public class MultiTenancyStoreService : IMultiTenancyStoreService
    {
        private readonly IMultiTenantStore _tenantStore;

        public MultiTenancyStoreService(IServiceProvider serviceProvider) => _tenantStore = serviceProvider.GetRequiredService<IMultiTenantStore>();

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

        public async Task<bool> TryRemoveAsync(string id) => await _tenantStore.TryRemoveAsync(id);

        public async Task<TenantInfo> TryGetAsync(string id) => await _tenantStore.TryGetAsync(id);
    }
}
