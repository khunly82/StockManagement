using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Entities;

namespace StockManagement.Infrastructure.Database.Configurations
{
    internal class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.Property(ol => ol.OrderRef).IsUnicode(false).HasMaxLength(10).IsFixedLength();
            builder.Property(ol => ol.ProductRef).IsUnicode(false).HasMaxLength(8).IsFixedLength();
            builder.Property(ol => ol.UnitPrice).HasColumnType("MONEY");

            builder.HasOne(ol => ol.Order).WithMany(o => o.OrderLines).HasForeignKey(o => o.OrderRef);
            builder.HasOne(ol => ol.Product).WithMany(p => p.OrderLines).HasForeignKey(o => o.ProductRef);

            builder.HasQueryFilter(ol => !ol.Product.IsDeleted);
        }
    }
}
