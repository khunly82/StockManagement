using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StockManagement.Domain.Entities;
using StockManagement.Domain.EntityInterfaces;
using StockManagement.Infrastructure.Database.Configurations;

namespace StockManagement.Infrastructure.Database
{
    public class StockContext(DbContextOptions options): DbContext(options)
    {
        public DbSet<Customer> Customers { get; init; }
        public DbSet<Order> Orders { get; init; }
        public DbSet<Product> Products { get; init; }
        public DbSet<OrderLine> OrderLines { get; init; }
        public DbSet<User> Users { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderLineConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public override int SaveChanges()
        {
            HandleSoftDelete();
            UpdateAuditFields();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            HandleSoftDelete();
            UpdateAuditFields();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditFields()
        {
            ChangeTracker.Entries()
                .OfType<EntityEntry<IAuditableEntity>>()
                .Where(entry => 
                    entry.State == EntityState.Added || 
                    entry.State == EntityState.Modified
                ).ToList().ForEach(UpdateAuditFields);
        }

        private void UpdateAuditFields(EntityEntry<IAuditableEntity> entry)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreateDate = DateTime.UtcNow;
            }
            entry.Entity.UpdateDate = DateTime.UtcNow;
        }

        private void HandleSoftDelete()
        {
            ChangeTracker.Entries()
                .OfType<EntityEntry<ISoftDeleteEntity>>()
                .Where(entry =>
                    entry.State == EntityState.Deleted
                ).ToList().ForEach(HandleSoftDelete);
        }

        private void HandleSoftDelete(EntityEntry<ISoftDeleteEntity> entry)
        {
            entry.State = EntityState.Modified;
            entry.Entity.IsDeleted = true;
        }
    }
}
