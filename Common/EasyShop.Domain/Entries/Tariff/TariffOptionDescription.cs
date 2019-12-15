using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Base;

namespace EasyShop.Domain.Entries.Tariff
{
    [Table("TariffOptionDescriptions")]
    public class TariffOptionDescription : NamedEntity
    {
        public string Description { get; set; }

        public ICollection<TariffOption> TariffOptions { get; set; } = new List<TariffOption>();
    }
}
