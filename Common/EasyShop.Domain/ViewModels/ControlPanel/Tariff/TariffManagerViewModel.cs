using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.ControlPanel.Tariff
{
    public class TariffManagerViewModel
    {
        public IEnumerable<TariffViewModel> Tariffs { get; set; }
    }
}
