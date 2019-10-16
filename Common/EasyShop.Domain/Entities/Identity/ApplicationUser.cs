﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EasyShop.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public const string AdminUserName = "Administrator@easyshop.com";
        public const string DefaultAdminPassword = "AdminPassword";

        public const string RoleAdmin = "Administrator";
        public const string RoleUser = "User";

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int Gender { get; set; }

        public int TransactionPercent { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        public int ShopsAllowed { get; set; }
    }
}