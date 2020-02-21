using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Settings;
using EasyShop.Domain.ViewModels.ControlPanel.PageViewModel;
using EasyShop.Domain.ViewModels.ControlPanel.Rust.Shop;
using EasyShop.Domain.ViewModels.ControlPanel.Shop.Stats;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Interfaces.Services.Rust;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EasyShop.Services.CP.Rust.Shop
{
    public class RustShopSalesService : IRustShopSalesService
    {
        private readonly EasyShopContext _easyShopContext;
        private readonly IConfiguration _configuration;
        private readonly PayPalSettings _payPalSettings;
        private readonly AppUser _currentRequestAppUser;

        public RustShopSalesService(
            EasyShopContext easyShopContext, 
            UserManager<AppUser> userManager, 
            IHttpContextAccessor httpContextAccessor,
            IRustShopService rustShopService,
            IConfiguration configuration,
            PayPalSettings payPalSettings)
        {
            _easyShopContext = easyShopContext;
            _configuration = configuration;
            _payPalSettings = payPalSettings;

            _currentRequestAppUser =
                userManager.FindByEmailAsync(httpContextAccessor.HttpContext.User.Identity.Name).Result;
        }

        public RustShopSalesHistoryViewModel GetSalesHistory(Guid shopId, int page)
        {
            var shop = _easyShopContext.Shops.FirstOrDefault(x => x.Id == shopId);

            var rustPurchaseStats = _easyShopContext.RustPurchaseStats.Where(x =>
                x.Shop.Id == shop.Id && x.AppUser.Id == _currentRequestAppUser.Id)
                .Include(x => x.AppUser)
                .Include(x => x.RustPurchasedItem)
                .Include(x => x.RustPurchasedItem.SteamUser)
                .Include(x => x.RustPurchasedItem.RustItem)
                .OrderByDescending(x => x.RustPurchasedItem.PurchaseDateTime)
                .ToList();

            int pageSize = 15;
            var purchaseStats = rustPurchaseStats;
            var rustPurchaseStatsLength = rustPurchaseStats.Count;
            var rustPurchaseStatsPage = purchaseStats.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageModel = new PageViewModel(rustPurchaseStatsLength, page, pageSize);

            var totalFees = _payPalSettings.Fees + _configuration.GetValue<int>("ServicePercentPerTransaction");

            var result = new RustShopSalesHistoryViewModel()
            {
                Sales = rustPurchaseStatsPage.Select(x => new RustShopSaleViewModel(totalFees, x.RustPurchasedItem.TotalPaid)
                {
                    DateTime = x.RustPurchasedItem.PurchaseDateTime,
                    Name = x.RustPurchasedItem.RustItem.Name,
                    Amount = x.RustPurchasedItem.AmountOnPurchase,
                    UID = x.RustPurchasedItem.SteamUser.Uid,
                    Paid = x.RustPurchasedItem.TotalPaid
                }),
                Pages = pageModel
            };

            return result;
        }
    }
}
