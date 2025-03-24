using ER_Stock_Management_DataLibrary;
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
    }
}
