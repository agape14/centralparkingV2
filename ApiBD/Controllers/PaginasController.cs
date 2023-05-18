using Microsoft.AspNetCore.Mvc;

namespace ApiBD.Controllers
{
    public class PaginasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
