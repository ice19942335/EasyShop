using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Enums.RustStore;

namespace EasyShop.Domain.Dto.RustStore
{
    public class RustStorePurchaseStandardProductResultDto
    {
        public RustStorePurchaseProductResultEnum Status { get; set; }

        public string ErrorMessage { get; set; }

        public int AmountPurchased { get; set; }

        public RustProduct RustProduct { get; set; }
    }
}
