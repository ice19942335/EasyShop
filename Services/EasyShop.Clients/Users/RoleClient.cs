using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EasyShop.Clients.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace EasyShop.Clients.Users
{
    public class RoleClient : BaseClient, IRoleStore<IdentityRole>
    {
        public RoleClient(IConfiguration configuration) : base(configuration, "api/roles") { }

        #region Implementation of IRoleStore<IdentityRole>

        public async Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancel) =>
            await (await PostAsync(_serviceAddress, role, cancel))
                .Content
                .ReadAsAsync<bool>(cancel)
                ? IdentityResult.Success
                : IdentityResult.Failed();

        public async Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancel) =>
            await (await PutAsync(_serviceAddress, role, cancel))
                .Content
                .ReadAsAsync<bool>(cancel)
                ? IdentityResult.Success
                : IdentityResult.Failed();

        public async Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancel) =>
            await (await PostAsync($"{_serviceAddress}/Delete", role, cancel))
                .Content
                .ReadAsAsync<bool>(cancel)
                ? IdentityResult.Success
                : IdentityResult.Failed();

        public async Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancel) =>
            await (await PostAsync($"{_serviceAddress}/GetRoleId", role, cancel))
                .Content
                .ReadAsAsync<string>(cancel);

        public async Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancel) =>
            await (await PostAsync($"{_serviceAddress}/GetRoleName", role, cancel))
                .Content
                .ReadAsAsync<string>(cancel);

        public async Task SetRoleNameAsync(IdentityRole role, string name, CancellationToken cancel)
        {
            role.Name = name;
            await PostAsync($"{_serviceAddress}/SetRoleName/{name}", role, cancel);
        }

        public async Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancel) =>
            await (await PostAsync($"{_serviceAddress}/GetNormalizedRoleName", role, cancel))
                .Content
                .ReadAsAsync<string>(cancel);

        public async Task SetNormalizedRoleNameAsync(IdentityRole role, string name, CancellationToken cancel)
        {
            role.NormalizedName = name;
            await PostAsync($"{_serviceAddress}/SetNormalizedRoleName/{name}", role, cancel);
        }

        public async Task<IdentityRole> FindByIdAsync(string id, CancellationToken cancel) =>
            await GetAsync<IdentityRole>($"{_serviceAddress}/FindById/{id}", cancel);

        public async Task<IdentityRole> FindByNameAsync(string name, CancellationToken cancel) =>
            await GetAsync<IdentityRole>($"{_serviceAddress}/FindByName/{name}", cancel);

        #endregion
    }
}
