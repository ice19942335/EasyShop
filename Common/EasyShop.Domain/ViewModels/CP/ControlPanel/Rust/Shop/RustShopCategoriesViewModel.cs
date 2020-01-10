using System.Collections.Generic;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Category;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Shop
{
    public class RustShopCategoriesViewModel
    {
        public IEnumerable<RustCategoryViewModel> Categories { get; set; }
    }
}