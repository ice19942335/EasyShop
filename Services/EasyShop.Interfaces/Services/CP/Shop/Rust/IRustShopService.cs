using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Items.RustItems;
using EasyShop.Domain.ViewModels.Shop.Rust;

namespace EasyShop.Interfaces.Services.CP.Shop.Rust
{
    public interface IRustShopService
    {
        Task<Domain.Entries.Shop.Shop> UpdateShopAsync(MainSettingsRustShopViewModel model);

        Task<IEnumerable<RustCategory>> GetAllAssignedCategoriesByShopIsAsync(Guid shopId);

        int GetAssignedItemsCountToACategoryInShop(Guid categoryId, Guid shopId);
    }
}
