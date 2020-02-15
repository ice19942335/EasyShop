using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.DashBoard
{
    public class DashBoardTotalRevenueViewModel
    {
        public IEnumerable<decimal> ChartValues { get; set; }

        public IEnumerable<string> ChartDateTimeValues { get; set; }

        public decimal TotalRevenue { get; set; }
    }

    public class DashBoardTotalOrdersViewModel
    {
        public IEnumerable<string> ChartValues { get; set; }

        public IEnumerable<string> ChartDateTimeValues { get; set; }

        public int TotalOrders { get; set; }
    }

    public class DashBoardTotalItemsViewModel
    {
        public IEnumerable<string> ChartValues { get; set; }

        public IEnumerable<string> ChartDateTimeValues { get; set; }

        public int TotalItems { get; set; }
    }

    public class DashBoardTotalBuyersViewModel
    {
        public IEnumerable<string> ChartValues { get; set; }

        public IEnumerable<string> ChartDateTimeValues { get; set; }

        public int TotalBuyers { get; set; }
    }

    public class DashBoardTotalRevenueOverviewViewModel
    {
        public IEnumerable<string> ChartValuesForPeriod { get; set; }

        public IEnumerable<string> ChartValuesForPreviousPeriod { get; set; }
    }
}
