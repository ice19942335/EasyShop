﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Dto.PayPal;
using EasyShop.Domain.Enums.PayPal;
using EasyShop.Domain.Settings;
using EasyShop.Domain.ViewModels.RustStore.Payment;
using EasyShop.Interfaces.Payments.RustPaymentServices;
using EasyShop.Interfaces.Payments.RustPaymentServices.PayPal;
using EasyShop.Interfaces.SteamUsers;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PayPal.Core;
using PayPal.v1.Payments;

namespace EasyShop.Services.Payments.RustPaymentServices.PayPal
{
    public class RustStoreSteamUserShopBalanceService : IRustPaymentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<RustStoreSteamUserShopBalanceService> _logger;
        private readonly PayPalSettings _payPalSettings;
        private readonly ISteamUserService _steamUserService;
        private readonly EasyShopContext _easyShopContext;
        private readonly IPayPalCreatedPaymentService _payPalCreatedPaymentService;
        private readonly IPayPalExecutedPaymentService _payPalExecutedPaymentService;
        private readonly MultiTenantContext _multiTenantContext;
        private readonly string _hostString;

        public RustStoreSteamUserShopBalanceService(IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration,
            ILogger<RustStoreSteamUserShopBalanceService> logger,
            PayPalSettings payPalSettings,
            ISteamUserService steamUserService,
            EasyShopContext easyShopContext,
            IPayPalCreatedPaymentService payPalCreatedPaymentService,
            IPayPalExecutedPaymentService payPalExecutedPaymentService)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _payPalSettings = payPalSettings;
            _steamUserService = steamUserService;
            _easyShopContext = easyShopContext;
            _payPalCreatedPaymentService = payPalCreatedPaymentService;
            _payPalExecutedPaymentService = payPalExecutedPaymentService;
            _hostString = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";
            _multiTenantContext = httpContextAccessor.HttpContext.GetMultiTenantContext();
        }

        public async Task<Payment> CreatePaymentAsync(RustStoreTopUpBalanceViewModel model)
        {
            var environment = new SandboxEnvironment(_payPalSettings.ClientId, _payPalSettings.ClientSecret);
            var client = new PayPalHttpClient(environment);

            var payment = new Payment()
            {
                Intent = "sale",
                Transactions = new List<Transaction>()
                    {
                        new Transaction()
                        {
                            Amount = new Amount()
                            {
                                Total = model.MoneyToPay,
                                Currency = "USD"
                            }
                        }
                    },
                RedirectUrls = new RedirectUrls()
                {
                    ReturnUrl = $"{_hostString}/{_multiTenantContext.TenantInfo.Identifier}/payment/ExecutePayment",
                    CancelUrl = $"{_hostString}/{_multiTenantContext.TenantInfo.Identifier}/Store/Store"
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }
            };

            PaymentCreateRequest paymentCreateRequest = new PaymentCreateRequest();
            paymentCreateRequest.RequestBody(payment);

            _logger.LogInformation($"Preparation for payment creation against PayPal API");

            HttpStatusCode responseStatusCode;

            try
            {
                BraintreeHttp.HttpResponse paymentCreateRequestResult = await client.Execute(paymentCreateRequest);

                _logger.LogInformation($"PayPal payment creation result, {nameof(paymentCreateRequestResult)}: {JsonConvert.SerializeObject(paymentCreateRequestResult)}");

                responseStatusCode = paymentCreateRequestResult.StatusCode;

                if (responseStatusCode != HttpStatusCode.Created)
                    return null;

                Payment paymentResult = paymentCreateRequestResult.Result<Payment>();

                await _payPalCreatedPaymentService.CreateAsync(paymentResult);

                return paymentResult;
            }
            catch (BraintreeHttp.HttpException e)
            {
                responseStatusCode = e.StatusCode;
                var debugId = e.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();

                _logger.LogError(e, $"PayPal payment creation: Failed\nDebugId: {debugId}\nStatusCode: {responseStatusCode}");

                return null;
            }
        }

        public async Task<PaymentExecuteResultDto> ExecutePaymentAsync(string paymentId, string token, string payerId)
        {
            var environment = new SandboxEnvironment(_payPalSettings.ClientId, _payPalSettings.ClientSecret);
            var client = new PayPalHttpClient(environment);

            PaymentExecution paymentExecution = new PaymentExecution() { PayerId = payerId };
            PaymentExecution payment = new PaymentExecution() { PayerId = payerId };
            PaymentExecuteRequest request = new PaymentExecuteRequest(paymentId);
            request.RequestBody(payment);

            HttpStatusCode statusCode;
            Payment paymentExecutionResult = null;

            _logger.LogInformation($"Preparation for payment execution against PayPal API");

            try
            {
                BraintreeHttp.HttpResponse response = await client.Execute(request);
                statusCode = response.StatusCode;
                paymentExecutionResult = response.Result<Payment>();

                await _payPalExecutedPaymentService.CreateAsync(paymentExecutionResult);

                _logger.LogInformation($"PayPal payment execution result, {nameof(paymentExecutionResult)}: {JsonConvert.SerializeObject(paymentExecutionResult)}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error on payment execution.");
                return new PaymentExecuteResultDto { State = PaymentExecutionResultEnum.Failed };
            }

            if (paymentExecutionResult.State == "approved")
            {
                var updateSteamUserShopBalanceResult = await AddFundsToSteamUserShopAsync(paymentExecutionResult);

                if (!updateSteamUserShopBalanceResult)
                    return new PaymentExecuteResultDto { State = PaymentExecutionResultEnum.Failed };

                return new PaymentExecuteResultDto
                {
                    State = PaymentExecutionResultEnum.Success,
                    AmountPaid = paymentExecutionResult
                        .Transactions.First()
                        .RelatedResources.First()
                        .Sale.Amount.Details.Subtotal,
                    CurrentBalance = _steamUserService.GetCurrentRequestSteamUserShop().Balance
                };
            }

            return new PaymentExecuteResultDto { State = PaymentExecutionResultEnum.Failed };
        }

        private async Task<bool> AddFundsToSteamUserShopAsync(Payment payment)
        {
            string subtotalString = payment.Transactions.First().RelatedResources.First().Sale.Amount.Total;
            decimal subtotalDecimal = Convert.ToDecimal(subtotalString);

            var steamUserShop = _steamUserService.GetCurrentRequestSteamUserShop();

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
    }
}