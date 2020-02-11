using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNet.Security.OpenId.Steam;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Entries.Users;
using EasyShop.Interfaces.SteamUsers;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EasyShop.Services.SteamUsers
{
    public class SteamUserService : ISteamUserService
    {
        private readonly EasyShopContext _easyShopContext;
        private readonly ILogger<SteamUserService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SteamUserService(EasyShopContext easyShopContext, ILogger<SteamUserService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _easyShopContext = easyShopContext;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        #region SteamUserService

        public SteamUser GetSteamUserByUid(string uid) => _easyShopContext.SteamUsers.First(x => x.Uid == uid);

        #endregion SteamUserService

        #region SteamUserShopService

        public SteamUserShop GetSteamUserShopByShopIdAndUserUid(string shopId, string userUid)
        {
            var user = _easyShopContext.SteamUsers.First(x => x.Uid == userUid);

            return _easyShopContext.SteamUsersShops.First(x =>
                x.ShopId == Guid.Parse(shopId) && x.SteamUserId == user.Id);
        }

        public async Task<bool> AddFundsToSteamUserShop(decimal subtotalDecimal, SteamUserShop steamUserShop)
        {
            try
            {
                _logger.LogInformation($"Preparation for adding funds to steamUserShop with Id: {steamUserShop.ShopId}, balance BEFORE add: {steamUserShop.Balance}");

                steamUserShop.Balance += subtotalDecimal;

                _easyShopContext.SteamUsersShops.Update(steamUserShop);

                await _easyShopContext.SaveChangesAsync();

                _logger.LogInformation($"Funds addition completed steamUserShop with Id: {steamUserShop.ShopId}, balance AFTER add: {steamUserShop.Balance}");

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error on updating SteamUserShop balance.");
            }

            return true;
        }

        public SteamUserShop GetCurrentRequestSteamUserShop()
        {
            var tenantInfo = _httpContextAccessor.HttpContext.GetMultiTenantContext();

            var userClaims = _httpContextAccessor.HttpContext.User.Claims.ToList();
            var uid = userClaims.First(x => x.Type == SteamAuthenticationConstants.Parameters.UserUid).Value;
            var user = _easyShopContext.SteamUsers.First(x => x.Uid == uid);

            return _easyShopContext.SteamUsersShops.First(x => x.SteamUser.Id == user.Id && x.ShopId == Guid.Parse(tenantInfo.TenantInfo.Identifier));
        }

        #endregion SteamUserShopService
    }
}
