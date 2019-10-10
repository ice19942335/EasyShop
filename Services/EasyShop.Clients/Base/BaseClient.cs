using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EasyShop.Clients.Base
{
    public class BaseClient : IDisposable
    {
        protected readonly HttpClient _client;

        protected readonly string _serviceAddress;

        public BaseClient(IConfiguration config, string serviceAddress)
        {
            _serviceAddress = serviceAddress;

            _client = new HttpClient { BaseAddress = new Uri(config["ClientAddress"]) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(config["DataTypeJson"]));
        }

        protected async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken = default) where T : new()
        {
            var response = await _client.GetAsync(url, cancellationToken);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<T>(cancellationToken);
            return new T();
        }

        protected T Get<T>(string url) where T : new() => GetAsync<T>(url).Result;

        protected async Task<HttpResponseMessage> PostAsync<T>(string url, T item, CancellationToken cancellationToken = default)
        {
            return (await _client.PostAsJsonAsync(url, item, cancellationToken)).EnsureSuccessStatusCode();
        }

        protected HttpResponseMessage Post<T>(string url, T item) => PostAsync(url, item).Result;


        protected async Task<HttpResponseMessage> PutAsync<T>(string url, T item, CancellationToken cancellationToken = default)
        {
            return (await _client.PutAsJsonAsync(url, item, cancellationToken)).EnsureSuccessStatusCode();
        }

        protected HttpResponseMessage Put<T>(string url, T item) => PutAsync(url, item).Result;

        protected async Task<HttpResponseMessage> DeleteAsync(string url, CancellationToken cancellationToken = default)
        {
            return await _client.DeleteAsync(url, cancellationToken);
        }

        protected HttpResponseMessage Delete(string url) => DeleteAsync(url).Result;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseClient()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _client?.Dispose();
        }
    }
}
