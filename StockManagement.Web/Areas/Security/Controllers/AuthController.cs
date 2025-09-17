using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockManagement.Application.Interfaces;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Enums;
using StockManagement.Web.Areas.Security.Models;
using System.Security.Authentication;
using System.Security.Claims;

namespace StockManagement.Web.Areas.Security.Controllers
{
    [Area("Security")]
    public class AuthController(IAuthService _authService) : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginFormViewModel());
        }

        [HttpPost]
        public IActionResult Login([FromForm]LoginFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = _authService.Login(model.Email!, model.Password!);

                    ClaimsPrincipal principal = new (
                        new ClaimsIdentity([
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Role, user.Role.ToString()),
                            new Claim(ClaimTypes.Email, user.Email),
                        ], CookieAuthenticationDefaults.AuthenticationScheme)
                    );

                    HttpContext.SignInAsync(principal);

                    TempData["info"] = "Bienvenue";

                    if (user.Role == UserRole.Admin)
                    {
                        return RedirectToAction("Index", "Dashboard", new { Area = "" });
                    }
                    else if (user.Role == UserRole.Seller)
                    {
                        return RedirectToAction("Index", "Customer", new { Area = "" });
                    }
                }
                catch (AuthenticationException)
                {
                    TempData["error"] = "Invalid Credentials";
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
