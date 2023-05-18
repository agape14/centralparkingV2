using Microsoft.AspNetCore.Mvc;

namespace ApiBD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
