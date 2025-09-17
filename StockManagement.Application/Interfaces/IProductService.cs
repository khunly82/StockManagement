using StockManagement.Domain.Entities;

namespace StockManagement.Application.Interfaces
{
    public interface IProductService
    {
        List<Product> GetStockNMostSoldProductsLastNDays(int nbOfProducts, int days);
    }
}
