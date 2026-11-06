using Microsoft.AspNetCore.Mvc;

namespace AgriStreamWebApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}