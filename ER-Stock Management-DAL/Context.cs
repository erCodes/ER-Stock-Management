using ER_Stock_Management_DataLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ER_Stock_Management_DAL
{
    public class Context : DbContext
    {
        public DbSet<Store> StoresAndProducts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=StockManagemenDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Store>()
            //    .HasAlternateKey(x => x.Name);

            //builder.Entity<ProductCategory>()
            //    .HasAlternateKey(x => x.Name);
        }
    }
}
