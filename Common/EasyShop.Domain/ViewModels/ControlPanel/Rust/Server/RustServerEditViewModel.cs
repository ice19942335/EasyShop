﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EasyShop.Domain.Enums.CP.Rust;

namespace EasyShop.Domain.ViewModels.ControlPanel.Rust.Server
{
    public class RustServerEditViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "The server name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name in shop is required")]
        public string NameInShop { get; set; }

        [Required(ErrorMessage = "The index is required, it allows you to sort your servers in Server manager")]
        public int Index { get; set; } = 1;

        [Required(ErrorMessage = "The server IP Address is required")]
        [RegularExpression("^[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}$", ErrorMessage = "Please enter a correct value, for example (192.0.2.222)")]
        public string IpAddress { get; set; }

        [Required(ErrorMessage = "The server port is required")]
        //[StringLength(maximumLength: 5, MinimumLength = 5, ErrorMessage = "The server port should have 5 digits")]
        public int Port { get; set; }

        public string MapId { get; set; }

        public string CurrentMap { get; set; }

        public Dictionary<string, string> MapsDict { get; set; }

        public bool ShowInShop { get; set; }

        public RustEditServerResult Status { get; set; } = RustEditServerResult.Default;
        public bool IsNewServer { get; set; }
    }
}
