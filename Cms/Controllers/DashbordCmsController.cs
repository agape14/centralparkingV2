using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ApiBD.Models;
using System.Security.Cryptography;
using System.Text;
using Cms.Service;
using Cms.ServiceCms;
using ApiBD.Controllers;
using CentralParkingSystem.Services;
using Microsoft.CodeAnalysis.Options;
using System.Text.Json.Serialization;
using System.Text.Json;

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
                    HttpContext.Session.SetInt32("IdUsuario",(Int32) usuario.Id);
                    HttpContext.Session.SetString("UsuarioName", usuario.Name);
                    HttpContext.Session.SetInt32("UsuarioRol", (Int32) usuario.RolId);
                    ViewData["result"] = "1";
              
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



        public async Task<IActionResult> Inicio()
        {
            int usuarioRol = HttpContext.Session.GetInt32("UsuarioRol") ?? 0;
            var usuario = new UsuarioCmsService(new HttpClient());
            var usuarioLista = await usuario.listarUsuarios();
            int contadorUsuarios = 0;
            if (usuarioLista is ICollection<TbConfUser> usuarioCollection)
            {
                contadorUsuarios = usuarioCollection.Count;
            }

            var contacto = new ContactanoService(new HttpClient());
            var contactoLista = await contacto.ListarContactos();
            int contadorContactos = 0;
            if (contactoLista is ICollection<TbFormContactano> contactoCollection)
            {
                contadorContactos = contactoCollection.Count;
            }

            var servicios = new ServicioCabeceraCmsService(new HttpClient());
            var listaServicios = await servicios.listarServiciosCabecera();
            int contadorServicios = 0;
            int contadorCotizanos = 0;
            if (listaServicios.Count > 0)
            {
                if (listaServicios is ICollection<TbServCabecera> serviciosCollection)
                {
                    contadorServicios = serviciosCollection.Count;
                    int contadorCoti = 0;
                    foreach (var servicio in serviciosCollection)
                    {
                        var cotizano = new CotizanosService(new HttpClient());
                        var cotizanoLista = await cotizano.ListarCotizanos(servicio.Id);

                        if (cotizanoLista is ICollection<TbFormCotizano> cotizanoCollection)
                        {
                            contadorCoti = contadorCoti+ cotizanoCollection.Count;
                        }
                    }
                    contadorCotizanos = contadorCoti;
                }
                
            }
            int contadorProvedores = 0;
            var proveedor = new ProveedorService(new HttpClient());
            var proveedorLista = await proveedor.ListarProveedores();
            if (proveedorLista is ICollection<TbFormProveedore> proveedorCollection)
            {
                contadorProvedores = proveedorCollection.Count;
            }

            int contadorHojaRecla = 0;
            var hojarecla = new HojaReclamacioneService(new HttpClient());
            var hojareclaLista = await hojarecla.ListarHojaReclamaciones();
            if (hojareclaLista is ICollection<TbFormHojareclamacione> hojareclaCollection)
            {
                contadorHojaRecla = hojareclaCollection.Count;
            }

            int contadorParking = 0;
            var parking = new ParkingCardService(new HttpClient());
            var parkingLista = await parking.ListarParkingCard();
            if (parkingLista is ICollection<TbFormParkingcard> parkingCollection)
            {
                contadorParking = parkingCollection.Count;
            }

            int contadorVacantes = 0;
            var vacante = new PuestoCmsService(new HttpClient());
            var vacanteLista = await vacante.puestoListar();
            if (vacanteLista is ICollection<TbTraPuesto> vacanteCollection)
            {
                contadorVacantes = vacanteCollection.Count;
            }
            var permiso = new PermisoCmsService(new HttpClient());
            var tbConfPermiso = await permiso.listarPermisos();
            var permisosss = tbConfPermiso.Where(per => per.RolId == usuarioRol).ToList();

            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();
            menuLista = menuLista.Where(menu => menu.TipoProyecto == "cms")
                .OrderBy(menu => menu.Id)
                .ToList();

            var option = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true,
            };
            ViewData["countUsuarios"] = contadorUsuarios;
            ViewData["countContactos"] = contadorContactos;
            ViewData["countCotizanos"] = contadorCotizanos;
            ViewData["countProvedores"] = contadorProvedores;
            ViewData["countHojaRecla"] = contadorHojaRecla;
            ViewData["countParking"] = contadorParking;
            ViewData["countVacantes"] = contadorVacantes;
            ViewData["countServicios"] = contadorServicios;
            ViewData["menuLista"] = menuLista;
            HttpContext.Session.SetString("menuLista", JsonSerializer.Serialize(menuLista, option));
            return View();
        }
    }
}
