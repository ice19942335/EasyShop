using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Dto.RustStore;
using EasyShop.Domain.ViewModels.RustStore.Store.Order;

namespace EasyShop.Interfaces.Services.Rust.StandardProductPurchase
{
    public interface IRustStoreStandardProductPurchaseService
    {
        Task<RustStorePurchaseStandardProductResultDto> TryPurchaseAsync(RustStoreStandardItemOrder model);
    }
}
