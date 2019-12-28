using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyShop.Domain.ViewModels.Rust.Server
{
    public class RustServerViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string NameInShop { get; set; }

        public int Index { get; set; }

        public string IpAddress { get; set; }

        public int Port { get; set; }

        public string MapName { get; set; }

        public bool ShowInShop { get; set; }
    }
}
