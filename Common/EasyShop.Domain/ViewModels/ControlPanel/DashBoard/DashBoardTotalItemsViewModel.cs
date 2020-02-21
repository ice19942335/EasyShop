using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.ControlPanel.DashBoard
{
    public class DashBoardTotalItemsViewModel
    {
        public IEnumerable<string> ChartValues { get; set; }

        public IEnumerable<string> ChartLabelValues { get; set; }

        public int TotalItems { get; set; }
    }
}