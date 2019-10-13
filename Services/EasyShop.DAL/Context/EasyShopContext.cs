using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.DAL.Context
{
    public class EasyShopContext : IdentityDbContext<User>
    {


        public EasyShopContext(DbContextOptions<EasyShopContext> options) : base(options) { }

        //Fluent API
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Section>()
        //        .HasMany(section => section.Products)
        //        .WithOne(product => product.Section)
        //        .HasForeignKey(product => product.SectionId);
        //}
    }
}
