using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyShop.Domain.Entries.Rust
{
    [Table("RustServers")]
    public class RustServer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [Required] 
        public bool ShowInShop { get; set; }

        [Required] 
        public Shop.Shop Shop { get; set; }

        [Required] 
        public RustServerMap ServerMap { get; set; }
    }
}