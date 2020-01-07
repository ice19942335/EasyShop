using System;
using System.ComponentModel.DataAnnotations;
using EasyShop.Domain.Enums.CP.Rust;

namespace EasyShop.Domain.ViewModels.ControlPanel.Rust.Shop
{
    public class RustShopEditMainSettingsViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Shop name is required")]
        public string ShopName { get; set; }

        [Required(ErrorMessage = "Shop title is required")]
        public string ShopTitle { get; set; }

        [RegularExpression("^[0-9]*\\.[0-9]{2}$", ErrorMessage = "Please enter a correct value, for example (0.99 or 150.00)")]
        public decimal StartBalance { get; set; }

        public Guid Secret { get; set; }

        public RustEditMainSettingsResult Status { get; set; } = RustEditMainSettingsResult.Default;
    }
}
