using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace EasyShop.Domain.ViewModels.User
{
    public class UserViewModel
    {
        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public IFormFile ProfileImage { get; set; }

        public IFormFile ImageToUpload { get; set; }

        public int ShopsAllowed { get; set; }

        public int PercentageOfTransaction { get; set; }
    }
}
