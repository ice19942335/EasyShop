using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EasyShop.Domain.ViewModels.User.UserProfile
{
    public class UserProfileViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Gender { get; set; }

        public int TransactionPercent { get; set; }

        public int ShopsAllowed { get; set; }

        public IFormFile ProfileImage { get; set; }

        public IFormFile ImageToUpload { get; set; }
    }
}
