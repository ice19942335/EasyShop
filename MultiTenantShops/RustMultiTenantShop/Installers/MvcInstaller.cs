using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RustMultiTenantShop.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddRazorPages(); // Need it because of View features
            services.AddMvcCore();
        }
    }
}
