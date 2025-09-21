using StockManagement.Domain.EntityInterfaces;
using StockManagement.Domain.Enums;

namespace StockManagement.Domain.Entities
{
    public class Order : IAuditableEntity
    {
        public string Reference { get; set; } = null!; // yymmddxxxx

        public DateTime Date { get; set; }

        public OrderStatus Status { get; set; }

        public string CustomerRef { get; set; } = null!;

        public Customer Customer { get; set; } = null!;

        public ICollection<OrderLine> OrderLines { get; set; } = null!;


        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
