﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using EasyShop.Domain.Settings;
using EasyShop.Interfaces.Payments.RustPaymentServices;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayPal.Core;
using PayPal.v1.Payments;

namespace EasyShop.Services.Payments.RustPaymentServices
{
    public class RustPaymentService : IRustPaymentService
    {
        private readonly ILogger<RustPaymentService> _logger;
        private readonly PayPalSettings _payPalSettings;
        private readonly MultiTenantContext _multiTenantContext;
        private readonly string _hostString;

        public RustPaymentService(IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration,
            ILogger<RustPaymentService> logger,
            PayPalSettings payPalSettings)
        {
            _logger = logger;
            _payPalSettings = payPalSettings;
            _hostString = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";
            _multiTenantContext = httpContextAccessor.HttpContext.GetMultiTenantContext();
        }

        public async Task<Payment> CreatePaymentAsync(decimal amountToPay)
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
                                Total = amountToPay.ToString(CultureInfo.InvariantCulture),
                                Currency = "USD"
                            }
                        }
                    },
                RedirectUrls = new RedirectUrls()
                {
                    ReturnUrl = $"{_hostString}/{_multiTenantContext.TenantInfo.Identifier}/payment/ExecutePayment",
                    CancelUrl = $"{_hostString}/{_multiTenantContext.TenantInfo.Identifier}/payment/CancelPayment"
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }
            };

            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);

            HttpStatusCode responseStatusCode;

            try
            {
                BraintreeHttp.HttpResponse response = await client.Execute(request);
                responseStatusCode = response.StatusCode;

                if (responseStatusCode != HttpStatusCode.Created)
                    return null;

                Payment result = response.Result<Payment>();

                return result;
            }
            catch (BraintreeHttp.HttpException ex)
            {
                responseStatusCode = ex.StatusCode;
                var debugId = ex.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();
                
                _logger.LogError($"PayPal payment creation: Failed\nDebugId: {debugId}\nStatusCode: {responseStatusCode}\nException message: {ex.Message}");

                return null;
            }
        }

        public async Task<Payment> ExecutePaymentAsync(string paymentId, string token, string PayerID)
        {
            var environment = new SandboxEnvironment(_payPalSettings.ClientId, _payPalSettings.ClientSecret);
            var client = new PayPalHttpClient(environment);

            PaymentExecution paymentExecution = new PaymentExecution(){ PayerId = PayerID };

            PaymentExecution payment = new PaymentExecution() { PayerId = PayerID };

            PaymentExecuteRequest request = new PaymentExecuteRequest(paymentId);
            request.RequestBody(payment);

            HttpStatusCode statusCode;
            Payment paymentResult = null;

            try
            {
                BraintreeHttp.HttpResponse response = await client.Execute(request);
                statusCode = response.StatusCode;
                paymentResult = response.Result<Payment>();

                return paymentResult;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}