using EasyShop.DAL.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServerMonetization.CP.Installers
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
