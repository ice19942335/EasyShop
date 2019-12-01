using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.Dto.CP.Account
{
    public class AccountDto
    {
        public Dictionary<string, string> RedirectToAction { get; set; }

        public string LocalRedirect { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public bool Success { get; set; }
    }
}
