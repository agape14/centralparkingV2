using Microsoft.AspNetCore.Mvc;

namespace ApiBD.Controllers
{
    public class SlideController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
