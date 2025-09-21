using StockManagement.Domain.Entities;

namespace StockManagement.Application.Interfaces
{
    public interface IProductService
    {
        List<Product> GetStockOfNMostSoldProductsLastNDays(int nbOfProducts, int days);
    }
}
