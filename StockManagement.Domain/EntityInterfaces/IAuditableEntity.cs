namespace StockManagement.Domain.EntityInterfaces
{
    public interface IAuditableEntity
    {
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
    }
}
