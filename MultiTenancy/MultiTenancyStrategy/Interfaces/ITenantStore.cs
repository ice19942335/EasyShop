using System.Threading.Tasks;
using MultiTenancyStrategy.Models;

namespace MultiTenancyStrategy.Interfaces
{
    public interface ITenantStore<T> where T : Tenant
    {
        Task<T> GetTenantAsync(string identifier);
    }
}
