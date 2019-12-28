using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.ViewModels.Rust.Server;

namespace EasyShop.Services.Mappers.ViewModels.Rust
{
    public static class RustServerViewModelMapper
    {
        public static RustServerViewModel CreateRustServerViewModel(this RustServer server)
        {
            var model = server.CopyToViewModel();
            return model;
        }

        private static RustServerViewModel CopyToViewModel(this RustServer server)
        {
            var model = new RustServerViewModel
            {
                Id = server.Id.ToString(),
                Name = server.Name,
                NameInShop = server.NameInShop,
                Index = server.Index,
                IpAddress = server.IpAddress,
                Port = server.Port,
                MapName = server.ServerMap.Name,
                ShowInShop = server.ShowInShop
            };

            return model;
        }
    }
}
