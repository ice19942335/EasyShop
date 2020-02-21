using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.ControlPanel.Shop.Stats
{
    public class ShopTotalBuyersViewModel
    {
        public IEnumerable<string> ChartValues { get; set; }

        public IEnumerable<string> ChartLabelValues { get; set; }

        public int TotalBuyers { get; set; }
    }
}