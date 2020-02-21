using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.ControlPanel.Shop.Stats
{
    public class ShopTotalRevenueViewModel
    {
        public IEnumerable<decimal> ChartValues { get; set; }

        public IEnumerable<string> ChartLabelValues { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}
