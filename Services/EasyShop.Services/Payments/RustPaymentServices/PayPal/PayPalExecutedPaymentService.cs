using System;
using System.Linq;
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
    public class PayPalExecutedPaymentService : IPayPalExecutedPaymentService
    {
        private readonly EasyShopContext _easyShopContext;
        private readonly ILogger<PayPalExecutedPaymentService> _logger;
        private readonly IRustShopService _rustShopService;
        private readonly ISteamUserService _steamUserService;

        public PayPalExecutedPaymentService(
            EasyShopContext easyShopContext, 
            ILogger<PayPalExecutedPaymentService> logger,
            IRustShopService rustShopService,
            ISteamUserService steamUserService)
        {
            _easyShopContext = easyShopContext;
            _logger = logger;
            _rustShopService = rustShopService;
            _steamUserService = steamUserService;
        }


        public async Task CreateAsync(Payment paymentExecutionResult)
        {
            string subtotalString = paymentExecutionResult.Transactions.First().RelatedResources.First().Sale.Amount.Total;

            try
            {
                Guid id = Guid.Empty;

                do
                {
                    id = Guid.NewGuid();
                } while (_easyShopContext.PayPalExecutedPayments.Any() && _easyShopContext.PayPalExecutedPayments.FirstOrDefault(x => x.Id == id) != null);

                var executedPayment = new PayPalExecutedPayment
                {
                    Id = id,
                    Shop = _rustShopService.GetCurrentRequestShop(),
                    SteamUser = _steamUserService.GetCurrentRequestSteamUser(),
                    AmountPaid = Convert.ToDecimal(subtotalString),
                    PaymentDateTime = DateTime.Now,
                    ParsedPayPalSdkPayment = JsonConvert.SerializeObject(paymentExecutionResult)
                };

                _easyShopContext.PayPalExecutedPayments.Add(executedPayment);
                await _easyShopContext.SaveChangesAsync();

                _logger.LogInformation($"New PayPalExecutedPayment successfully created. ID: {id}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error on PayPalExecutedPayment entry creation.");
            }
        }
    }
}