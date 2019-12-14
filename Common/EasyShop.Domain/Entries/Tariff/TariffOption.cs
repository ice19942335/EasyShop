using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Base;

namespace EasyShop.Domain.Entries.Tariff
{
    [Table("TariffOptions")]
    public class TariffOption : NamedEntity
    {
        public string Description { get; set; }
    }
}
