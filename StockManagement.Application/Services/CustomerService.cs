using Microsoft.EntityFrameworkCore;
using StockManagement.Application.Interfaces;
using StockManagement.Domain.Entities;
using StockManagement.Infrastructure.Database;

namespace StockManagement.Application.Services
{
    public class CustomerService(StockContext _dbContext) : ICustomerService
    {
        public int CountWithFilters(string? search)
        {
            return _dbContext.Customers.Count(c =>
                !c.Deleted && (
                    search == null || 
                    c.FirstName.StartsWith(search) || 
                    c.LastName.StartsWith(search) || 
                    c.Reference.StartsWith(search)
                )
            );
        }

        public List<Customer> FindWithFilters(string? search, int currentPage, int itemsPerPage)
        {
            return [
                .. _dbContext.Customers
                .Where(c =>
                    !c.Deleted && (
                        search == null ||
                        c.FirstName.StartsWith(search) ||
                        c.LastName.StartsWith(search) ||
                        c.Reference.StartsWith(search)
                    )
                )
                .Skip((currentPage - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .AsNoTracking()
            ];
        }

        public void Delete(string id)
        {
            Customer? toDelete = Find(id) 
                ?? throw new KeyNotFoundException();
            toDelete.Deleted = true;
            _dbContext.SaveChanges();
        }

        public Customer? Find(string id)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.Reference == id && !c.Deleted);
        }
    }
}
