using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Base;
using EasyShop.Domain.Entries.Base.Interfaces;

namespace EasyShop.Domain.Entries.Tariff
{
    [Table("Tariffs")]
    public class Tariff : BaseEntity, INamedEntity
    {
        /// <summary>Tariff name</summary>
        public string Name { get; set; }

        /// <summary>Tariff price</summary>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        /// <summary>Days active, days that tariff will be active</summary>
        [Required]
        public int DaysActive { get; set; }

        public string Description { get; set; }

        public ICollection<TariffOption> TariffOptions { get; set; } = new List<TariffOption>();

        public ICollection<UserTariff> UserTariffs { get; set; } = new List<UserTariff>();
    }
}
