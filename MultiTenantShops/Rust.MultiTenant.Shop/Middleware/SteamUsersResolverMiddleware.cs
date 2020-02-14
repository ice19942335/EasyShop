using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OpenId.Steam;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Entries.Users;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Interfaces.Services.Rust;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;

namespace Rust.MultiTenant.Shop.Middleware
{
    public class SteamUsersResolverMiddleware
    {
        private readonly RequestDelegate _next;
        private EasyShopContext _easyShopContext;
        private IRustShopService _rustShopService;

        public SteamUsersResolverMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, EasyShopContext easyShopContext, IRustShopService rustShopService)
        {
            _easyShopContext = easyShopContext;
            _rustShopService = rustShopService;

            EasyShop.Domain.Entries.Shop.Shop shop = null;

            try
            {
                var tenantContext = httpContext.GetMultiTenantContext();
                shop = _rustShopService.GetShopById(Guid.Parse(tenantContext.TenantInfo.Id));
            }
            catch
            {
                await _next(httpContext);
            }

            if (httpContext.User.Identity.IsAuthenticated)
            {
                var steamUser = _easyShopContext.SteamUsers.FirstOrDefault(x => x.Uid == GetSteamUserUid(httpContext));

                if (steamUser is null)
                {
                    Guid newSteamUserGuid;

                    do
                    {
                        newSteamUserGuid = Guid.NewGuid();
                    } while (_easyShopContext.SteamUsers.FirstOrDefault(x => x.Id == newSteamUserGuid) != null);

                    var newSteamUser = new SteamUser
                    {
                        Id = newSteamUserGuid,
                        Uid = GetSteamUserUid(httpContext),
                        TotalSpent = 0m
                    };

                    if (shop != null)
                    {
                        var newSteamUserShop = new SteamUserShop
                        {
                            ShopId = shop.Id,
                            Shop = shop,
                            SteamUserId = newSteamUser.Id,
                            SteamUser = newSteamUser,
                            Balance = shop.StartBalance,
                            TotalSpent = 0m
                        };

                        _easyShopContext.SteamUsersShops.Add(newSteamUserShop);
                    }

                    _easyShopContext.SteamUsers.Add(newSteamUser);
                    await _easyShopContext.SaveChangesAsync();
                }
                else
                {
                    var steamUserShop =
                        _easyShopContext.SteamUsersShops.FirstOrDefault(x =>
                            x.SteamUserId == steamUser.Id && x.ShopId == shop.Id);

                    if (steamUserShop is null)
                    {
                        var newSteamUserShop = new SteamUserShop
                        {
                            ShopId = shop.Id,
                            Shop = shop,
                            SteamUserId = steamUser.Id,
                            SteamUser = steamUser,
                            Balance = shop.StartBalance,
                            TotalSpent = 0m
                        };

                        _easyShopContext.SteamUsersShops.Add(newSteamUserShop);
                        await _easyShopContext.SaveChangesAsync();
                    }
                }
            }

            await _next(httpContext);
        }

        private string GetSteamUserUid(HttpContext httpContext)
        {
            var userClaimName = httpContext.User.Claims.FirstOrDefault(x => x.Type == SteamAuthenticationConstants.Parameters.UserUid);
            var userClaimNameArray = userClaimName?.Value.Split("/");
            var steamUserUid = userClaimNameArray?[userClaimNameArray.Length - 1];

            return steamUserUid;
        }
    }
}
