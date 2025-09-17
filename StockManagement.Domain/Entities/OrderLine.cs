namespace StockManagement.Domain.Entities
{
    public class OrderLine
    {
        public int Id { get; set; }

        public string OrderRef { get; set; } = null!;

        public string ProductRef { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public Order Order { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
