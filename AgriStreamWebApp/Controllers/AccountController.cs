using Microsoft.AspNetCore.Mvc;
using AgriStreamWebApp.Data;
using AgriStreamWebApp.Models;
using System.Linq;

namespace AgriStreamWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user in the database
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Username && u.PasswordHash == model.Password);

                if (user != null)
                {
                    // Login successful! Send them to the Dashboard
                    return RedirectToAction("Index", "Dashboard");
                }
            }

            // If we reach here, login failed
            ViewBag.Error = "Invalid username or password";
            return View(model);
        }
    }
}