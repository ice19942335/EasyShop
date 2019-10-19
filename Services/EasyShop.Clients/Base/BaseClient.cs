using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace EasyShop.Clients.Base
{
    public abstract class BaseClient
    {
        private readonly HttpClient _client;

        private readonly string _serviceAddress;

        protected BaseClient(IConfiguration configuration, string serviceAddress)
        {
            _serviceAddress = serviceAddress;

            _client = new HttpClient{ BaseAddress = new Uri(configuration["ClientAddress"])};
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
