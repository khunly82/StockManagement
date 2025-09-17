namespace StockManagement.Domain.Entities
{
    public class Product
    {
        public string Reference { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public bool Deleted { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; } = null!;
    }
}
