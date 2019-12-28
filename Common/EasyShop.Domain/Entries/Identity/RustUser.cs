using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EasyShop.Domain.Entries.Identity
{
    public class RustUser
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Uid { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalSpent { get; set; }
    }
}
