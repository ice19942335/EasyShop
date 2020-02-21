using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EasyShop.Domain.Enums.CP.Rust;
using EasyShop.Domain.ViewModels.ControlPanel.Rust.Category;

namespace EasyShop.Domain.ViewModels.ControlPanel.Rust.Product
{
    public class RustProductEditViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(minimum: 0.00, 100_000_000, ErrorMessage = "Price range: (minimun: 0.00, maximum: 100 000 000)")]
        [RegularExpression("^[0-9]*\\.[0-9]{2}$", ErrorMessage = "Please enter a correct value, for example (0.99 or 150.00)")]
        public decimal Price { get; set; }

        [Range(0, 100, ErrorMessage = "Discount can't be less than 0 percent or more than 100 percent.")]
        public int Discount { get; set; }

        [Required]
        public int Amount { get; set; }

        [RegularExpression("^[0-9]{1,2}/[0-9]{1,2}/[0-9]{4}$", ErrorMessage = "Please enter a correct value, for example (1/1/2000 or 11/12/2000), no need zero's")]
        public string BlockedTill { get; set; }

        public string CurrentCategoryName { get; set; }

        public string NewCategoryId { get; set; }

        public IEnumerable<RustCategoryViewModel> RustCategories { get; set; }

        public bool ShowInShop { get; set; }

        public string ImgUrl { get; set; }

        public RustEditProductResult Status { get; set; } = RustEditProductResult.Default;

        public int Index { get; set; } = 0;
    }
}
