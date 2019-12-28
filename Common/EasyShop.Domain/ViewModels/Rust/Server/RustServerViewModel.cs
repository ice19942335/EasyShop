﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyShop.Domain.ViewModels.Rust.Server
{
    public class RustServerViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage = "The server name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name in shop is required")]
        public string NameInShop { get; set; }

        [Required(ErrorMessage = "The index is required, it allows you to sort your servers in Server manager")]
        public int Index { get; set; }

        [Required(ErrorMessage = "The server IP Address is required")]
        [RegularExpression("^[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}$", ErrorMessage = "Please enter a correct value, for example (192.0.2.235)")]
        public string IpAddress { get; set; }

        [Required(ErrorMessage = "The server port is required")]
        [StringLength(maximumLength: 5, MinimumLength = 5, ErrorMessage = "The server port should have 5 digits")]
        public int Port { get; set; }

        public string Map { get; set; }

        [Required]
        public bool ShowInShop { get; set; }


        public Entries.Shop.Shop Shop { get; set; }
    }
}
