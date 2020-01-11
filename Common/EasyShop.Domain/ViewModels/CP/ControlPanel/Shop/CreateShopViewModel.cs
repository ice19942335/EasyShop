using System.ComponentModel.DataAnnotations;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.Shop
{
    public class CreateShopViewModel
    {
        [Required(ErrorMessage = "Shop name is required")]
        public string ShopName { get; set; }

        [Required(ErrorMessage = "Shop title is required")]
        public string ShopTitle { get; set; }

        [RegularExpression("^[0-9]*\\.[0-9]{2}$", ErrorMessage = "Please enter a correct value, for example (0.99 or 150.00)")]
        public decimal StartBalance { get; set; }

        [Required(ErrorMessage = "Game type is required")]
        public string GameType { get; set; }

        public bool AddDefaultItems { get; set; }
    }
}
