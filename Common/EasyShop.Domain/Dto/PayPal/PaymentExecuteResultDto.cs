using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using EasyShop.Domain.Enums.PayPal;

namespace EasyShop.Domain.Dto.PayPal
{
    public class PaymentExecuteResultDto
    {
        public PaymentExecutionResultEnum State { get; set; }

        public string AmountPaid { get; set; }

        public decimal CurrentBalance { get; set; }

        public string FailedReason { get; set; }
    }
}
