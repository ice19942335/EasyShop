using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Items.RustItems;
using EasyShop.Domain.Enums;
using EasyShop.Domain.Enums.Rust;
using EasyShop.Domain.ViewModels.Shop;
using EasyShop.Domain.ViewModels.Shop.Rust;

namespace EasyShop.Interfaces.Services.CP.Shop.Rust
{
    public interface IRustShopService
    {
        Task<RustCreateShopResult> CreateShopAsync(CreateShopViewModel model);

        Task<Domain.Entries.Shop.Shop> UpdateShopAsync(RustShopMainSettingsViewModel model);

        IEnumerable<RustCategory> GetAllAssignedCategoriesToShopByShopId(Guid shopId);

        int GetAssignedUserItemsCountToACategoryInShop(Guid categoryId, Guid shopId);

        Task<RustCategory> UpdateCategoryAsync(RustShopViewModel model);

        RustCategory GetCategoryById(Guid categoryId);

        Task<bool> DeleteCategory(Guid categoryId);

        Task<bool> DeleteShopAsync(Guid shopId);

        Task<(List<RustCategory>, List<RustProduct>)> GetDefaultCategoriesWithProducts(AppUser user,
            Domain.Entries.Shop.Shop shop);

        Task<bool> SetDefaultProductsAsync(Domain.Entries.Shop.Shop shop);

        IEnumerable<RustProduct> GetAllAssignedProductsToAShopByShopId(Guid shopId);

        Task<RustProduct> GetProductByIdAsync(Guid productId);

        Task<RustEditProductResult> UpdateRustProductAsync(RustShopViewModel model);
    }
}
