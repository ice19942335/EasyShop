using System;
using EasyShop.Domain.Settings;
using Microsoft.Extensions.Configuration;

namespace EasyShop.Domain.ViewModels.ControlPanel.Rust.Shop
{
    public class RustShopSaleViewModel
    {
        public RustShopSaleViewModel(int totalFees)
        {
            Profit = Paid - (Paid / 100) * totalFees;
        }

        public DateTime DateTime { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public string UID { get; set; }

        public decimal Paid { get; set; }

        public decimal Profit { get; }
    }
}