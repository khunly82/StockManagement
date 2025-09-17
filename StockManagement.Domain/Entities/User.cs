using StockManagement.Domain.Enums;

namespace StockManagement.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public UserRole Role { get; set; }
        public byte[] EncodedPassword { get; set; } = null!;
    }
}
