using ApiBD.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using CentralParkingSystem.Services;
using CentralParkingSystem.Models;

namespace CentralParkingSystem.Controllers;

public class HomeController : Controller
{
    

    public async Task<IActionResult> Index()
    {
        var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await entidad.ListarEntidades();


        var redSocial = new RedesSocialesService(new HttpClient());
        var listRedes = await redSocial.ListarRedSociales();


        var menu = new MenusService(new HttpClient());
        var listMenu =await  menu.ListarMenus();

        var subMenu = new MenusService(new HttpClient());
        var listSubMenu = await subMenu.ListarSubMenus();


        var PiePaginaCab = new PiePaginaCabsService(new HttpClient());
        var listPie = await PiePaginaCab.ListarPiePaginasCabs();


        var PieDet = new PiePaginaDetsService(new HttpClient());
        var listPieDet = await PieDet.ListarPiePaginaDets();



        var IServicio = new ServiciosCabsService(new HttpClient());
        var listIServicios = await IServicio.ListarServiciosCabs();


        var ServicioDet = new ServiciosdetsService(new HttpClient());
        var listIServiciodets = await ServicioDet.ListarServiciosdets();



        var option = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true,
        };

        HttpContext.Session.SetString("entidad", JsonSerializer.Serialize(listEntidad, option));
        HttpContext.Session.SetString("redessociales", JsonSerializer.Serialize(listRedes, option));

        HttpContext.Session.SetString("menu", JsonSerializer.Serialize(listMenu, option));
        HttpContext.Session.SetString("submenu", JsonSerializer.Serialize(listSubMenu, option));

        HttpContext.Session.SetString("piepagina", JsonSerializer.Serialize(listPie, option));
        HttpContext.Session.SetString("piepaginadet", JsonSerializer.Serialize(listPieDet, option));

        HttpContext.Session.SetString("iservicios", JsonSerializer.Serialize(listIServicios, option));
        HttpContext.Session.SetString("iserviciosdet", JsonSerializer.Serialize(listIServiciodets, option));



        var instancia = new CaracteristicasService(new HttpClient());
        var caracteristicasLista = await instancia.ListarCaracteristicas();


        var Slide = new SlideService(new HttpClient());
        var listSlide = await Slide.ListarSlide();



        var model = new IndexVM()
        {

            Servicios = listIServicios,
            ServiciosDet =  listIServiciodets,
            SlideCad =  listSlide,
            Valores = caracteristicasLista,
    };

        return View(model);

    }
    public IActionResult Privacy()
    {
        return View();
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public async Task<IActionResult> Nosotros()
    {
        var paginasCab = new PaginasCabsService(new HttpClient());
        var model = new IndexVM()
        {
            PaginaCab = await paginasCab.paginasCabsPorDefault()
        };

        return View(model);
    }

    // ============================ Administracion de estacionamiento ============================
    public IActionResult Adminestacionamiento()
    {
        return View();
    }

    public IActionResult Cotizacionadministracion()
    {
        return View();
    }

    // ============================ Abonados ============================
    public IActionResult Abonados()
    {
        return View();
    }
    public IActionResult Cotizacionabonados()
    {
        return View();
    }

    // ============================ Otros servicios ============================
    public IActionResult Otrosservicios()
    {
        return View();
    }
    //----------------------------------------
    public IActionResult ValetParking()
    {
        return View();
    }
    public IActionResult CotizacionValetParking()
    {
        return View();
    }
    //----------------------------------------
    public IActionResult Eventos()
    {
        return View();
    }
    public IActionResult CotizacionEventos()
    {
        return View();
    }
    //----------------------------------------
    public IActionResult Prevencion()
    {
        return View();
    }
    public IActionResult CotizacionPrevencion()
    {
        return View();
    }
    //----------------------------------------
    public IActionResult Rentabilizacion()
    {
        return View();
    }
    public IActionResult CotizacionRentabilizacion()
    {
        return View();
    }
    //----------------------------------------
    // ============================ Contactanos ============================
    public IActionResult Contactanos()
    {
        return View();
    }
    // ============================ Trabaja con Nosotros ============================
    public async Task<IActionResult> Trabajaconnosotros()
    {
        var puesto = new PuestoService(new HttpClient());
        var model = new IndexVM()
        {
            Puestos = await puesto.ListarPuestos(),
        };

        return View(model);
    }

    public IActionResult Postulacion(int idpostulacion)
    {
        return View();
    }
    // ============================ Proveedores ============================ 
    public IActionResult Proveedores()
    {
        return View();
    }
    // ============================ Hoja Reclamaciones ============================ 
    public IActionResult HojaReclamaciones()
    {
        return View();
    }
}