namespace StockManagement.Domain.Entities
{
    public class Customer
    {
        public string Reference { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Phone { get; set; }

        public bool Deleted { get; set; }

        public ICollection<Order> Orders { get; set; } = null!;
    }
}
