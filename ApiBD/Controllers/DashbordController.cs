using Microsoft.AspNetCore.Mvc;

namespace ApiBD.Controllers
{
    public class DashbordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
