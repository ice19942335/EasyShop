using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EasyShop.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public const string AdminUserName = "Administrator@easyshop.com";
        public const string DefaultAdminPassword = "AdminPassword";

        public const string RoleAdmin = "Administrator";
        public const string RoleUser = "User";

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        public int Gender { get; set; }

        public int ShopsAllowed { get; set; }

        public int PercentageOfTransaction { get; set; }
    }
}
