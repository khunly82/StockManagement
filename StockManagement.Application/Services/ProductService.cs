using Microsoft.EntityFrameworkCore;
using StockManagement.Application.Interfaces;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Enums;
using StockManagement.Domain.Views;
using StockManagement.Infrastructure.Database;

namespace StockManagement.Application.Services
{
    public class ProductService(StockContext _dbContext): IProductService
    {
        public List<Product> GetStockNMostSoldProductsLastNDays(int nbOfProducts, int days)
        {
            return [
                .. _dbContext.Products
                .Select(p => new { 
                    Product = p, 
                    SoldQuantity = p.OrderLines
                        .Where(l => 
                            l.Order.Status == OrderStatus.Closed && 
                            l.Order.Date >= DateTime.Now.AddDays(-days)
                        ).Sum(l => l.Quantity)
                })
                .OrderByDescending(p => p.SoldQuantity)
                .Take(nbOfProducts)
                .Select(p => p.Product)
                .AsNoTracking()
            ];
        }
    }
}
