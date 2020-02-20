using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.ViewModels.ControlPanel.Rust.Shop;
using EasyShop.Domain.ViewModels.ControlPanel.Shop.Stats;

namespace EasyShop.Interfaces.Services.CP.Rust.Shop
{
    public interface IRustShopSalesService
    {
        RustShopSalesHistoryViewModel GetSalesHistory(Guid shopId, int page);
    }
}
