using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.DTO.Identity;
using EasyShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EasyShop.CP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UserStore<ApplicationUser> _userStore;

        public UsersController(EasyShopContext context, ILogger<UsersController> logger)
        {
            _logger = logger;
            _userStore = new UserStore<ApplicationUser>(context)
            {
                AutoSaveChanges = true
            };
        }

        #region Users

        [HttpGet("AllUsers")]
        public async Task<IEnumerable<ApplicationUser>> GetAllUsers() => await _userStore.Users.ToArrayAsync();

        [HttpPost("UserId")]
        public async Task<string> GetUserIdAsync([FromBody] ApplicationUser user) => await _userStore.GetUserIdAsync(user);

        [HttpPost("UserName")]
        public async Task<string> GetUserNameAsync([FromBody] ApplicationUser user) => await _userStore.GetUserNameAsync(user);

        [HttpPost("UserName/{name}")]
        public async Task SetUserNameAsync([FromBody] ApplicationUser user, string name) => await _userStore.SetUserNameAsync(user, name);

        [HttpPost("NormalUserName")]
        public async Task<string> GetNormalizedUserNameAsync([FromBody] ApplicationUser user) => await _userStore.GetNormalizedUserNameAsync(user);

        [HttpPost("NormalUserName/{name}")]
        public Task SetNormalizedUserNameAsync([FromBody] ApplicationUser user, string name) => _userStore.SetNormalizedUserNameAsync(user, name);

        [HttpPost("ApplicationUser")]
        public async Task<bool> CreateAsync([FromBody] ApplicationUser user)
        {
            var result = await _userStore.CreateAsync(user);
            if (result.Succeeded)
                _logger.LogInformation("ApplicationUser {0} created ", user.UserName);
            else
                _logger.LogWarning("Errors on user creation user ID: {0} Errors: {1}",
                    user.UserName, string.Join(",", result.Errors.Select(error => error.Description)));
            return result.Succeeded;
        }

        [HttpPut("ApplicationUser")]
        public async Task<bool> UpdateAsync([FromBody] ApplicationUser user) => (await _userStore.UpdateAsync(user)).Succeeded;

        [HttpPost("ApplicationUser/Delete")]
        public async Task<bool> DeleteAsync([FromBody] ApplicationUser user) => (await _userStore.DeleteAsync(user)).Succeeded;

        [HttpGet("ApplicationUser/Find/{id}")]
        public async Task<ApplicationUser> FindByIdAsync(string id) => await _userStore.FindByIdAsync(id);

        [HttpGet("ApplicationUser/Normal/{name}")]
        public async Task<ApplicationUser> FindByNameAsync(string name) => await _userStore.FindByNameAsync(name);

        #endregion

        #region Roles to users

        [HttpPost("Role/{role}")]
        public async Task AddToRoleAsync([FromBody] ApplicationUser user, string role) => await _userStore.AddToRoleAsync(user, role);

        [HttpPost("Role/Delete/{role}")]
        public async Task RemoveFromRoleAsync([FromBody] ApplicationUser user, string role) => await _userStore.RemoveFromRoleAsync(user, role);

        [HttpPost("Roles")]
        public async Task<IList<string>> GetRolesAsync([FromBody] ApplicationUser user) => await _userStore.GetRolesAsync(user);

        [HttpPost("InRole/{role}")]
        public async Task<bool> IsInRoleAsync([FromBody] ApplicationUser user, string role) => await _userStore.IsInRoleAsync(user, role);

        [HttpGet("UsersInRole/{role}")]
        public async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string role) => await _userStore.GetUsersInRoleAsync(role);

        #endregion

        #region Password managment

        [HttpPost("GetPasswordHash")]
        public async Task<string> GetPasswordHashAsync([FromBody] ApplicationUser user) => await _userStore.GetPasswordHashAsync(user);

        [HttpPost("SetPasswordHash")]
        public async Task<string> SetPasswordHashAsync([FromBody] PasswordHashDTO hash)
        {
            await _userStore.SetPasswordHashAsync(hash.User, hash.Hash);
            return hash.User.PasswordHash;
        }

        [HttpPost("HasPassword")]
        public async Task<bool> HasPasswordAsync([FromBody] ApplicationUser user) => await _userStore.HasPasswordAsync(user);

        #endregion

        #region Claims managment

        [HttpPost("GetClaims")]
        public async Task<IList<Claim>> GetClaimsAsync([FromBody] ApplicationUser user) => await _userStore.GetClaimsAsync(user);

        [HttpPost("AddClaims")]
        public async Task AddClaimsAsync([FromBody] AddClaimDTO claimInfo) => await _userStore.AddClaimsAsync(claimInfo.User, claimInfo.Claims);

        [HttpPost("ReplaceClaim")]
        public async Task ReplaceClaimAsync([FromBody] ReplaceClaimDTO claimInfo) =>
            await _userStore.ReplaceClaimAsync(claimInfo.User, claimInfo.OldClaim, claimInfo.NewClaim);

        [HttpPost("RemoveClaim")]
        public async Task RemoveClaimsAsync([FromBody] RemoveClaimDTO claimInfo) =>
            await _userStore.RemoveClaimsAsync(claimInfo.User, claimInfo.Claims);

        [HttpPost("GetUsersForClaim")]
        public async Task<IList<ApplicationUser>> GetUsersForClaimAsync([FromBody] Claim claim) => await _userStore.GetUsersForClaimAsync(claim);

        #endregion

        #region TwoFactor authentication

        [HttpPost("GetTwoFactorEnabled")]
        public async Task<bool> GetTwoFactorEnabledAsync([FromBody] ApplicationUser user) => await _userStore.GetTwoFactorEnabledAsync(user);

        [HttpPost("SetTwoFactor/{enable}")]
        public async Task SetTwoFactorEnabledAsync([FromBody] ApplicationUser user, bool enable) => await _userStore.SetTwoFactorEnabledAsync(user, enable);

        #endregion

        #region Emails managment

        [HttpPost("GetEmail")]
        public async Task<string> GetEmailAsync([FromBody] ApplicationUser user) => await _userStore.GetEmailAsync(user);

        [HttpPost("SetEmail/{email}")]
        public async Task SetEmailAsync([FromBody] ApplicationUser user, string email) => await _userStore.SetEmailAsync(user, email);

        [HttpPost("GetEmailConfirmed")]
        public async Task<bool> GetEmailConfirmedAsync([FromBody] ApplicationUser user) => await _userStore.GetEmailConfirmedAsync(user);

        [HttpPost("SetEmailConfirmed/{enable}")]
        public async Task SetEmailConfirmedAsync([FromBody] ApplicationUser user, bool enable) => await _userStore.SetEmailConfirmedAsync(user, enable);

        [HttpGet("UserFindByEmail/{email}")]
        public async Task<ApplicationUser> FindByEmailAsync(string email) => await _userStore.FindByEmailAsync(email);

        [HttpPost("GetNormalizedEmail")]
        public async Task<string> GetNormalizedEmailAsync([FromBody] ApplicationUser user) => await _userStore.GetNormalizedEmailAsync(user);

        [HttpPost("SetNormalizedEmail/{email?}")] // Грабли! - если не добавить "?", то при создании пользователя без email невозможно будет выполнить запрос к этому WebAPI
        public async Task SetNormalizedEmailAsync([FromBody] ApplicationUser user, string email) => await _userStore.SetNormalizedEmailAsync(user, email);

        #endregion

        #region Phone numbers managment

        [HttpPost("GetPhoneNumber")]
        public async Task<string> GetPhoneNumberAsync([FromBody] ApplicationUser user) => await _userStore.GetPhoneNumberAsync(user);

        [HttpPost("SetPhoneNumber/{phone}")]
        public async Task SetPhoneNumberAsync([FromBody] ApplicationUser user, string phone) => await _userStore.SetPhoneNumberAsync(user, phone);

        [HttpPost("GetPhoneNumberConfirmed")]
        public async Task<bool> GetPhoneNumberConfirmedAsync([FromBody] ApplicationUser user) => await _userStore.GetPhoneNumberConfirmedAsync(user);

        [HttpPost("SetPhoneNumberConfirmed/{confirmed}")]
        public async Task SetPhoneNumberConfirmedAsync([FromBody] ApplicationUser user, bool confirmed) =>
            await _userStore.SetPhoneNumberConfirmedAsync(user, confirmed);

        #endregion

        #region Login info managment

        [HttpPost("AddLogin")]
        public async Task AddLoginAsync([FromBody] AddLoginDTO login)
        {
            _logger.LogInformation("ApplicationUser {0} successfully logged in", login.User);
            await _userStore.AddLoginAsync(login.User, login.UserLoginInfo);
        }

        [HttpPost("RemoveLogin/{loginProvider}/{ProviderKey}")]
        public async Task RemoveLoginAsync([FromBody] ApplicationUser user, string loginProvider, string providerKey) =>
            await _userStore.RemoveLoginAsync(user, loginProvider, providerKey);

        [HttpPost("GetLogins")]
        public async Task<IList<UserLoginInfo>> GetLoginsAsync([FromBody] ApplicationUser user) => await _userStore.GetLoginsAsync(user);

        [HttpGet("ApplicationUser/FindByLogin/{loginProvider}/{ProviderKey}")]
        public async Task<ApplicationUser> FindByLoginAsync(string loginProvider, string providerKey) =>
            await _userStore.FindByLoginAsync(loginProvider, providerKey);

        #endregion

        #region Lockout managment

        [HttpPost("GetLockoutEndDate")]
        public async Task<DateTimeOffset?> GetLockoutEndDateAsync([FromBody] ApplicationUser user) => await _userStore.GetLockoutEndDateAsync(user);

        [HttpPost("SetLockoutEndDate")]
        public async Task SetLockoutEndDateAsync([FromBody] SetLockoutDTO lockoutInfo) =>
            await _userStore.SetLockoutEndDateAsync(lockoutInfo.User, lockoutInfo.LockoutEnd);

        [HttpPost("IncrementAccessFailedCount")]
        public async Task<int> IncrementAccessFailedCountAsync([FromBody] ApplicationUser user) => await _userStore.IncrementAccessFailedCountAsync(user);

        [HttpPost("ResetAccessFailedCount")]
        public async Task ResetAccessFailedCountAsync([FromBody] ApplicationUser user) => await _userStore.ResetAccessFailedCountAsync(user);

        [HttpPost("GetAccessFailedCount")]
        public async Task<int> GetAccessFailedCountAsync([FromBody] ApplicationUser user) => await _userStore.GetAccessFailedCountAsync(user);

        [HttpPost("GetLockoutEnabled")]
        public async Task<bool> GetLockoutEnabledAsync([FromBody] ApplicationUser user) => await _userStore.GetLockoutEnabledAsync(user);

        [HttpPost("SetLockoutEnabled/{enable}")]
        public async Task SetLockoutEnabledAsync([FromBody] ApplicationUser user, bool enable) => await _userStore.SetLockoutEnabledAsync(user, enable);

        #endregion
    }
}