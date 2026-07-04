using System.Data.Entity;

namespace RetailInventoryHub.Data
{
    public class RetailDbContext : DbContext
    {
        public RetailDbContext()
            : base("RetailInventoryHubDB")
        {
            Database.SetInitializer<RetailDbContext>(null);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}