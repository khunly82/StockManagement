﻿using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
