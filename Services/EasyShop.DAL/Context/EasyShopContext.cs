using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Tariff;
using EasyShop.Domain.ViewModels.ControlPanel.Tariff;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.DAL.Context
{
    public class EasyShopContext : IdentityDbContext<AppUser>
    {
        //Tables
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<TariffOption> TariffOptions { get; set; }
        public DbSet<TariffOptionDescription> TariffOptionsDescriptions { get; set; }
        public DbSet<UserTariff> UserTariffs { get; set; }

        //Constructor
        public EasyShopContext(DbContextOptions<EasyShopContext> options) : base(options) { }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TariffOption -----------------------------------------------------
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
        }
    }
}
