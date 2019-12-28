using System.Collections.Generic;
using EasyShop.Domain.ViewModels.Rust.Category;

namespace EasyShop.Domain.ViewModels.Rust.Shop
{
    public class RustShopCategoriesViewModel
    {
        public IEnumerable<RustCategoryViewModel> Categories { get; set; }
    }
}