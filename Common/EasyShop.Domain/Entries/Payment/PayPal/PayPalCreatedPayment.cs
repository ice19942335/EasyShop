using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Users;

namespace EasyShop.Domain.Entries.Payment.PayPal
{
    [Table("PayPalCreatedPayments")]
    public class PayPalCreatedPayment
    {
        [Key] public Guid Id { get; set; }

        public Shop.Shop Shop { get; set; }

        public SteamUser SteamUser { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountToPay { get; set; }

        public DateTime CreationDateTime { get; set; }

        public string ParsedPayPalSdkPayment { get; set; }
    }
}