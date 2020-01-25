using System.Linq;
using System.Threading.Tasks;
using MultiTenancyStrategy.Models;

namespace MultiTenancyStrategy.Interfaces
{
    /// <summary>
    /// InMemory store for testing
    /// </summary>
    public class InMemoryTenantStore : ITenantStore<Tenant>
    {
        /// <summary>
        /// Get a tenant for a given identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public async Task<Tenant> GetTenantAsync(string identifier)
        {
            var tenant = new[]
            {
                new Tenant {Id = "80fdb3c0-5888-4295-bf40-ebee0e3cd8f3", Identifier = "localhost"}
            }.SingleOrDefault(x => x.Identifier == identifier);

            return await Task.FromResult(tenant);
        }
    }
}
