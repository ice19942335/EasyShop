using System;
using System.Collections;
using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.User.UserData
{
    public class ApplicationUserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Gender { get; set; }

        public double TransactionPercent { get; set; }

        public int ShopsAllowed { get; set; }

        public string ProfileImage { get; set; }

        public IList<string> Roles { get; set; }
    }
}
