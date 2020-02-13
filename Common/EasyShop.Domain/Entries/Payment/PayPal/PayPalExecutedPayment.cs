using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EasyShop.Domain.Entries.Users;

namespace EasyShop.Domain.Entries.Payment.PayPal
{
    [Table("PayPalExecutedPayments")]
    public class PayPalExecutedPayment
    {
        [Key] public Guid Id { get; set; }

        public Shop.Shop Shop { get; set; }

        public SteamUser SteamUser { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountPaid { get; set; }

        public DateTime PaymentDateTime { get; set; }

        public string ParsedPayPalSdkPayment { get; set; }
    }
}
