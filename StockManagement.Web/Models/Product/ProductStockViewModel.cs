using StockManagement.Domain.Entities;

namespace StockManagement.Web.Models
{
    public class ProductStockViewModel(Product product)
    {
        public string Name { get; set; } = product.Name;
        public int Stock { get; set; } = product.Stock;
    }
}
