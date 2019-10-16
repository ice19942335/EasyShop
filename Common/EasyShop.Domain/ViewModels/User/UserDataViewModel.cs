using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace EasyShop.Domain.ViewModels.User
{
    public class UserDataViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Gender { get; set; }

        public int TransactionPercent { get; set; }

        public int ShopsAllowed { get; set; }
    }
}
