using Microsoft.AspNetCore.Mvc;

namespace MiAspnetProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
