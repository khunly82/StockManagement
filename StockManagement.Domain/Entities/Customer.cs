
using StockManagement.Domain.EntityInterfaces;

namespace StockManagement.Domain.Entities
{
    public class Customer : IAuditableEntity, ISoftDeleteEntity
    {
        public string Reference { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Order> Orders { get; set; } = null!;

        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
