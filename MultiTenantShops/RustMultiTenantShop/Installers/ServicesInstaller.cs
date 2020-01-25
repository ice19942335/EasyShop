using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenancyStrategy.Accessors;
using MultiTenancyStrategy.Interfaces;
using MultiTenancyStrategy.Models;

namespace RustMultiTenantShop.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Transient

            //Scoped
            services.AddScoped<ITenantAccessor<Tenant>, TenantAccessor<Tenant>>();

            //Single-tone
        }
    }
}
