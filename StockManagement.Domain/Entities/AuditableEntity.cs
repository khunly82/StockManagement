namespace StockManagement.Domain.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
