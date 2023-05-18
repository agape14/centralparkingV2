using Microsoft.AspNetCore.Mvc;

namespace ApiBD.Controllers
{
    public class ProveedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
