using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Entries.Tariff;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.DAL.Context
{
    public class EasyShopContext : IdentityDbContext<AppUser>
    {
        //Tables
        private DbSet<Tariff> Tariffs { get; set; }

        private DbSet<TariffOption> TariffOptions { get; set; }

        //Constructor
        public EasyShopContext(DbContextOptions<EasyShopContext> options) : base(options) { }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
