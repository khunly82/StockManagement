
using StockManagement.Domain.EntityInterfaces;

namespace StockManagement.Domain.Entities
{
    public class Product : IAuditableEntity, ISoftDeleteEntity
    {
        public string Reference { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<OrderLine> OrderLines { get; set; } = null!;

        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
