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
        private readonly IRustStorePaymentService _rustStorePaymentService;
        private readonly EasyShopContext _easyShopContext;

        public PaymentController(ILogger<PaymentController> logger, IRustStorePaymentService rustStorePaymentService, EasyShopContext easyShopContext)
        {
            _logger = logger;
            _rustStorePaymentService = rustStorePaymentService;
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
        public async Task<IActionResult> CretePaymentHandler(RustStoreTopUpBalanceViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                    errors.ForEach(x => ModelState.AddModelError("", x));
                    return View("TopUpBalance", model);
                }

                switch (model.PaymentMethod)
                {
                    case "paypal":
                        return RedirectToAction("PayPalCreatePayment", "Payment", new { amountToPay = model.amountToPay });

                    default: return RedirectToAction("Error404", "Error");
                }
            }

            return RedirectToAction("UserHaveToBeLoggedIn", "Authentication");
        }

        #region PayPal

        public async Task<IActionResult> PayPalCreatePayment(string amountToPay)
        {
            if (User.Identity.IsAuthenticated)
            {
                _logger.LogInformation($"Creating payment against the PayPal API");

                var result = await _rustStorePaymentService.CreatePayPalPaymentAsync(amountToPay);

                if (result.State == PaymentCreationResultEnum.Failed)
                    return RedirectToAction("PaymentFailed", "Payment", new { reason = result.FailedReason });

                _logger.LogInformation($"Payment created successfully: '{JsonConvert.SerializeObject(result.PaymentDetails)}' from the PayPal API");

                foreach (var link in result.PaymentDetails.Links)
                {
                    if (link.Rel.Equals("approval_url"))
                    {
                        _logger.LogInformation($"Found the approval URL: '{link.Href}' from response");
                        return Redirect(link.Href);
                    }
                }

                return RedirectToAction("PaymentFailed", "Payment", new { reason = "Error: 'approval_url' has not been found!" });
            }

            return RedirectToAction("UserHaveToBeLoggedIn", "Authentication");
        }

        //Variables naming is ugly because of PayPal API making a GET request with these params names. =(
        public async Task<IActionResult> ExecutePayPalPayment(string paymentId, string token, string PayerID)
        {
            var result = await _rustStorePaymentService.ExecutePayPalPaymentAsync(paymentId, token, PayerID);

            if (result.State == PaymentExecutionResultEnum.Failed)
                return RedirectToAction("PaymentFailed", new { reason = result.FailedReason });

            return RedirectToAction("PaymentSuccess", new
            {
                currentBalance = result.CurrentBalance,
                amountPaid = result.AmountPaid
            });
        }

        #endregion PayPal

        public IActionResult PaymentSuccess(string currentBalance, string amountPaid) => View(new PayPalPaymentSuccess
        {
            CurrentBalance = Convert.ToDecimal(currentBalance),
            AmountPaid = amountPaid
        });

        public IActionResult PaymentFailed(string reason) => View("PaymentFailed", reason);
    }
}