using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Items.RustItems;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;

namespace EasyShop.Interfaces.Services.CP.Shop.Rust
{
    public interface IRustShopService
    {
        Task<bool> CreateShopAsync(CreateShopViewModel model);

        Task<Domain.Entries.Shop.Shop> UpdateShopAsync(RustShopMainSettingsViewModel model);

        Task<IEnumerable<RustCategory>> GetAllAssignedItemsToShopByIdAsync(Guid shopId);

        int GetAssignedUserItemsCountToACategoryInShop(Guid categoryId, Guid shopId);

        Task<RustCategory> UpdateCategoryAsync(RustShopViewModel model);

        RustCategory GetCategoryById(Guid categoryId);

        Task<bool> DeleteCategory(Guid categoryId);

        Task<bool> DeleteShopAsync(Guid shopId);

        Task<(List<RustCategory>, List<RustUserItem>)> GetDefaultCategoriesWithProducts(AppUser user,
            Domain.Entries.Shop.Shop shop);

        Task<bool> SetDefaultProductsAsync(Domain.Entries.Shop.Shop shop);
    }
}
