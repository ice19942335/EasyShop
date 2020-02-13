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

        #region SteamUserService

        SteamUser GetCurrentRequestSteamUser();

        #endregion SteamUserService

        #region SteamUserShopService

        SteamUserShop GetSteamUserShopByShopIdAndUserUid(string shopId, string userUid);

        SteamUserShop GetCurrentRequestSteamUserShop();

        #endregion SteamUserShopService

    }
}
