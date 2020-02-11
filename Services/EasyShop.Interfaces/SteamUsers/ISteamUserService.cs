using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Entries.Users;

namespace EasyShop.Interfaces.SteamUsers
{
    public interface ISteamUserService
    {
        SteamUserShop GetSteamUserShopByShopIdAndUserUid(string shopId, string userUid);

        SteamUser GetSteamUserByUid(string uid);

        Task<bool> AddFundsToSteamUserShop(decimal subtotalDecimal, string uid, string shopId);
    }
}
