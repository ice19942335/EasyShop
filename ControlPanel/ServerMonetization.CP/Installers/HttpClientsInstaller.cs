using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ServerMonetization.CP.Installers
{
    public class HttpClientsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("PayPalPayout", client =>
            {
                client.BaseAddress = new Uri(configuration["PayPalBaseUrl"]);
            });
        }
    }
}
