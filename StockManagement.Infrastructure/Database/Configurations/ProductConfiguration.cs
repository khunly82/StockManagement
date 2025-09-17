using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Entities;

namespace StockManagement.Infrastructure.Database.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Reference);

            builder.Property(p => p.Reference).IsFixedLength().IsUnicode(false).HasMaxLength(8);
            builder.Property(p => p.Name).IsUnicode(false).HasMaxLength(100);
            builder.Property(p => p.Description).IsUnicode(true);
            builder.Property(p => p.Price).HasColumnType("MONEY");

            builder.HasData(CreateProducts());
        }

        private IEnumerable<Product> CreateProducts()
        {
            yield return new Product { Reference = "COCA0001", Name = "Coca Cola 33cl", Description = "CAN. 24X33cl", Price = 16.8m, Stock = 1000 };
            yield return new Product { Reference = "COCA0002", Name = "Coca Cola 50cl", Description = "CAN. 24X50cl", Price = 19.92m, Stock = 1000 };
            yield return new Product { Reference = "COCA0003", Name = "Coca Cola 1l", Description = "BOUT. 6X1l", Price = 10.92m, Stock = 1000 };
            yield return new Product { Reference = "FANT0001", Name = "Fanta Orange 33cl", Description = "CAN. 24X33cl", Price = 16.8m, Stock = 1000 };
            yield return new Product { Reference = "FANT0002", Name = "Fanta Citron 33cl", Description = "CAN. 24X33cl", Price = 16.8m, Stock = 1000 };
            yield return new Product { Reference = "FANT0003", Name = "Fanta Orange 50cl", Description = "CAN. 24X50cl", Price = 16.8m, Stock = 1000 };
            yield return new Product { Reference = "FANT0004", Name = "Fanta Citron 50cl", Description = "CAN. 24X50cl", Price = 19.92m, Stock = 1000 };
            yield return new Product { Reference = "JUPI0001", Name = "Jupiler 33cl", Description = "CAN. 24X33cl", Price = 29.04m, Stock = 1000 };
            yield return new Product { Reference = "JUPI0002", Name = "Jupiler 50cl", Description = "CAN. 24X50cl", Price = 35.52m, Stock = 1000 };
            yield return new Product { Reference = "CARL0001", Name = "Carlsberg 33cl", Description = "CAN. 24X33cl", Price = 32.4m, Stock = 1000 };
            yield return new Product { Reference = "CHIM0001", Name = "Chimay Bleue 33cl", Description = "BOUT. 24X33cl", Price = 45.6m, Stock = 1000 };
            yield return new Product { Reference = "CHIM0002", Name = "Chimay Rouge 33cl", Description = "BOUT. 24X33cl", Price = 45.6m, Stock = 1000 };
            yield return new Product { Reference = "CHIM0003", Name = "Chimay Blanche 33cl", Description = "BOUT. 24X33cl", Price = 30.24m, Stock = 1000 };
            yield return new Product { Reference = "NALU0001", Name = "Nalu Vert 25cl", Description = "CAN. 24X25cl", Price = 16.8m, Stock = 1000 };
            yield return new Product { Reference = "EVIA0001", Name = "Evian 1l", Description = "BOUT. 8X1l", Price = 8.96m, Stock = 1000 };
            yield return new Product { Reference = "EVIA0002", Name = "Evian 50cl", Description = "BOUT. 24X50cl", Price = 5.6m, Stock = 1000 };
            yield return new Product { Reference = "VITT0001", Name = "Vittel 1l", Description = "BOUT. 8X1l", Price = 8.72m, Stock = 1000 };
            yield return new Product { Reference = "VITT0002", Name = "Vittel 50cl", Description = "BOUT. 24X50cl", Price = 5.44m, Stock = 1000 };
            yield return new Product { Reference = "OASI0001", Name = "Oasis Orange 2l", Description = "BOUT. 6X2l", Price = 13.44m, Stock = 1000 };
            yield return new Product { Reference = "OASI0002", Name = "Oasis Tropical 2l", Description = "BOUT. 6X2l", Price = 13.44m, Stock = 1000 };

        }
    }
}
