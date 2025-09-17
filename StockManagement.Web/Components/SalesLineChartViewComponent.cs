using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Interfaces;
using StockManagement.Web.Models;

namespace StockManagement.Web.Components
{
    [ViewComponent]
    public class SalesLineChartViewComponent(IOrderService _orderService): ViewComponent
    {
        public IViewComponentResult Invoke(int days)
        {
            var model = _orderService.GetTotalSalesByDateLastNDays(days)
                .Select(d => new DateStatsViewModel(d));
            return View(model);
        }
    }
}
