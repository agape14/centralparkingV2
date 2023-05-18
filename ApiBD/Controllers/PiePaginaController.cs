using Microsoft.AspNetCore.Mvc;

namespace ApiBD.Controllers
{
    public class PiePaginaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
