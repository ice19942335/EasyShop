using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;

namespace EasyShop.Services.Data.FirstRunInitialization.RustShopDataInitialization
{
    public class RustDefaultDataInitialization
    {
        private readonly EasyShopContext _dbContext;

        public RustDefaultDataInitialization(EasyShopContext dbContext) => _dbContext = dbContext; 

        public async Task Initialize()
        {
            if (_dbContext.RustCategories.Any())  
                return;

            await InitializeDefaultCategories();
            await InitializeDefaultItemTypes();
            await InitializeDefaultItems();
        }

        private async Task InitializeDefaultCategories()
        {
            await _dbContext.RustCategories.AddRangeAsync(RustDefaultInitializationData.DefaultRustCategories);
            await _dbContext.SaveChangesAsync();
        }

        private async Task InitializeDefaultItemTypes()
        {
            await _dbContext.RustItemTypes.AddRangeAsync(RustDefaultInitializationData.DefaultRustItemTypes);
            await _dbContext.SaveChangesAsync();
        }

        private async Task InitializeDefaultItems()
        {
            await _dbContext.RustItems.AddRangeAsync(RustDefaultInitializationData.DefaultRustItems);
            await _dbContext.SaveChangesAsync();
        }
    }
}
