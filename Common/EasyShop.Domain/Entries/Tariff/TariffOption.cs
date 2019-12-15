using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Text;

namespace EasyShop.Domain.Entries.Tariff
{
    [Table("TariffOptions")]
    public class TariffOption
    {
        public int TariffOptionDescriptionId { get; set; }
        public TariffOptionDescription TariffOptionDescription { get; set; }


        public int TariffId { get; set; }
        public Tariff Tariff { get; set; }
    }
}
