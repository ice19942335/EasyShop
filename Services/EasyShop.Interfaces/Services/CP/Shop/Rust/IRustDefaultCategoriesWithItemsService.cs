using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Items.RustItems;

namespace EasyShop.Interfaces.Services.CP.Shop.Rust
{
    public interface IRustDefaultCategoriesWithItemsService
    {
        (List<RustCategory>, List<RustProduct>) CreateDefaultCategoriesWithItems(
            AppUser user,
            Domain.Entries.Shop.Shop shop,
            List<RustCategory> defaultCategories,
            List<RustItem> defaultRustItems);
    }
}
