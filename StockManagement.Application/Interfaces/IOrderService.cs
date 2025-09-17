using StockManagement.Domain.Views;

namespace StockManagement.Application.Interfaces
{
    public interface IOrderService
    {
        List<DateStatsView> GetTotalSalesByDateLastNDays(int days);
    }
}