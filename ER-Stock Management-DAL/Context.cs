using ER_Stock_Management_DataLibrary;
using Microsoft.EntityFrameworkCore;

namespace ER_Stock_Management_DAL
{
    public class Context(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Store> StoresAndProducts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>()
                .HasAlternateKey(x => x.Name);

            builder.Entity<ProductCategory>()
                .HasAlternateKey(x => x.Name);
        }
    }
}
