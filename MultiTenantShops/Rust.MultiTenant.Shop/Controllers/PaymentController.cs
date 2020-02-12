using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OpenId.Steam;
using EasyShop.DAL.Context;
using EasyShop.Domain.Enums.PayPal;
using EasyShop.Domain.ViewModels.RustStore.Payment;
using EasyShop.Domain.ViewModels.RustStore.Store;
using EasyShop.Domain.ViewModels.RustStore.Store.Profile;
using EasyShop.Interfaces.Payments.RustPaymentServices;
using EasyShop.Interfaces.Payments.RustPaymentServices.PayPal;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayPal.v1.Payments;

namespace Rust.MultiTenant.Shop.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IRustPaymentService _rustPaymentService;
        private readonly EasyShopContext _easyShopContext;

        public PaymentController(ILogger<PaymentController> logger, IRustPaymentService rustPaymentService, EasyShopContext easyShopContext)
        {
            _logger = logger;
            _rustPaymentService = rustPaymentService;
            _easyShopContext = easyShopContext;
        }

        [HttpGet]
        public IActionResult TopUpBalance()
        {
            if (User.Identity.IsAuthenticated)
                return View(new RustStoreTopUpBalanceViewModel());

            return RedirectToAction("UserHaveToBeLoggedIn", "Authentication");
        }

        [HttpPost]
        public async Task<IActionResult> CretePayment(RustStoreTopUpBalanceViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!ModelState.IsValid)
                {
                    if (!ModelState.IsValid)
                    {
                        var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                        errors.ForEach(x => ModelState.AddModelError("", x));
                        return View("TopUpBalance", model);
                    }
                }

                _logger.LogInformation($"Creating payment against the PayPal API");

                var result = await _rustPaymentService.CreatePaymentAsync(model);

                if (result is null)
                    return RedirectToAction("Store", "Store");

                _logger.LogInformation($"Payment created successfully: '{result}' from the PayPal API");

                foreach (var link in result.Links)
                {
                    if (link.Rel.Equals("approval_url"))
                    {
                        _logger.LogInformation($"Found the approval URL: '{link.Href}' from response");
                        return Redirect(link.Href);
                    }
                }

                return RedirectToAction("Store", "Store");
            }

            return RedirectToAction("UserHaveToBeLoggedIn", "Authentication");
        }

        //Variables naming is ugly because of PayPal API making a GET request with these params names. =(
        public async Task<IActionResult> ExecutePayment(string paymentId, string token, string PayerID)
        {
            var result = await _rustPaymentService.ExecutePaymentAsync(paymentId, token, PayerID);


            if (result.State == PaymentExecutionResultEnum.Failed)
                return RedirectToAction("PaymentExecutionError", new { reason = result.FailedReason });

            return RedirectToAction("SuccessPayment", new
            {
                currentBalance = result.CurrentBalance,
                amountPaid = result.AmountPaid
            });
        }

        public IActionResult SuccessPayment(string currentBalance, string amountPaid) => View(new PayPalPaymentSuccess
        {
            CurrentBalance = Convert.ToDecimal(currentBalance),
            AmountPaid = amountPaid
        });

        public IActionResult PaymentExecutionError(string reason) => View(new PayPalPaymentFailed { Reason = reason });
    }
}