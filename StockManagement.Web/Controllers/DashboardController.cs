using IronPdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Web.Guards;

namespace StockManagement.Web.Controllers
{
    public class DashboardController: Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index([FromQuery] int days = 30)
        {
            ViewBag.days = days;
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Print([FromQuery] int days = 30)
        
        {
            ViewBag.days = days;
            return File(new ChromePdfRenderer().RenderUrlAsPdf(Url.Action(
                action: "PdfTemplate",
                controller: "Dashboard",
                values: new { days },
                protocol: Request.Scheme
            )).BinaryData, "application/pdf");
        }

        [LocalOnly]
        public IActionResult PdfTemplate([FromQuery] int days = 30)
        {
            ViewBag.days = days;
            return View();
        }
    }
}
