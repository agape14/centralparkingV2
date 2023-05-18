using Microsoft.AspNetCore.Mvc;

namespace ApiBD.Controllers
{
    public class PaginasDetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
