using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EasyShop.Domain.Entries.Base;
using EasyShop.Domain.Entries.Base.Interfaces;

namespace EasyShop.Domain.Entries.Tariff
{
    public class Tariff : BaseEntity, INamedEntity
    {
        /// <summary>Tariff name</summary>
        public string Name { get; set; }

        /// <summary>Tariff price</summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public int DaysActive { get; set; }
    }
}
