using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.DashBoard
{
    public class DashBoardTotalRevenueViewModel
    {
        public IEnumerable<decimal> ChartValues { get; set; }

        public IEnumerable<string> ChartLabelValues { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}
