using System;
using System.Collections.Generic;
using EasyShop.Domain.Entries.GameType;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Items.RustItems;
using EasyShop.Domain.Entries.Servers;
using EasyShop.Domain.Entries.Shop;
using EasyShop.Domain.Entries.Tariff;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EasyShop.DAL.Context
{
    public class EasyShopContext : IdentityDbContext<AppUser>
    {
        //Tables
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<TariffOption> TariffOptions { get; set; }
        public DbSet<TariffOptionDescription> TariffOptionsDescriptions { get; set; }
        public DbSet<UserTariff> UserTariffs { get; set; }


        public DbSet<UserShop> UserShops { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<GameType> GameTypes { get; set; }


        public DbSet<ServerShop> ServerShops { get; set; }
        public DbSet<Server> Servers { get; set; }


        public DbSet<RustShopItem> RustShopItems { get; set; }
        public DbSet<RustItem> RustItems { get; set; }
        public DbSet<RustItemType> RustItemTypes { get; set; }
        public DbSet<RustItemCategory> RustItemCategories { get; set; }
        public DbSet<RustCategory> RustCategories { get; set; }
        public DbSet<RustItemsPurchased> RustItemsPurchased { get; set; }

        public DbSet<RustUser> RustUsers { get; set; }


        //Constructor
        public EasyShopContext(DbContextOptions<EasyShopContext> options) : base(options) { }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //AppUser -----------------------------------------------------------
            modelBuilder.Entity<AppUser>(x =>
            {
                x.Property(u => u.PurchasedTariffs);

                x.Property(u => u.PurchasedTariffs)
                    .HasConversion(
                        x => JsonConvert.SerializeObject(x, Formatting.None),
                        s => JsonConvert.DeserializeObject<Dictionary<Tariff, DateTime>>(s))
                    .HasMaxLength(10000);
            });
            //===================================================================

            //TariffOption ------------------------------------------------------
            modelBuilder.Entity<TariffOption>()
                .HasKey(x => new {x.TariffOptionDescriptionId, x.TariffId});

            modelBuilder.Entity<TariffOption>()
                .HasOne(x => x.TariffOptionDescription)
                .WithMany(x => x.TariffOptions)
                .HasForeignKey(x => x.TariffOptionDescriptionId);
            
            modelBuilder.Entity<TariffOption>()
                .HasOne(x => x.Tariff)
                .WithMany(x => x.TariffOptions)
                .HasForeignKey(x => x.TariffId);
            //===================================================================

            //UserTariff --------------------------------------------------------
            modelBuilder.Entity<UserTariff>()
                .HasKey(x => new { x.AppUserId, x.TariffId });

            modelBuilder.Entity<UserTariff>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.UserTariffs)
                .HasForeignKey(x => x.AppUserId);

            modelBuilder.Entity<UserTariff>()
                .HasOne(x => x.Tariff)
                .WithMany(x => x.UserTariffs)
                .HasForeignKey(x => x.TariffId);
            //===================================================================

            //UserShop ----------------------------------------------------------
            modelBuilder.Entity<UserShop>()
                .HasKey(x => new { x.AppUserId, x.ShopId });

            modelBuilder.Entity<UserShop>()
                .HasOne(x => x.Shop)
                .WithMany(x => x.UserShops)
                .HasForeignKey(x => x.ShopId);

            modelBuilder.Entity<UserShop>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.UserShops)
                .HasForeignKey(x => x.AppUserId);
            //===================================================================

            //ServerShops -------------------------------------------------------
            modelBuilder.Entity<ServerShop>()
                .HasKey(x => new { x.ServerId, x.ShopId });

            modelBuilder.Entity<ServerShop>()
                .HasOne(x => x.Server)
                .WithMany(x => x.ServerShops)
                .HasForeignKey(x => x.ServerId);

            modelBuilder.Entity<ServerShop>()
                .HasOne(x => x.Shop)
                .WithMany(x => x.ServerShops)
                .HasForeignKey(x => x.ShopId);
            //===================================================================

            //RustShopItems -----------------------------------------------------
            modelBuilder.Entity<RustShopItem>()
                .HasKey(x => new { x.RustItemId, x.ShopId });

            modelBuilder.Entity<RustShopItem>()
                .HasOne(x => x.RustItem)
                .WithMany(x => x.RustShopItems)
                .HasForeignKey(x => x.RustItemId);

            modelBuilder.Entity<RustShopItem>()
                .HasOne(x => x.Shop)
                .WithMany(x => x.RustShopItems)
                .HasForeignKey(x => x.ShopId);
            //===================================================================

            //RustItemCategories ------------------------------------------------
            modelBuilder.Entity<RustItemCategory>()
                .HasKey(x => new { x.RustItemId, x.RustCategoryId });

            modelBuilder.Entity<RustItemCategory>()
                .HasOne(x => x.RustItem)
                .WithMany(x => x.RustItemCategories)
                .HasForeignKey(x => x.RustItemId);

            modelBuilder.Entity<RustItemCategory>()
                .HasOne(x => x.RustCategory)
                .WithMany(x => x.RustItemCategories)
                .HasForeignKey(x => x.RustCategoryId);
            //===================================================================

            //RustItemsBasket ------------------------------------------------
            modelBuilder.Entity<RustItemsPurchased>()
                .HasKey(x => new { x.RustItemId, x.RustUserId });

            modelBuilder.Entity<RustItemsPurchased>()
                .HasOne(x => x.RustItem)
                .WithMany(x => x.RustItemsPurchased)
                .HasForeignKey(x => x.RustItemId);

            modelBuilder.Entity<RustItemsPurchased>()
                .HasOne(x => x.RustUser)
                .WithMany(x => x.RustItemsPurchased)
                .HasForeignKey(x => x.RustUserId);
            //===================================================================
        }
    }
}
