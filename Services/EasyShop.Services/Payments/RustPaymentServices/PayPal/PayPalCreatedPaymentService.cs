using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Payment.PayPal;
using EasyShop.Interfaces.Services.CP.Rust.Shop;
using EasyShop.Interfaces.Services.Payments.RustPaymentServices.PayPal;
using EasyShop.Interfaces.Services.Rust;
using EasyShop.Interfaces.SteamUsers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PayPal.v1.Payments;

namespace EasyShop.Services.Payments.RustPaymentServices.PayPal
{
    public class PayPalCreatedPaymentService : IPayPalCreatedPaymentService
    {
        private readonly EasyShopContext _easyShopContext;
        private readonly ISteamUserService _steamUserService;
        private readonly IRustShopService _rustShopService;
        private readonly ILogger<PayPalCreatedPaymentService> _logger;

        public PayPalCreatedPaymentService(
            EasyShopContext easyShopContext, 
            ISteamUserService steamUserService, 
            IRustShopService rustShopService, 
            ILogger<PayPalCreatedPaymentService> logger)
        {
            _easyShopContext = easyShopContext;
            _steamUserService = steamUserService;
            _rustShopService = rustShopService;
            _logger = logger;
        }

        public async Task CreateAsync(Payment paymentCreationResult)
        {
            try
            {
                Guid id = Guid.Empty;

                do
                {
                    id = Guid.NewGuid();
                } while (_easyShopContext.PayPalCreatedPayments.Any() && _easyShopContext.PayPalCreatedPayments.FirstOrDefault(x => x.Id == id) != null);

                var amountToPay = paymentCreationResult.Transactions.First().Amount.Total;

                var createdPayment = new PayPalCreatedPayment
                {
                    Id = id,
                    Shop = _rustShopService.GetCurrentRequestShopInRustStore(),
                    SteamUser = _steamUserService.GetCurrentRequestSteamUser(),
                    AmountToPay = Convert.ToDecimal(amountToPay),
                    CreationDateTime = DateTime.Now,
                    ParsedPayPalSdkPayment = JsonConvert.SerializeObject(paymentCreationResult)
                };

                _easyShopContext.PayPalCreatedPayments.Add(createdPayment);
                await _easyShopContext.SaveChangesAsync();

                _logger.LogInformation($"New PayPalCreatedPayment successfully created. ID: {id}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error on PayPalCreatedPayment entry creation.");
            }
        }
    }
}
