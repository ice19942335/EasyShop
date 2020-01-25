using System.Threading.Tasks;

namespace MultiTenancyStrategy.Interfaces
{
    public interface ITenantResolutionStrategy
    {
        Task<string> GetTenantIdentifierAsync();
    }
}
