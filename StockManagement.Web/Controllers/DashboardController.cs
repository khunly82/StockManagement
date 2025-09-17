using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StockManagement.Web.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index([FromQuery] int days = 30)
        {
            ViewBag.days = days;
            return View();
        }
    }
}
