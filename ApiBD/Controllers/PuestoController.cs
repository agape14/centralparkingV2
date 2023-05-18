using Microsoft.AspNetCore.Mvc;

namespace ApiBD.Controllers
{
    public class PuestoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
