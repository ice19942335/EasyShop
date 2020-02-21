using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EasyShop.Domain.Entries.Tariff;

namespace EasyShop.Domain.ViewModels.ControlPanel.Tariff
{
    public class EditTariffViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Tariff name required.")]
        [MinLength(2, ErrorMessage = "Minimum 2 characters.")]
        [MaxLength(36, ErrorMessage = "Max 36 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price required.")]
        [RegularExpression("^[0-9]*\\.[0-9]{2}$", ErrorMessage = "Please enter a correct value, for example (0.99 or 150.00)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Days active required")]
        public int DaysActive { get; set; }

        public string Description { get; set; }

        public IEnumerable<TariffOptionDescription> AssignedOptions{ get; set; }

        public IEnumerable<TariffOptionDescription> AllOptions { get; set; }
    }
}
