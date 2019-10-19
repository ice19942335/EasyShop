using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using EasyShop.Clients.Base;
using EasyShop.Domain.DTO.Identity;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EasyShop.Clients.Users
{
    public class UserClient : BaseClient, IUserClient
    {
        private readonly ILogger<UserClient> _logger;

        public UserClient(IConfiguration configuration, ILogger<UserClient> logger) : base(configuration, "api/users") => _logger = logger;

        #region Implementation of IUserStore<ApplicationUser>

        public async Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/UserId", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel)
                .ConfigureAwait(false);
        }

        public async Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/UserName", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel)
                .ConfigureAwait(false);
        }

        public async Task SetUserNameAsync(ApplicationUser user, string name, CancellationToken cancel)
        {
            _logger.LogInformation("ApplicationUser name changing, from {0} to: {1}", user.UserName, name);
            user.UserName = name;
            await PostAsync($"{_serviceAddress}/UserName/{name}", user, cancel);
        }

        public async Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/NormalUserName/", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel)
                .ConfigureAwait(false);
        }

        public async Task SetNormalizedUserNameAsync(ApplicationUser user, string name, CancellationToken cancel)
        {
            user.NormalizedUserName = name;
            await PostAsync($"{_serviceAddress}/NormalUserName/{name}", user, cancel);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/ApplicationUser", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel)
                ? IdentityResult.Success
                : IdentityResult.Failed();
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PutAsync($"{_serviceAddress}/ApplicationUser", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel)
                ? IdentityResult.Success
                : IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/ApplicationUser/Delete", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel)
                ? IdentityResult.Success
                : IdentityResult.Failed();
        }

        public async Task<ApplicationUser> FindByIdAsync(string id, CancellationToken cancel)
        {
            return await GetAsync<ApplicationUser>($"{_serviceAddress}/ApplicationUser/Find/{id}", cancel);
        }

        public async Task<ApplicationUser> FindByNameAsync(string name, CancellationToken cancel)
        {
            var user = await GetAsync<ApplicationUser>($"{_serviceAddress}/ApplicationUser/Normal/{name}", cancel);
            return user;
        }

        #endregion

        #region Implementation of IUserRoleStore<ApplicationUser>

        public async Task AddToRoleAsync(ApplicationUser user, string role, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/Role/{role}", user, cancel);
        }

        public async Task RemoveFromRoleAsync(ApplicationUser user, string role, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/Role/Delete/{role}", user, cancel);
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/roles", user, cancel))
               .Content
               .ReadAsAsync<IList<string>>(cancel);
        }

        public async Task<bool> IsInRoleAsync(ApplicationUser user, string role, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/InRole/{role}", user, cancel))
               .Content
               .ReadAsAsync<bool>(cancel);
        }

        public async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string role, CancellationToken cancel)
        {
            return await GetAsync<List<ApplicationUser>>($"{_serviceAddress}/UsersInRole/{role}", cancel);
        }

        #endregion

        #region Implementation of IUserPasswordStore<ApplicationUser>

        public async Task SetPasswordHashAsync(ApplicationUser user, string hash, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/SetPasswordHash", new PasswordHashDTO { Hash = hash, User = user },
                cancel);
        }

        public async Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetPasswordHash", user, cancel))
               .Content
               .ReadAsAsync<string>(cancel);
        }

        public async Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/HasPassword", user, cancel))
               .Content
               .ReadAsAsync<bool>(cancel);
        }

        #endregion

        #region Implementation of IUserEmailStore<ApplicationUser>

        public async Task SetEmailAsync(ApplicationUser user, string email, CancellationToken cancel)
        {
            user.Email = email;
            await PostAsync($"{_serviceAddress}/SetEmail/{email}", user, cancel);
        }

        public async Task<string> GetEmailAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetEmail", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel);
        }

        public async Task<bool> GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetEmailConfirmed", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel);
        }

        public async Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancel)
        {
            user.EmailConfirmed = confirmed;
            await PostAsync($"{_serviceAddress}/SetEmailConfirmed/{confirmed}", user, cancel);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string email, CancellationToken cancel)
        {
            return await GetAsync<ApplicationUser>($"{_serviceAddress}/ApplicationUser/FindByEmail/{email}", cancel);
        }

        public async Task<string> GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/ApplicationUser/GetNormalizedEmail", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel);
        }

        public async Task SetNormalizedEmailAsync(ApplicationUser user, string email, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/SetNormalizedEmail/{email}", user, cancel);
        }

        #endregion

        #region Implementation of IUserPhoneNumberStore<ApplicationUser>

        public async Task SetPhoneNumberAsync(ApplicationUser user, string phone, CancellationToken cancel)
        {
            user.PhoneNumber = phone;
            await PostAsync($"{_serviceAddress}/SetPhoneNumber/{phone}", user, cancel);
        }

        public async Task<string> GetPhoneNumberAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetPhoneNumber", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel);
        }

        public async Task<bool> GetPhoneNumberConfirmedAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetPhoneNumberConfirmed", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel);
        }

        public async Task SetPhoneNumberConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancel)
        {
            user.PhoneNumberConfirmed = confirmed;
            await PostAsync($"{_serviceAddress}/SetPhoneNumberConfirmed/{confirmed}", user, cancel);
        }

        #endregion

        #region Implementation of IUserLoginStore<ApplicationUser>

        public async Task AddLoginAsync(ApplicationUser user, UserLoginInfo login, CancellationToken cancel)
        {
            _logger.LogInformation("ApplicationUser {0} login in system", user.UserName);
            await PostAsync($"{_serviceAddress}/AddLogin", new AddLoginDTO { User = user, UserLoginInfo = login }, cancel);
        }

        public async Task RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/RemoveLogin/{loginProvider}/{providerKey}", user, cancel);
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetLogins", user, cancel))
                .Content
                .ReadAsAsync<List<UserLoginInfo>>(cancel);
        }

        public async Task<ApplicationUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancel)
        {
            return await GetAsync<ApplicationUser>($"{_serviceAddress}/ApplicationUser/FindByLogin/{loginProvider}/{providerKey}", cancel);
        }

        #endregion

        #region Implementation of IUserLockoutStore<ApplicationUser>

        public async Task<DateTimeOffset?> GetLockoutEndDateAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetLockoutEndDate", user, cancel))
                .Content
                .ReadAsAsync<DateTimeOffset?>(cancel);
        }

        public async Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? endDate, CancellationToken cancel)
        {
            user.LockoutEnd = endDate;
            await PostAsync($"{_serviceAddress}/SetLockoutEndDate",
                new SetLockoutDTO { User = user, LockoutEnd = endDate }, cancel);
        }

        public async Task<int> IncrementAccessFailedCountAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/IncrementAccessFailedCount", user, cancel))
                .Content
                .ReadAsAsync<int>(cancel);
        }

        public async Task ResetAccessFailedCountAsync(ApplicationUser user, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/ResetAccessFailedCont", user, cancel);
        }

        public async Task<int> GetAccessFailedCountAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetAccessFailedCount", user, cancel))
                .Content
                .ReadAsAsync<int>(cancel);
        }

        public async Task<bool> GetLockoutEnabledAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetLockoutEnabled", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel);
        }

        public async Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/SetLockoutEnabled/{enabled}", user, cancel);
        }

        #endregion

        #region Implementation of IUserTwoFactorStore<ApplicationUser>

        public async Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled, CancellationToken cancel)
        {
            user.TwoFactorEnabled = enabled;
            await PostAsync($"{_serviceAddress}/SetTwoFactor/{enabled}", user, cancel);
        }

        public async Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetTwoFactorEnabled", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel);
        }

        #endregion

        #region Implementation of IUserClaimStore<ApplicationUser>

        public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetClaims", user, cancel))
                .Content
                .ReadAsAsync<List<Claim>>(cancel);
        }

        public async Task AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/AddClaims", new AddClaimDTO { User = user, Claims = claims }, cancel);
        }

        public async Task ReplaceClaimAsync(ApplicationUser user, Claim oldClaim, Claim newClaim, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/ReplaceClaim",
                new ReplaceClaimDTO { User = user, OldClaim = oldClaim, NewClaim = newClaim }, cancel);
        }

        public async Task RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancel)
        {
            await PostAsync($"{_serviceAddress}/RemoveClaims", new RemoveClaimDTO { User = user, Claims = claims },
                cancel);
        }

        public async Task<IList<ApplicationUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancel)
        {
            return await (await PostAsync($"{_serviceAddress}/GetUsersForClaim", claim, cancel))
                .Content
                .ReadAsAsync<List<ApplicationUser>>(cancel);
        }

        #endregion
    }
}
