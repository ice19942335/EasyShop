using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OpenId.Steam;
using EasyShop.DAL.Context;
using EasyShop.Domain.ViewModels.RustStore.Store.Profile;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Mvc;

namespace Rust.MultiTenant.Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly EasyShopContext _easyShopContext;

        public AccountController(EasyShopContext easyShopContext)
        {
            _easyShopContext = easyShopContext;
        }

        public IActionResult Profile()
        {
            throw new ApplicationException("Test exception");

            if (User.Identity.IsAuthenticated)
            {
                var tenantInfo = HttpContext.GetMultiTenantContext().TenantInfo;
                var userClaims = User.Claims.ToList();

                var userName = userClaims.First(x => x.Type == ClaimTypes.Name).Value;
                var uid = userClaims.First(xx => xx.Type == SteamAuthenticationConstants.Parameters.UserUid).Value;
                var avatar = userClaims.First(x => x.Type == SteamAuthenticationConstants.Parameters.AvatarFull).Value;

                var steamUser = _easyShopContext.SteamUsers.First(x => x.Uid == uid);
                var userShop = _easyShopContext.SteamUsersShops.First(x =>
                    x.ShopId == Guid.Parse(tenantInfo.Id) && x.SteamUserId == steamUser.Id);

                var model = new RustStoreSteamUserViewModel
                {
                    UserName = userName,
                    ImgUrl = avatar,
                    Uid = uid,
                    Balance = userShop.Balance
                };

                return View(model);
            }

            return RedirectToAction("UserHaveToBeLoggedIn", "Authentication");
        }
    }
}