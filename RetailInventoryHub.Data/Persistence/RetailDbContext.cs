using Microsoft.EntityFrameworkCore;
using RetailInventoryHub.Entities;

namespace RetailInventoryHub.Persistence;

public class RetailDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=.\SQLEXPRESS;Database=RetailInventoryHubDB;Trusted_Connection=True;TrustServerCertificate=True");
    }
}
