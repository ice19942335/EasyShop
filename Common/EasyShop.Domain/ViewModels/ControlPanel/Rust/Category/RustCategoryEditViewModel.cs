using EasyShop.Domain.Enums.CP.Rust;

namespace EasyShop.Domain.ViewModels.ControlPanel.Rust.Category
{
    public class RustCategoryEditViewModel
    {
        public RustCategoryViewModel Category { get; set; }

        public RustEditCategoryResult Status { get; set; } = RustEditCategoryResult.Default;
    }
}
