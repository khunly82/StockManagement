using StockManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.Web.Models
{
    public class CustomerViewModel
    {
        [Display(Name = "Référence")]
        public string Reference { get; set; } = null!;
        [Display(Name = "Nom")]
        public string LastName { get; set; } = null!;
        [Display(Name = "Prénom")]
        public string FirstName { get; set; } = null!;
        public bool IsActive { get; set; }

        public CustomerViewModel()
        {
            
        }

        public CustomerViewModel(Customer customer)
        {
            Reference = customer.Reference;
            LastName = customer.LastName;
            FirstName = customer.FirstName;
            IsActive = customer.IsActive;
        }
    }
}
