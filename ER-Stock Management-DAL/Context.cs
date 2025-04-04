﻿using ER_Stock_Management_DataLibrary;
using ER_Stock_Management_DataLibrary.LogDataObjects;
using Microsoft.EntityFrameworkCore;

namespace ER_Stock_Management_DAL
{
    public class Context(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Store> StoresAndProducts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductLogData> ProductLogs { get; set; }
        public DbSet<StoreLogData> StoreLogs { get; set; }
        public DbSet<ProductCategoryLogData> CategoryLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>()
                .HasIndex(x => x.Id)
                .IsUnique();

            builder.Entity<Store>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder.Entity<ProductCategory>()
                .HasIndex(x => x.Id)
                .IsUnique();

            builder.Entity<ProductCategory>()
                .HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
