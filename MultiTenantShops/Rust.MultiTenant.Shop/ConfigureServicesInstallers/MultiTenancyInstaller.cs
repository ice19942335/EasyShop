using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rust.MultiTenant.Shop.ConfigureServicesInstallers
{
    public class MultiTenancyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMultiTenant()
                .WithEFCoreStore<RustShopMultiTenantStoreContext>()
                .WithRouteStrategy();
        }
    }
}
