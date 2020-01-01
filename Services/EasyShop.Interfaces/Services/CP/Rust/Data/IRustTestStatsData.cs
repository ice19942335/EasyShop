using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Rust;

namespace EasyShop.Interfaces.Services.CP.Rust.Data
{
    public interface IRustTestStatsData
    {
        Task InitializeDefaultStatsData();

    }
}
