using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.Shop.Rust
{
    public class RustProductsManagerViewModel
    {
        public IEnumerable<RustProductViewModel> Products { get; set; }
    }
}
