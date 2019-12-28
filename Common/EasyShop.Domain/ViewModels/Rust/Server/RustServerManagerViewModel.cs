using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entries.Rust;

namespace EasyShop.Domain.ViewModels.Rust.Server
{
    public class RustServerManagerViewModel
    {
        public IEnumerable<RustServerViewModel> RustServers { get; set; }
    }
}
