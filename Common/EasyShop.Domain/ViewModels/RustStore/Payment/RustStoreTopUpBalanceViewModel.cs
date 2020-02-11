using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyShop.Domain.ViewModels.RustStore.Payment
{
    public class RustStoreTopUpBalanceViewModel
    {
        [Required]
        [RegularExpression(pattern: @"^[0-9]{2}\.[0-9]{2}$|^[1-9]{1}\.[0-9]{2}$", ErrorMessage = "An error within entered values. Minimal payment is: $1.00")]
        public string MoneyToPay { get; set; }
    }
}
