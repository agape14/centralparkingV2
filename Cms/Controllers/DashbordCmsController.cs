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
using Microsoft.AspNetCore.Http;

namespace Cms.Controllers
{
    public class DashbordCmsController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly UsuarioCmsService _usuariocmsService;
        private readonly ContactanoCmsService _contactanoCmsService;
        private readonly ServicioCabeceraCmsService _servicioCabeceraCmsService;
        private readonly CotizanoCmsService _cotizanoCmsService;
        private readonly ProveedorCmsService _proveedorCmsService;
        private readonly HojaReclamacioneCmsService _hojaReclamacioneCmsService;
        private readonly ParkingCardCmsService _parkingCardCmsService;
        private readonly PuestoCmsService _puestoCmsService;
        private readonly PermisoCmsService _permisoCmsService;
        private readonly MenuCmsService _menuCmsService;
        public DashbordCmsController(
            UsuarioService usuarioCService,
            UsuarioCmsService usuarioCmsService,
            ContactanoCmsService contactanoCmsService,
            ServicioCabeceraCmsService servicioCabeceraCmsService,
            CotizanoCmsService cotizanoCmsService,
            ProveedorCmsService proveedorCmsService,
            HojaReclamacioneCmsService hojaReclamacioneCmsService,
            ParkingCardCmsService parkingCardCmsService,
            PuestoCmsService puestoCmsService,
            PermisoCmsService permisoCmsService,
            MenuCmsService menuCmsService
         )
        {
            _usuarioService = usuarioCService;
            _usuariocmsService = usuarioCmsService;
            _contactanoCmsService= contactanoCmsService;
            _servicioCabeceraCmsService=servicioCabeceraCmsService;
            _cotizanoCmsService= cotizanoCmsService;
            _proveedorCmsService= proveedorCmsService;
            _hojaReclamacioneCmsService=hojaReclamacioneCmsService;
            _parkingCardCmsService=parkingCardCmsService;
            _puestoCmsService= puestoCmsService;
            _permisoCmsService = permisoCmsService;
            _menuCmsService= menuCmsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(TbConfUser user)
        {

            //var servicioUsuario = new UsuarioService(new HttpClient());
            
            try
            {

                var usuario = await _usuarioService.validacionUsuario(user);

                if (usuario != null)
                {
                    HttpContext.Session.SetInt32("IdUsuario",(Int32) usuario.Id);
                    HttpContext.Session.SetString("UsuarioName", usuario.Name);
                    HttpContext.Session.SetInt32("UsuarioRol", (Int32) usuario.RolId);
                    ViewData["resultado"] = "1";
                    return RedirectToAction("Inicio", "DashbordCms");
                }
                else
                {
                    ModelState.AddModelError("Campo1", "Se encontraron errores en el formulario.");
                    ViewData["resultado"] = "0";
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
            int idUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0;
            string usuarioName = HttpContext.Session.GetString("UsuarioName") ?? "";
            int usuarioRol = HttpContext.Session.GetInt32("UsuarioRol") ?? 0;

            //var usuario = new UsuarioCmsService(new HttpClient());
            var usuarioLista = await _usuariocmsService.listarUsuarios();
            int contadorUsuarios = 0;
            if (usuarioLista is ICollection<TbConfUser> usuarioCollection)
            {
                contadorUsuarios = usuarioCollection.Count;
            }

            //var contacto = new ContactanoCmsService(new HttpClient());
            var contactoLista = await _contactanoCmsService.ListarContactos();
            int contadorContactos = 0;
            if (contactoLista is ICollection<TbFormContactano> contactoCollection)
            {
                contadorContactos = contactoCollection.Count;
            }

            //var servicios = new ServicioCabeceraCmsService(new HttpClient());
            var listaServicios = await _servicioCabeceraCmsService.listarServiciosCabecera();
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
                        //var cotizano = new CotizanoCmsService(new HttpClient());
                        var cotizanoLista = await _cotizanoCmsService.ListarCotizanos(servicio.Id);

                        if (cotizanoLista is ICollection<TbFormCotizano> cotizanoCollection)
                        {
                            contadorCoti = contadorCoti+ cotizanoCollection.Count;
                        }
                    }
                    contadorCotizanos = contadorCoti;
                }
                
            }
            int contadorProvedores = 0;
            //var proveedor = new ProveedorCmsService(new HttpClient());
            var proveedorLista = await _proveedorCmsService.ListarProveedores();
            if (proveedorLista is ICollection<TbFormProveedore> proveedorCollection)
            {
                contadorProvedores = proveedorCollection.Count;
            }

            int contadorHojaRecla = 0;
            //var hojarecla = new HojaReclamacioneCmsService(new HttpClient());
            var hojareclaLista = await _hojaReclamacioneCmsService.ListarHojaReclamaciones();
            if (hojareclaLista is ICollection<TbFormHojareclamacione> hojareclaCollection)
            {
                contadorHojaRecla = hojareclaCollection.Count;
            }

            int contadorParking = 0;
            //var parking = new ParkingCardCmsService(new HttpClient());
            var parkingLista = await _parkingCardCmsService.ListarParkingCard();
            if (parkingLista is ICollection<TbFormParkingcard> parkingCollection)
            {
                contadorParking = parkingCollection.Count;
            }

            int contadorVacantes = 0;
            //var vacante = new PuestoCmsService(new HttpClient());
            var vacanteLista = await _puestoCmsService.puestoListar();
            if (vacanteLista is ICollection<TbTraPuesto> vacanteCollection)
            {
                contadorVacantes = vacanteCollection.Count;
            }
            //var permiso = new PermisoCmsService(new HttpClient());
            var tbConfPermiso = await _permisoCmsService.listarPermisos();
            var permisosss = tbConfPermiso.Where(per => per.RolId == usuarioRol).ToList();

            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();
            menuLista = menuLista.Where(menu => menu.TipoProyecto == "cms" && permisosss.Any(p => p.MenuId == menu.Id))
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
            HttpContext.Session.SetString("idUsuario", JsonSerializer.Serialize(idUsuario, option));
            HttpContext.Session.SetString("usuarioName", JsonSerializer.Serialize(usuarioName, option));
            HttpContext.Session.SetString("usuarioRol", JsonSerializer.Serialize(usuarioRol, option));

            return View();
        }
    }
}
