﻿using System;
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

        Task<IEnumerable<RustCategory>> GetAllAssignedItemsToShopByIdAsync(Guid shopId);

        int GetAssignedUserItemsCountToACategoryInShop(Guid categoryId, Guid shopId);

        Task<RustCategory> UpdateCategoryAsync(RustShopViewModel model);

        RustCategory GetCategoryById(Guid categoryId);

        Task<bool> DeleteCategory(Guid categoryId);

        Task<bool> DeleteShopAsync(Guid shopId);
    }
}
