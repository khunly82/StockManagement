using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Entities;

namespace StockManagement.Infrastructure.Database.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Reference);

            builder.Property(o => o.Reference).IsUnicode(false).HasMaxLength(10).IsFixedLength();
            builder.Property(o => o.CustomerRef).IsUnicode(false).HasMaxLength(8).IsFixedLength();

            builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerRef);

            builder.HasQueryFilter(o => !o.Customer.IsDeleted);
        }
    }
}
