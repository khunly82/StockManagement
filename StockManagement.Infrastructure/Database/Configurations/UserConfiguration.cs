using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Enums;
using StockManagement.Infrastructure.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagement.Infrastructure.Database.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Email).HasMaxLength(255).IsUnicode(false);

            builder.HasIndex(u => u.Email).IsUnique();

            builder.HasData(CreateUsers());
        }

        private IEnumerable<User> CreateUsers()
        {
            yield return new User { Id = 1, Email = "admin@yopmail.com", Role = UserRole.Admin, EncodedPassword = HashUtils.HashPassword("admin", [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]) };
            yield return new User { Id = 2, Email = "seller@yopmail.com", Role = UserRole.Seller, EncodedPassword = HashUtils.HashPassword("seller", [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1]) };
            yield return new User { Id = 3, Email = "restocker@yopmail.com", Role = UserRole.Seller, EncodedPassword = HashUtils.HashPassword("restocker", [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2]) };
        }
    }
}
