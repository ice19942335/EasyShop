using System.Collections.Generic;
using EasyShop.Domain.Enums.CP.DashBoard;

namespace EasyShop.Domain.ViewModels.ControlPanel.DashBoard
{
    public class DashBoardViewModel
    {
        public DashBoardStatsPeriodEnum StatsPeriod { get; set; } = DashBoardStatsPeriodEnum.Over_the_last_week;

        public List<DashBoardStatsPeriodEnum> StatsPeriodList { get; set; } = new List<DashBoardStatsPeriodEnum>
        {
            DashBoardStatsPeriodEnum.Today,
            DashBoardStatsPeriodEnum.Over_the_last_week,
            DashBoardStatsPeriodEnum.Over_the_last_30_days,
            DashBoardStatsPeriodEnum.Over_the_last_90_days,
            DashBoardStatsPeriodEnum.Over_the_last_180_days,
            DashBoardStatsPeriodEnum.Over_the_last_year,
            DashBoardStatsPeriodEnum.All_time
        };
        

        public DashBoardTotalRevenueViewModel RevenueModel { get; set; }
        public DashBoardTotalOrdersViewModel OrdersModel { get; set; }
        public DashBoardTotalItemsViewModel ItemsModel { get; set; }
        public DashBoardTotalBuyersViewModel BuyersModel { get; set; }
    }
}
