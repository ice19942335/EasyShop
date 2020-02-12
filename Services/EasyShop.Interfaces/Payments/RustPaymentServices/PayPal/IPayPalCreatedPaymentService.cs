using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Payment.PayPal;
using PayPal.v1.Payments;

namespace EasyShop.Interfaces.Payments.RustPaymentServices.PayPal
{
    public interface IPayPalCreatedPaymentService
    {
        Task CreateAsync(Payment paymentCreationResult);
    }
}
