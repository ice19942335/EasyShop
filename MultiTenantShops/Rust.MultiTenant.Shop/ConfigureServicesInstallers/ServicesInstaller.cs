using EasyShop.Interfaces.MultiTenancy;
using EasyShop.Services.MultiTenancy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rust.MultiTenant.Shop.ConfigureServicesInstallers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //TenantStore
            services.AddTransient<IMultiTenancyStoreService, MultiTenancyStoreService>();
        }
    }
}
