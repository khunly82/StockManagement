using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Interfaces;
using StockManagement.Domain.Entities;
using StockManagement.Web.Models;

namespace StockManagement.Web.Controllers
{
    [Authorize]
    public class CustomerController(ICustomerService _customerService) : Controller
    {
        [Authorize]
        public ActionResult Index(CustomerIndexViewModel model)
        {
            model.Results = _customerService.FindWithFilters(model.Search, model.Page, model.ItemsPerPage)
                .Select(c => new CustomerViewModel(c));
            model.TotalItems = _customerService.CountWithFilters(model.Search);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            CustomerFormViewModel model = new();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            Customer? customer = _customerService.Find(id);
            if (customer == null)
                return NotFound();
            CustomerFormViewModel model = new (customer);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            try
            {
                _customerService.Delete(id);
            }
            catch (KeyNotFoundException) 
            { 
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
