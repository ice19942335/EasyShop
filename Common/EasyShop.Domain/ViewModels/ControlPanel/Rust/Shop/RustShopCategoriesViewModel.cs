using System.Collections.Generic;
using EasyShop.Domain.ViewModels.ControlPanel.Rust.Category;

namespace EasyShop.Domain.ViewModels.ControlPanel.Rust.Shop
{
    public class RustShopCategoriesViewModel
    {
        public IEnumerable<RustCategoryViewModel> Categories { get; set; }
    }
}