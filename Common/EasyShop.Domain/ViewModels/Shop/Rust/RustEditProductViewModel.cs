﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using System.Text;
using EasyShop.Domain.Enums.Rust;

namespace EasyShop.Domain.ViewModels.Shop.Rust
{
    public class RustEditProductViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [RegularExpression("^[0-9]*\\.[0-9]{2}$", ErrorMessage = "Please enter correct value, example (0.99 or 150.00)")]
        public decimal Price { get; set; }

        public int Discount { get; set; }

        [Required]
        public int Amount { get; set; }

        [RegularExpression("^[0-9]{1,2}/[0-9]{1,2}/[0-9]{4}$", ErrorMessage = "Please enter correct value, example (1/1/2000 or 11/12/2000), no need zero's")]
        public string BlockedTill { get; set; }

        public string CurrentCategoryName { get; set; }

        public string NewCategoryId { get; set; }

        public IEnumerable<RustCategoryViewModel> RustCategories { get; set; }

        [Required]
        public bool ShowInShop { get; set; }

        public string ImgUrl { get; set; }

        public RustEditProductResult Status { get; set; } = RustEditProductResult.Default;
    }
}
