using Microsoft.AspNetCore.Mvc;

namespace ApiBD.Controllers
{
    public class RolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
