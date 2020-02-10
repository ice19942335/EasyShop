using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Interfaces.Payments.RustPaymentServices;
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

        public PaymentController(ILogger<PaymentController> logger, IRustPaymentService rustPaymentService)
        {
            _logger = logger;
            _rustPaymentService = rustPaymentService;
        }

        public async Task<IActionResult> TopUpBalance()
        {
            return View();
        }

        public async Task<IActionResult> CretePayment()
        {
            _logger.LogInformation($"Creating payment against the PayPal API");

            var result = await _rustPaymentService.CreatePaymentAsync(15.26M);

            if (result is null)
                return View("CancelPayment");
            
            _logger.LogInformation($"Payment created successfully: '{result}' from the PayPal API");

            foreach (var link in result.Links)
            {
                if (link.Rel.Equals("approval_url"))
                {
                    _logger.LogInformation($"Found the approval URL: '{link.Href}' from response");
                    return Redirect(link.Href);
                }
            }

            return View("CancelPayment");
        }

        //Variables naming is ugly because of PayPal API making a GET request with these params names. =(
        public async Task<IActionResult> ExecutePayment(string paymentId, string token, string PayerID) 
        {
            var result = await _rustPaymentService.ExecutePaymentAsync(paymentId, token, PayerID);

            if (result is null)
                return View("CancelPayment");

            return View("SuccessPayment"); 
        }


        public IActionResult CancelPayment() => View();

        public IActionResult SuccessPayment() => View();
    }
}