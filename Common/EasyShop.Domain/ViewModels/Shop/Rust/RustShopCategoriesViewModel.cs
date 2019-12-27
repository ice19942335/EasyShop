using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using EasyShop.Domain.Entries.Base;
using EasyShop.Domain.Entries.Items.RustItems;
using EasyShop.Domain.Enums.Rust;

namespace EasyShop.Domain.ViewModels.Shop.Rust
{
    public class RustShopCategoriesViewModel
    {
        public IEnumerable<RustCategoryViewModel> Categories { get; set; }
    }
}