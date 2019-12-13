using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EasyShop.Domain.Entries.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EasyShop.Domain.Entries.Tariff
{
    public class TariffOption
    {
        [Key]
        [ForeignKey(nameof(TariffOf))]
        public int TariffId { get; set; }

        public string Description { get; set; }

        public Tariff TariffOf { get; set; }
    }
}
