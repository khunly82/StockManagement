using StockManagement.Domain.Entities;
using StockManagement.Web.Models;

namespace StockManagement.Web.Mappers
{
    public static class ToEntityMappers
    {
        public static Customer ToEntity(this CustomerFormViewModel model) 
        {
            return new Customer
            {
                LastName = model.LastName!,
                FirstName = model.FirstName!,
                Email = model.Email!,
                Phone = model.Phone,
                IsActive = model.IsActive,
            };
        }

        public static Customer MapTo(this CustomerFormViewModel model, Customer entity)
        {

            entity.LastName = model.LastName!;
            entity.FirstName = model.FirstName!;
            entity.Email = model.Email!;
            entity.Phone = model.Phone;
            entity.IsActive = model.IsActive;
            return entity;
        }
    }
}
