using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Entities;

namespace StockManagement.Infrastructure.Database.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Reference);

            builder.Property(c => c.Reference).IsUnicode(false).HasMaxLength(8).IsFixedLength();
            builder.Property(c => c.LastName).IsUnicode(false).HasMaxLength(50);
            builder.Property(c => c.FirstName).IsUnicode(false).HasMaxLength(50);
            builder.Property(c => c.Email).IsUnicode(false).HasMaxLength(255);
            builder.Property(c => c.Phone).IsUnicode(false).HasMaxLength(25);
            builder.Property(c => c.Deleted).IsRequired();

            builder.HasIndex(c => c.Email).IsUnique();

            builder.HasData(GetCreateCustomers());
        }

        private IEnumerable<Customer> GetCreateCustomers()
        {
            yield return new Customer
            {
                Reference = "LYKH0001",
                LastName = "Ly",
                FirstName = "Khun",
                Email = "lykhun@gmail.com"
            };
            yield return new Customer { Reference = "LYPI0001", LastName = "Ly", FirstName = "Piv", Email = "piv.ly@bstorm.be" };
            yield return new Customer { Reference = "PEMI0001", LastName = "Person", FirstName = "Mike", Email = "michael.person@cognitic.be" };
            yield return new Customer { Reference = "MOTH0001", LastName = "Morre", FirstName = "Thierry", Email = "tierry.morre@cognitic.be" };
            yield return new Customer { Reference = "COJU0001", LastName = "Coppin", FirstName = "Julien", Email = "julien.coppin@bstorm.be" };
            yield return new Customer { Reference = "COJU0002", LastName = "Courtois", FirstName = "Julie", Email = "julie@courtois.be" };
            yield return new Customer { Reference = "STAU0001", LastName = "Strimelle", FirstName = "Aurélien", Email = "aurelien.strimelle@bstorm.be" };
            yield return new Customer { Reference = "OVFL0001", LastName = "Ovyn", FirstName = "Flavian", Email = "flavian.ovyn@bstorm.be" };
            yield return new Customer { Reference = "LAST0001", LastName = "Laurent", FirstName = "Steve", Email = "steve.laurent@bstorm.be" };
            yield return new Customer { Reference = "BALO0001", LastName = "Baudoux", FirstName = "Loïc", Email = "loic.baudoux@bstorm.be" };
            yield return new Customer { Reference = "PEMI0002", LastName = "Pedro", FirstName = "Michel", Email = "michel@pedro.be" };
            yield return new Customer { Reference = "COJU0003", LastName = "Constant", FirstName = "Jules", Email = "jules@constant.be" };
        }
    }
}
