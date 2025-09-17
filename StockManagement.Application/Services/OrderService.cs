using Microsoft.EntityFrameworkCore;
using StockManagement.Application.Interfaces;
using StockManagement.Domain.Enums;
using StockManagement.Domain.Views;
using StockManagement.Infrastructure.Database;

namespace StockManagement.Application.Services
{
    public class OrderService(StockContext _dbContext): IOrderService
    {
        public List<DateStatsView> GetTotalSalesByDateLastNDays(int days)
        {
            return [
                .. _dbContext.Orders.Include(o => o.OrderLines)
                .Where(o =>
                    o.Status == OrderStatus.Closed &&
                    o.Date >= DateTime.Now.AddDays(-days)
                ).GroupBy(o => o.Date.Date, o => o.OrderLines.Sum(l => l.UnitPrice * l.Quantity))
                .Select(g => new DateStatsView { 
                    Date = g.Key, 
                    Amount = g.Sum() ?? 0,
                    Count = g.Count(),
                })
                .AsNoTracking()
            ];
        }
    }
}
