using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.ControlPanel.Shop
{
    public class ShopsManagerViewModel
    {
        public IEnumerable<Entries.Shop.Shop> Shops { get; set; }
    }
}
