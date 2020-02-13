using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Enums.PayPal;
using PayPal.v1.Payments;

namespace EasyShop.Domain.Dto.PayPal
{
    public class PayPalPaymentCreationResultDto
    {
        public PaymentCreationResultEnum State { get; set; }

        public Payment PaymentDetails { get; set; }

        public string FailedReason { get; set; }
    }
}
