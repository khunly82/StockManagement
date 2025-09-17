namespace StockManagement.Web.Models
{
    public class LinkViewModel
    {
        public string Title { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public string Controller { get; set; } = null!;
        public string? Action { get; set; }
        public string? Area { get; set; }
    }
}
