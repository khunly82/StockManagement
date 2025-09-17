using StockManagement.Domain.Views;

namespace StockManagement.Web.Models
{
    public class DateStatsViewModel(DateStatsView view)
    {
        public DateTime Date { get; set; } = view.Date;
        public decimal Amount { get; set; } = view.Amount;
        public decimal Count { get; set; } = view.Count;
    }
}
