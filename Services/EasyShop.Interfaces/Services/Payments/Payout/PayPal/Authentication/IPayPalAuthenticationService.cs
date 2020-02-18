using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Contracts.CP.PayPal.Authentication.Response;

namespace EasyShop.Interfaces.Services.Payments.Payout.PayPal.Authentication
{
    public interface IPayPalAuthenticationService
    {
        PayPalAuthenticationResponse GetAccessToken();
    }
}
