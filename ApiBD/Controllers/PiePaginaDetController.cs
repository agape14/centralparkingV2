using Microsoft.AspNetCore.Mvc;

namespace ApiBD.Controllers
{
    public class PiePaginaDetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
