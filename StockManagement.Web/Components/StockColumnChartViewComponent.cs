using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Interfaces;
using StockManagement.Web.Models;

namespace StockManagement.Web.Components
{
    [ViewComponent]
    public class StockColumnChartViewComponent(IProductService _productService) : ViewComponent
    {
        public IViewComponentResult Invoke(int days)
        {
            var products = _productService.GetStockOfNMostSoldProductsLastNDays(10, days)
                .Select(p => new ProductStockViewModel(p));
            return View(products);
        }
    }
}
