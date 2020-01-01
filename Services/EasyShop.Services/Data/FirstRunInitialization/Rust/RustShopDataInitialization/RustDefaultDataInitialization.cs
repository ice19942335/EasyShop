using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.GameType;

namespace EasyShop.Services.Data.FirstRunInitialization.Rust.RustShopDataInitialization
{
    public class RustDefaultDataInitialization
    {
        private readonly EasyShopContext _dbContext;

        public RustDefaultDataInitialization(EasyShopContext dbContext) => _dbContext = dbContext; 

        public async Task Initialize()
        {
            if (_dbContext.RustCategories.Any())
                return;

            try
            {
                await InitializeDefaultCategories();
                await InitializeDefaultItemTypes();
                await InitializeDefaultItems();
                await InitializeDefaultMaps();
                await InitializeGameTypes();
            }
            catch (Exception e)
            {
                throw new ApplicationException($"Error on initializing Rust data. Stacktrace: {e.StackTrace}", e);
            }
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

        private async Task InitializeDefaultMaps()
        {
            await _dbContext.RustServerMaps.AddRangeAsync(RustDefaultInitializationData.DefaultRustServerMaps);
            await _dbContext.SaveChangesAsync();
        }

        public async Task InitializeGameTypes()
        {
            var gameTypes = new List<GameType>
            {
                new GameType
                {
                    Type = "Rust"
                }
            };

            await _dbContext.GameTypes.AddRangeAsync(gameTypes);
            await _dbContext.SaveChangesAsync();
        }
    }
}
