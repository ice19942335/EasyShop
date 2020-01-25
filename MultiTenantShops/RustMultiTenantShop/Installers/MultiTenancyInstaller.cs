using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenancyStrategy;
using MultiTenancyStrategy.Extensions;
using MultiTenancyStrategy.HostResolutionStrategy;
using MultiTenancyStrategy.Interfaces;

namespace RustMultiTenantShop.Installers
{
    public class MultiTenancyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMultiTenancy()
                .WithResolutionStrategy<HostResolutionStrategy>()
                .WithStore<InMemoryTenantStore>();
        }
    }
}
