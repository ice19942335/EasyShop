using System;
using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.CP.User.UserData
{
    public class AppUserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Gender { get; set; }

        public double TransactionPercent { get; set; }

        public int ShopsAllowed { get; set; }

        public string ProfileImage { get; set; }

        public IList<string> Roles { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}
