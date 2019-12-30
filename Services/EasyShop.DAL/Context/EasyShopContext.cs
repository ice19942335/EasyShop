using System;
using System.Collections.Generic;
using EasyShop.Domain.Entries.GameType;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Rust;
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


        public DbSet<RustServer> RustServers { get; set; }
        public DbSet<RustItem> RustItems { get; set; }
        public DbSet<RustItemType> RustItemTypes { get; set; }
        public DbSet<RustProduct> RustUserItems { get; set; }
        public DbSet<RustCategory> RustCategories { get; set; }
        public DbSet<RustPurchasedItem> RustPurchasedItems { get; set; }
        public DbSet<RustServerMap> RustServerMaps { get; set; }

        public DbSet<RustUser> RustUsers { get; set; }


        //Constructor
        public EasyShopContext(DbContextOptions<EasyShopContext> options) : base(options) { }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region ManyToMany

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
            #endregion
        }
    }
}
