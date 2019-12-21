using System;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.Items.RustItems
{
    [Table("RustItemsPurchased")]
    public class RustItemsPurchased
    {
        public Guid RustUserId { get; set; }
        public RustUser RustUser { get; set; }


        public Guid RustItemId { get; set; }
        public RustItem RustItem { get; set; }

        public int Amount { get; set; }
    }
}