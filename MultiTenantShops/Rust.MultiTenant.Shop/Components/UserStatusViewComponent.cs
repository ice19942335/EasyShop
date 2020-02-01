using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OpenId.Steam;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.ViewModels.RustStore.Store.UserStatus;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rust.MultiTenant.Shop.Extensions;

namespace Rust.MultiTenant.Shop.Components
{
    public class UserStatusViewComponent : ViewComponent
    {
        private readonly EasyShopContext _easyShopContext;
        private readonly AuthenticationScheme[] _authenticationSchemes;

        public UserStatusViewComponent(IHttpContextAccessor httpContextAccessor, EasyShopContext easyShopContext)
        {
            _easyShopContext = easyShopContext;
            _authenticationSchemes = httpContextAccessor.HttpContext.GetExternalProvidersAsync().Result;
        }

        public IViewComponentResult Invoke()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User as ClaimsPrincipal;
                var tenantInfo = HttpContext.GetMultiTenantContext().TenantInfo;
                var userClaims = user?.Claims;
                var uid = userClaims?.FirstOrDefault(xx => xx.Type == SteamAuthenticationConstants.Parameters.UserUid)?.Value;
                var steamUser = _easyShopContext.SteamUsers.FirstOrDefault(x => x.Uid == uid);

                if (steamUser is null)
                    throw new ApplicationException("Steam user not found! User should be added on SteamUserResolverMiddleware stage");

                var userShop = _easyShopContext.SteamUsersShops.First(x =>
                    x.ShopId == Guid.Parse(tenantInfo.Id) && x.SteamUserId == steamUser.Id);

                return View("SignedIn", new RustStoreUserStatusViewModel
                {
                    Balance = userShop.Balance
                });
            }

            return View("SignedOut", new RustStoreUserStatusViewModel
            {
                AuthenticationScheme = _authenticationSchemes.First(x => x.Name == "Steam"),
            });
        }
    }
}
