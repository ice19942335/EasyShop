using System;
using System.ComponentModel.DataAnnotations;
using EasyShop.Domain.ViewModels.Rust.Category;

namespace EasyShop.Domain.ViewModels.Rust.Product
{
    public class RustProductViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[0-9]*\\.[0-9]{2}$", ErrorMessage = "Please enter correct value, example (0.99 or 150.00)")]
        public decimal Price { get; set; }

        [Required]
        public int Amount { get; set; }

        public string ImgUrl { get; set; }

        public string Description { get; set; }

        [RegularExpression("^[0-9]*\\.[0-9]{2}$", ErrorMessage = "Please enter correct value, example (0.99 or 150.00)")]
        public decimal Discount { get; set; }

        public DateTime BlockedTill { get; set; }

        public RustCategoryViewModel CategoryViewModel { get; set; }

        public bool ShowInShop { get; set; }

        public int Index { get; set; }
    }
}