namespace StockManagement.Web.Models
{
    public class CustomerIndexViewModel: IndexViewModelBase<CustomerViewModel>
    {
        public string? Search { get; set; }
        public CustomerIndexViewModel()
        {

        }
        public CustomerIndexViewModel(IEnumerable<CustomerViewModel> results) : base(results)
        {
        }
    }
}
