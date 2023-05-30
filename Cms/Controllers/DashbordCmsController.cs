using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ApiBD.Models;
using System.Security.Cryptography;
using System.Text;
using Cms.Service;

namespace Cms.Controllers
{
    public class DashbordCmsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(TbConfUser user)
        {

            var servicioUsuario = new UsuarioService(new HttpClient());
            
            try
            {

                var usuario = await servicioUsuario.validacionUsuario(user);

                if (usuario != null)
                {
                    HttpContext.Session.SetString("Usuario", usuario.Username);
                    ViewData["result"] = "1";
                    //return View();
                    return RedirectToAction("Inicio", "DashbordCms");
                }
                else
                {
                    ViewData["result"] = "0";
                    return RedirectToAction("Index", "DashbordCms");
                }

            }
            catch (Exception ex)
            {

                return Content("Ocurrio un error : " + ex.Message);
            }
            
          
        }



        public ActionResult Inicio()
        {
            return View();
        }
    }
}
