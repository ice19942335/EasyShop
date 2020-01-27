using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.DAL.Context
{
    public class RustShopMultiTenantStoreContext : EFCoreStoreDbContext
    {
        public RustShopMultiTenantStoreContext(DbContextOptions<RustShopMultiTenantStoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
