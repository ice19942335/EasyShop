using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.ControlPanel.DashBoard
{
    public class DashBoardTotalRevenueViewModel
    {
        public IEnumerable<decimal> ChartValues { get; set; }

        public IEnumerable<string> ChartLabelValues { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}
