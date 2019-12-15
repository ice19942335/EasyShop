using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int TransactionPercent { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        public int ShopsAllowed { get; set; }

        public string ProfileImage { get; set; }

        [DataType(DataType.Date)]
        public DateTime? TariffLastUpdate { get; set; }

        public List<UserTariff> UserTariffs { get; set; }
    }
}
