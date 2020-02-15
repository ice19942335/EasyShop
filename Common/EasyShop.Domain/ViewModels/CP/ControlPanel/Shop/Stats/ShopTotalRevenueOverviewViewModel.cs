using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.Shop.Stats
{
    public class ShopTotalRevenueOverviewViewModel
    {
        public IEnumerable<string> ChartValuesForPeriod { get; set; }

        public IEnumerable<string> ChartValuesForPreviousPeriod { get; set; }

        public IEnumerable<string> ChartLabelsValues { get; set; }
    }
}