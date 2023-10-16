using Microsoft.AspNetCore.Mvc;

namespace Cms.Controllers
{
    public class UbigeoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
