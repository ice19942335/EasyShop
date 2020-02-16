using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Contracts.CP.PayPal.Authentication.Response;
using EasyShop.Interfaces.Services.Payments.Payout.PayPal.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServerMonetization.CP.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class PayoutController : Controller
    {
        private readonly IPayPalAuthenticationService _payPalAuthenticationService;

        public PayoutController(IPayPalAuthenticationService payPalAuthenticationService)
        {
            _payPalAuthenticationService = payPalAuthenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            PayPalAuthenticationResponse authResponse = _payPalAuthenticationService.GetAccessToken();

            return View("Index", authResponse);
        }
    }
}