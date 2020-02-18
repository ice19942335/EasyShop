using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

            services.AddHttpClient("PayPalAuth", client =>
            {
                client.BaseAddress = new Uri(configuration["PayPalBaseUrl"] + "v1/oauth2/token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("");
            });
        }
    }
}
