using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Enums.Rust;

namespace EasyShop.Domain.ViewModels.Shop.Rust
{
    public class RustEditCategoryViewModel
    {
        public RustCategoryViewModel Category { get; set; }

        public RustEditCategoryResult Status { get; set; } = RustEditCategoryResult.Default;
    }
}
