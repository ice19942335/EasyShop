using EasyShop.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rust.MultiTenant.Shop.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RustShopMultiTenantStoreContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TenantsStoreDevConnection")));

            services.AddDbContext<EasyShopContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ControlPanelDevConnection")));
        }
    }

}
