using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.CP.ControlPanel.Tariff
{
    public class TariffManagerViewModel
    {
        public IEnumerable<EditTariffViewModel> Tariffs { get; set; }

        public IEnumerable<TariffOptionDescriptionViewModel> TariffOptionDescriptions { get; set; }
    }
}
