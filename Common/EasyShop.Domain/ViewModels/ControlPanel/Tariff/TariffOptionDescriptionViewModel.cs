using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entries.Base;
using EasyShop.Domain.Entries.Base.Interfaces;

namespace EasyShop.Domain.ViewModels.ControlPanel.Tariff
{
    public class TariffOptionDescriptionViewModel
    {
        public int? Id { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }
    }
}
