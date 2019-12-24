using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Base;
using EasyShop.Domain.Entries.Base.Interfaces;

namespace EasyShop.Domain.Entries.Servers
{
    [Table("Servers")]
    public class Server : BaseEntity, INamedEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string NameInShop { get; set; }

        [Required]
        public string IndexInList { get; set; }

        [Required]
        public string IpAddress { get; set; }

        [Required]
        public int Port { get; set; }

        public string Map { get; set; }

        public ICollection<ServerShop> ServerShops { get; set; }
    }
}