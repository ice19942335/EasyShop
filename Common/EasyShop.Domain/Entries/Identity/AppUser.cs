using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.Entries.Tariff;
using Microsoft.AspNetCore.Identity;

namespace EasyShop.Domain.Entries.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        public string ProfileImage { get; set; }


        public int ShopsAllowed { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public double TransactionPercent { get; set; }

        public bool UsingTariff { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalRevenue { get; set; }

        public Dictionary<Tariff.Tariff, DateTime> PurchasedTariffs { get; set; }

        public ICollection<UserTariff> UserTariffs { get; set; }

        public ICollection<UserShop> UserShops { get; set; }
    }
}
