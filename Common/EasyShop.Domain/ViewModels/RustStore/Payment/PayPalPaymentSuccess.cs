using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.RustStore.Payment
{
    public class PayPalPaymentSuccess
    {
        public decimal CurrentBalance { get; set; }

        public string AmountPaid { get; set; }
    }
}
