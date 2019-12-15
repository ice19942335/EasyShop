using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.ControlPanel.Tariff
{
    public class TariffManagerViewModel
    {
        public IEnumerable<EditTariffViewModel> Tariffs { get; set; }

        public IEnumerable<TariffOptionDescriptionViewModel> TariffOptionDescriptions { get; set; }
    }
}
