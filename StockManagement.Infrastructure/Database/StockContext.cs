using Microsoft.EntityFrameworkCore;
using StockManagement.Domain.Entities;
using StockManagement.Infrastructure.Database.Configurations;

namespace StockManagement.Infrastructure.Database
{
    public class StockContext(DbContextOptions options): DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderLineConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
