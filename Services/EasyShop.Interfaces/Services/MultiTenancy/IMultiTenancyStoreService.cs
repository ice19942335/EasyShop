using System.Threading.Tasks;
using Finbuckle.MultiTenant;

namespace EasyShop.Interfaces.Services.MultiTenancy
{
    public interface IMultiTenancyStoreService
    {
        Task<bool> TryAddAsync(string id, string identifier, string name, string connectionString);

        Task<bool> RemoveAsync(string id);

        Task<TenantInfo> TryGetAsync(string id);
    }
}

