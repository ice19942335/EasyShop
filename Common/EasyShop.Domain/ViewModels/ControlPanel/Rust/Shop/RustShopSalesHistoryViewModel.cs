using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.ControlPanel.Rust.Shop
{
    public class RustShopSalesHistoryViewModel
    {
        public IEnumerable<RustShopSaleViewModel> Sales { get; set; }

        public PageViewModel.PageViewModel Pages { get; set; }
    }
}
