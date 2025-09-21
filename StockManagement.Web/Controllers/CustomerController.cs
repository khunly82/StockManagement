using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Exceptions;
using StockManagement.Application.Interfaces;
using StockManagement.Domain.Entities;
using StockManagement.Web.Mappers;
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
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(CustomerFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Formulaire invalide";
                return View(model);
            }
            Customer added = _customerService.Create(model.ToEntity());
            TempData["success"] = $"Le client {added.FirstName} {added.LastName} a été créé";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Seller")]
        public ActionResult Edit(string id)
        {
            Customer? customer = _customerService.Find(id);
            if (customer == null)
                return NotFound();
            CustomerFormViewModel model = new (customer);
            return View(model);
        }

        [Authorize(Roles = "Admin,Seller")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(string id, CustomerFormViewModel model)
        {
            Customer? customer = _customerService.Find(id);
            if (customer == null)
                return NotFound();
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Formulaire invalide";
                return View(model);
            }
            Customer updated = _customerService.Update(model.MapTo(customer));
            TempData["success"] = $"Le client {updated.FirstName} {updated.LastName} a été mis à jour";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            try
            {
                _customerService.Delete(id);
            }
            catch (EntityNotFoundException) 
            { 
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
