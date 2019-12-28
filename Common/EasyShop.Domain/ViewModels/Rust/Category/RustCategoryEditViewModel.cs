using EasyShop.Domain.Enums.Rust;

namespace EasyShop.Domain.ViewModels.Rust.Category
{
    public class RustCategoryEditViewModel
    {
        public RustCategoryViewModel Category { get; set; }

        public RustEditCategoryResult Status { get; set; } = RustEditCategoryResult.Default;
    }
}
