using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Tariff
{
    [Table("UserTariffs")]
    public class UserTariff
    {
        public int TariffId { get; set; }
        public Tariff Tariff { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
