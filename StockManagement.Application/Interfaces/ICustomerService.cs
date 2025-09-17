using StockManagement.Domain.Entities;

namespace StockManagement.Application.Interfaces
{
    public interface ICustomerService
    {
        int CountWithFilters(string? search);
        void Delete(string id);
        Customer? Find(string id);
        List<Customer> FindWithFilters(string? search, int currentPage, int itemsPerPage);
    }
}
