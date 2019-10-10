using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyShop.Clients.Base;
using EasyShop.Domain.DTO.Identity;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EasyShop.Clients.User
{
    public class UserClient : BaseClient, IUserClient
    {
        private readonly ILogger<UserClient> _logger;

        public UserClient(IConfiguration configuration, ILogger<UserClient> logger) : base(configuration, "api/users") => _logger = logger;

        #region Implementation of IUserStore<User>

        public async Task<string> GetUserIdAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/UserId", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel)
                .ConfigureAwait(false);
        }

        public async Task<string> GetUserNameAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/UserName", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel)
                .ConfigureAwait(false);
        }

        public async Task SetUserNameAsync(Domain.Entities.Identity.User user, string name, CancellationToken cancel)
        {
            _logger.LogInformation("User name changing, from {0} to: {1}", user.UserName, name);
            user.UserName = name;
            await PostAsync($"{_serviceAddress}/UserName/{name}", user, cancel);
        }

        public async Task<string> GetNormalizedUserNameAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/NormalUserName/", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel)
                .ConfigureAwait(false);
        }

        public async Task SetNormalizedUserNameAsync(Domain.Entities.Identity.User user, string name, CancellationToken cancel)
        {
            user.NormalizedUserName = name;
            await PostAsync($"{_serviceAddress}/NormalUserName/{name}", user, cancel);
        }

        public async Task<IdentityResult> CreateAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/User", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel)
                ? IdentityResult.Success
                : IdentityResult.Failed();
        }

        public async Task<IdentityResult> UpdateAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PutAsync($"{_serviceAddress}/User", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel)
                ? IdentityResult.Success
                : IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/User/Delete", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel)
                ? IdentityResult.Success
                : IdentityResult.Failed();
        }

        public async Task<Domain.Entities.Identity.User> FindByIdAsync(string id, CancellationToken cancel)
        {
            return await GetAsync<Domain.Entities.Identity.User>($"{_serviceAddress}/User/Find/{id}", cancel);
        }

        public async Task<Domain.Entities.Identity.User> FindByNameAsync(string name, CancellationToken cancel)
        {
            var user = await GetAsync<Domain.Entities.Identity.User>($"{_serviceAddress}/User/Normal/{name}", cancel);
            return user;
        }

        #endregion

        #region Implementation of IUserRoleStore<User>

        public async Task AddToRoleAsync(Domain.Entities.Identity.User user, string role, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/Role/{role}", user, cancel);
        }

        public async Task RemoveFromRoleAsync(Domain.Entities.Identity.User user, string role, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/Role/Delete/{role}", user, cancel);
        }

        public async Task<IList<string>> GetRolesAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/roles", user, cancel))
               .Content
               .ReadAsAsync<IList<string>>(cancel);
        }

        public async Task<bool> IsInRoleAsync(Domain.Entities.Identity.User user, string role, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/InRole/{role}", user, cancel))
               .Content
               .ReadAsAsync<bool>(cancel);
        }

        public async Task<IList<Domain.Entities.Identity.User>> GetUsersInRoleAsync(string role, CancellationToken cancel)
        {
            return await GetAsync<List<Domain.Entities.Identity.User>>($"{_serviceAddress}/UsersInRole/{role}", cancel);
        }

        #endregion

        #region Implementation of IUserPasswordStore<User>

        public async Task SetPasswordHashAsync(Domain.Entities.Identity.User user, string hash, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/SetPasswordHash", new PasswordHashDTO { Hash = hash, User = user },
                cancel);
        }

        public async Task<string> GetPasswordHashAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetPasswordHash", user, cancel))
               .Content
               .ReadAsAsync<string>(cancel);
        }

        public async Task<bool> HasPasswordAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/HasPassword", user, cancel))
               .Content
               .ReadAsAsync<bool>(cancel);
        }

        #endregion

        #region Implementation of IUserEmailStore<User>

        public async Task SetEmailAsync(Domain.Entities.Identity.User user, string email, CancellationToken cancel)
        {
            user.Email = email;
            await PostAsync($"{_serviceAddress}/SetEmail/{email}", user, cancel);
        }

        public async Task<string> GetEmailAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetEmail", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel);
        }

        public async Task<bool> GetEmailConfirmedAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetEmailConfirmed", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel);
        }

        public async Task SetEmailConfirmedAsync(Domain.Entities.Identity.User user, bool confirmed, CancellationToken cancel)
        {
            user.EmailConfirmed = confirmed;
            await PostAsync($"{_serviceAddress}/SetEmailConfirmed/{confirmed}", user, cancel);
        }

        public async Task<Domain.Entities.Identity.User> FindByEmailAsync(string email, CancellationToken cancel)
        {
            return await GetAsync<Domain.Entities.Identity.User>($"{_serviceAddress}/User/FindByEmail/{email}", cancel);
        }

        public async Task<string> GetNormalizedEmailAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/User/GetNormalizedEmail", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel);
        }

        public async Task SetNormalizedEmailAsync(Domain.Entities.Identity.User user, string email, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/SetNormalizedEmail/{email}", user, cancel);
        }

        #endregion

        #region Implementation of IUserPhoneNumberStore<User>

        public async Task SetPhoneNumberAsync(Domain.Entities.Identity.User user, string phone, CancellationToken cancel)
        {
            user.PhoneNumber = phone;
            await PostAsync($"{_serviceAddress}/SetPhoneNumber/{phone}", user, cancel);
        }

        public async Task<string> GetPhoneNumberAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetPhoneNumber", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel);
        }

        public async Task<bool> GetPhoneNumberConfirmedAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetPhoneNumberConfirmed", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel);
        }

        public async Task SetPhoneNumberConfirmedAsync(Domain.Entities.Identity.User user, bool confirmed, CancellationToken cancel)
        {
            user.PhoneNumberConfirmed = confirmed;
            await PostAsync($"{_serviceAddress}/SetPhoneNumberConfirmed/{confirmed}", user, cancel);
        }

        #endregion

        #region Implementation of IUserLoginStore<User>

        public async Task AddLoginAsync(Domain.Entities.Identity.User user, UserLoginInfo login, CancellationToken cancel)
        {
            _logger.LogInformation("User {0} login in system", user.UserName);
            await PostAsync($"{_serviceAddress}/AddLogin", new AddLoginDTO { User = user, UserLoginInfo = login }, cancel);
        }

        public async Task RemoveLoginAsync(Domain.Entities.Identity.User user, string loginProvider, string providerKey, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/RemoveLogin/{loginProvider}/{providerKey}", user, cancel);
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetLogins", user, cancel))
                .Content
                .ReadAsAsync<List<UserLoginInfo>>(cancel);
        }

        public async Task<Domain.Entities.Identity.User> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancel)
        {
            return await GetAsync<Domain.Entities.Identity.User>($"{_serviceAddress}/User/FindByLogin/{loginProvider}/{providerKey}", cancel);
        }

        #endregion

        #region Implementation of IUserLockoutStore<User>

        public async Task<DateTimeOffset?> GetLockoutEndDateAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetLockoutEndDate", user, cancel))
                .Content
                .ReadAsAsync<DateTimeOffset?>(cancel);
        }

        public async Task SetLockoutEndDateAsync(Domain.Entities.Identity.User user, DateTimeOffset? endDate, CancellationToken cancel)
        {
            user.LockoutEnd = endDate;
            await PostAsync($"{_serviceAddress}/SetLockoutEndDate",
                new SetLockoutDTO { User = user, LockoutEnd = endDate }, cancel);
        }

        public async Task<int> IncrementAccessFailedCountAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/IncrementAccessFailedCount", user, cancel))
                .Content
                .ReadAsAsync<int>(cancel);
        }

        public async Task ResetAccessFailedCountAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/ResetAccessFailedCont", user, cancel);
        }

        public async Task<int> GetAccessFailedCountAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetAccessFailedCount", user, cancel))
                .Content
                .ReadAsAsync<int>(cancel);
        }

        public async Task<bool> GetLockoutEnabledAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetLockoutEnabled", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel);
        }

        public async Task SetLockoutEnabledAsync(Domain.Entities.Identity.User user, bool enabled, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/SetLockoutEnabled/{enabled}", user, cancel);
        }

        #endregion

        #region Implementation of IUserTwoFactorStore<User>

        public async Task SetTwoFactorEnabledAsync(Domain.Entities.Identity.User user, bool enabled, CancellationToken cancel)
        {
            user.TwoFactorEnabled = enabled;
            await PostAsync($"{_serviceAddress}/SetTwoFactor/{enabled}", user, cancel);
        }

        public async Task<bool> GetTwoFactorEnabledAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetTwoFactorEnabled", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel);
        }

        #endregion

        #region Implementation of IUserClaimStore<User>

        public async Task<IList<Claim>> GetClaimsAsync(Domain.Entities.Identity.User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetClaims", user, cancel))
                .Content
                .ReadAsAsync<List<Claim>>(cancel);
        }

        public async Task AddClaimsAsync(Domain.Entities.Identity.User user, IEnumerable<Claim> claims, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/AddClaims", new AddClaimDTO { User = user, Claims = claims }, cancel);
        }

        public async Task ReplaceClaimAsync(Domain.Entities.Identity.User user, Claim oldClaim, Claim newClaim, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/ReplaceClaim",
                new ReplaceClaimDTO { User = user, OldClaim = oldClaim, NewClaim = newClaim }, cancel);
        }

        public async Task RemoveClaimsAsync(Domain.Entities.Identity.User user, IEnumerable<Claim> claims, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/RemoveClaims", new RemoveClaimDTO { User = user, Claims = claims },
                cancel);
        }

        public async Task<IList<Domain.Entities.Identity.User>> GetUsersForClaimAsync(Claim claim, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetUsersForClaim", claim, cancel))
                .Content
                .ReadAsAsync<List<Domain.Entities.Identity.User>>(cancel);
        }

        #endregion
    }
}
