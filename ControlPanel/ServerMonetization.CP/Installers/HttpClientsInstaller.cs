using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace ServerMonetization.CP.Installers
{
    public class HttpClientsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //NuGet package required
            //Microsoft.Extensions.Http.Polly
            //services.AddHttpClient("PayPalPayout", client =>
            //{
            //    client.BaseAddress = new Uri("https://api.some-service.com/resource");
            //})
            //    .AddTransientHttpErrorPolicy(x => x.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(300)));
        }
    }
}
