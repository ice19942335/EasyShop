﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rust.MultiTenant.Shop.Installers;

namespace Rust.MultiTenant.Shop.ConfigureServicesInstallers
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