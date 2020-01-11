using System.Collections.Generic;
using EasyShop.Domain.Enums.CP.DashBoard;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.DashBoard
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
            DashBoardStatsPeriodEnum.Over_the_last_year
        };

        public Dictionary<DashBoardStatsUnitEnum, (IEnumerable<string>, IEnumerable<string>, IEnumerable<string>)> Stats { get; set; }
    }
}
