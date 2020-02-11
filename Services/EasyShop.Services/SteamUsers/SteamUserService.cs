using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Entries.Users;
using EasyShop.Interfaces.SteamUsers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EasyShop.Services.SteamUsers
{
    public class SteamUserService : ISteamUserService
    {
        private readonly EasyShopContext _easyShopContext;
        private readonly ILogger<SteamUserService> _logger;

        public SteamUserService(EasyShopContext easyShopContext, ILogger<SteamUserService> logger)
        {
            _easyShopContext = easyShopContext;
            _logger = logger;
        }

        public SteamUserShop GetSteamUserShopByShopIdAndUserUid(string shopId, string userUid)
        {
            var user = _easyShopContext.SteamUsers.First(x => x.Uid == userUid);

            return _easyShopContext.SteamUsersShops.First(x =>
                x.ShopId == Guid.Parse(shopId) && x.SteamUserId == user.Id);
        }

        public SteamUser GetSteamUserByUid(string uid) => _easyShopContext.SteamUsers.First(x => x.Uid == uid);

        public async Task<bool> AddFundsToSteamUserShop(decimal subtotalDecimal, string uid, string shopId)
        {
            try
            {
                var steamUserShop = GetSteamUserShopByShopIdAndUserUid(shopId, uid);

                steamUserShop.Balance += subtotalDecimal;

                _easyShopContext.SteamUsersShops.Update(steamUserShop);

                await _easyShopContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error on updating SteamUserShop\nError: {e.Message}");
            }

            return true;
        }
    }
}
