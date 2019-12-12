using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.Domain.Dto.CP.Account
{
    public class AccountDto
    {
        public IActionResult RedirectToAction { get; set; }

        public IActionResult ReturnToView { get; set; }

        public string LocalRedirect { get; set; }
    }
}
