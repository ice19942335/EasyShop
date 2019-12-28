using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyShop.Domain.Entries.Servers
{
    [Table("RustServers")]
    public class RustServer
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string NameInShop { get; set; }

        [Required]
        public int Index { get; set; }

        [Required]
        public string IpAddress { get; set; }

        [Required]
        public int Port { get; set; }

        public string Map { get; set; }

        [Required]
        public bool ShowInShop { get; set; }


        public ICollection<RustServerShop> RustServerShops { get; set; }
    }
}