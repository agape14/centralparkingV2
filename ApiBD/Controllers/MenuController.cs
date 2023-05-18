using Microsoft.AspNetCore.Mvc;

namespace ApiBD.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
