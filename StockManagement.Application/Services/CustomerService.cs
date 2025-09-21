using Microsoft.EntityFrameworkCore;
using StockManagement.Application.Exceptions;
using StockManagement.Application.Interfaces;
using StockManagement.Domain.Entities;
using StockManagement.Infrastructure.Database;
using System.Data;

namespace StockManagement.Application.Services
{
    public class CustomerService(StockContext _dbContext) : ICustomerService
    {
        public int CountWithFilters(string? search)
        {
            return _dbContext.Customers.Count(c =>
                search == null || 
                c.FirstName.StartsWith(search) || 
                c.LastName.StartsWith(search) || 
                c.Reference.StartsWith(search)
            );
        }

        public List<Customer> FindWithFilters(string? search, int currentPage, int itemsPerPage)
        {
            return [
                .. _dbContext.Customers
                .Where(c =>
                    search == null ||
                    c.FirstName.StartsWith(search) ||
                    c.LastName.StartsWith(search) ||
                    c.Reference.StartsWith(search)
                )
                .Skip((currentPage - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .AsNoTracking()
            ];
        }

        public void Delete(string id)
        {
            Customer? toDelete = Find(id) 
                ?? throw new EntityNotFoundException();
            _dbContext.Customers.Remove(toDelete);
            _dbContext.SaveChanges();
        }

        public Customer? Find(string id)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.Reference == id && !c.IsDeleted);
        }

        public Customer Create(Customer customer)
        {
            string newRef = CreateRef(customer.LastName, customer.FirstName);
            if (_dbContext.Customers.Any(c => c.Email == customer.Email))
            {
                throw new DuplicateNameException(nameof(customer.Email));
            }
            customer.Reference = newRef;
            customer.IsActive = true;
            var added = _dbContext.Customers.Add(customer).Entity;
            _dbContext.SaveChanges();
            return added;
        }

        private string CreateRef(string lastName, string firstName)
        {
            string firstLetters = (lastName[..2] + firstName[..2]).ToUpper();
            int count = _dbContext.Customers.Count(c => c.Reference.StartsWith(firstLetters));
            string number = $"{count + 1}".PadLeft(4, '0');
            return $"{firstLetters}{number}";
        }

        public Customer Update(Customer customer)
        {
            if (_dbContext.Customers.Any(c => c.Email == customer.Email && c.Reference != customer.Reference))
            {
                throw new DuplicateNameException(nameof(customer.Email));
            }
            var updated = _dbContext.Customers.Update(customer).Entity;
            _dbContext.SaveChanges();
            return updated;
        }
    }
}
