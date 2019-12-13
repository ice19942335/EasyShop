using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EasyShop.Domain.Entries.Identity
{
    public class AppUser : IdentityUser
    {
        public const string AdminUserName = "aleksejbirula@gmail.com";
        public const string DefaultAdminPassword = "AdminPassword123";

        public const string RoleAdministrator = "Administrator";
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

        public string ProfileImage { get; set; }
    }
}
