using System.ComponentModel.DataAnnotations;

namespace StockManagement.Web.Areas.Security.Models
{
    public class LoginFormViewModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
    }
}
