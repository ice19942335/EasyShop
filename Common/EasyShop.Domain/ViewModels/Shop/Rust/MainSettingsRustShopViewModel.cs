using System;
using System.ComponentModel.DataAnnotations;

namespace EasyShop.Domain.ViewModels.Shop.Rust
{
    public class MainSettingsRustShopViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Shop name is required")]
        public string ShopName { get; set; }

        [Required(ErrorMessage = "Shop title is required")]
        public string ShopTitle { get; set; }

        [RegularExpression("^[0-9]*,[0-9]{2}$", ErrorMessage = "Please enter correct value, example (9,99 or 150,00)")]
        public decimal StartBalance { get; set; }

        public Guid Secret { get; set; }
    }
}
