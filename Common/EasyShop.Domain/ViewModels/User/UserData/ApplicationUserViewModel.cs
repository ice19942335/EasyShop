using System;

namespace EasyShop.Domain.ViewModels.User.UserData
{
    public class ApplicationUserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Gender { get; set; }

        public int TransactionPercent { get; set; }

        public int ShopsAllowed { get; set; }
    }
}
