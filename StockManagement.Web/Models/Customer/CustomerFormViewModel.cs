using StockManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.Web.Models
{
    public class CustomerFormViewModel
    {
        public CustomerFormViewModel()
        {
            
        }
        public CustomerFormViewModel(Customer customer)
        {
            Reference = customer.Reference;
            LastName = customer.LastName;
            FirstName = customer.FirstName;
            Email = customer.Email;
            Phone = customer.Phone;
        }

        public string? Reference { get; init; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public bool Deleted { get; set; }
    }
}
