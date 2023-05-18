using Microsoft.AspNetCore.Mvc;

namespace ApiBD.Controllers
{
    public class IServiciosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
