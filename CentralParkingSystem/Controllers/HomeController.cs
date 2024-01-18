using ApiBD.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using CentralParkingSystem.Services;
using CentralParkingSystem.Models;
using ApiBD.Models;
using MailKit.Net.Smtp;
using MimeKit;
using CentralParkingSystem.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApiBD.Controllers;
using System.Linq;

namespace CentralParkingSystem.Controllers;

public class HomeController : Controller
{
    private readonly ContactanoService _contactanoService;
    private readonly CotizanosService _cotizanosService;
    private readonly HojaReclamacioneService _hojaReclamacioneService;
    private readonly ParkingCardService _parkingCardService;
    private readonly PostulacionService _postulacionService;
    private readonly ProveedorService _proveedorService;
    private readonly ServicioCabeceraService _servicioCabeceraService;
    private readonly ServicioDetalleService _servicioDetalleService;

    private readonly SlideService _slideService;
    private readonly ServiciosCabsService _serviciosCabsservice;
    private readonly ServiciosdetsService _serviciosdetsService;
    private readonly CaracteristicasService _caracteristicasService;
    private readonly ModaleCabeceraService _modaleCabeceraService;
    private readonly ModaleDetalleService _modaleDetalleService;
    private readonly RedesSocialesService _redesSocialesService;
    private readonly MenusService _menusService;
    private readonly PiePaginaCabsService _piePaginaCabsService;
    private readonly PiePaginaDetsService _piePaginaDetsService;
    private readonly EntidadesService _entidadesService;
    private readonly PaginasCabsService _paginasCabsService;
    private readonly PuestoService _puestoService;
    private readonly RubroService _rubroService;

    public HomeController(SlideService slideService, 
        ServiciosCabsService serviciosCabsservice,
        ServiciosdetsService serviciosdetsService,
        CaracteristicasService caracteristicasService,
        EntidadesService entidadesService,
        RedesSocialesService redesSocialesService,
        MenusService menusService,
        PiePaginaCabsService piePaginaCabsService,
        PiePaginaDetsService piePaginaDetsService,
        ModaleCabeceraService modaleCabeceraService,
        ModaleDetalleService modalDetalleservice,
        PaginasCabsService paginasCabsService,
        PuestoService puestoService,
        RubroService rubroService,

        ContactanoService contactanoService,
        CotizanosService cotizanosService,
        HojaReclamacioneService hojaReclamacioneService,
        ParkingCardService parkingCardService,
        PostulacionService postulacionService,
        ProveedorService proveedorService,
        ServicioCabeceraService servicioCabeceraService,
        ServicioDetalleService servicioDetalleService
        )
    {
        _slideService = slideService;
        _serviciosCabsservice = serviciosCabsservice;
        _serviciosdetsService = serviciosdetsService;
        _caracteristicasService = caracteristicasService;
        _entidadesService = entidadesService;
        _redesSocialesService = redesSocialesService;
        _menusService = menusService;
        _piePaginaCabsService = piePaginaCabsService;
        _piePaginaDetsService = piePaginaDetsService;
        _modaleCabeceraService = modaleCabeceraService;
        _modaleDetalleService = modalDetalleservice;
        _paginasCabsService = paginasCabsService;
        _puestoService = puestoService;
        _rubroService=rubroService;
        _contactanoService= contactanoService;
        _cotizanosService= cotizanosService;
        _hojaReclamacioneService = hojaReclamacioneService;
        _parkingCardService=parkingCardService;
        _postulacionService=postulacionService;
        _proveedorService=proveedorService;
        _servicioCabeceraService=servicioCabeceraService;
        _servicioDetalleService=servicioDetalleService;
    }
    public async Task<IActionResult> Index()
    {
        //var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await _entidadesService.ListarEntidades(); //entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }


        //var redSocial = new RedesSocialesService(new HttpClient());
        var listRedes = await _redesSocialesService.ListarRedSociales(); //redSocial.ListarRedSociales();
        if(listRedes.Count == 0)
        {
            RedesSociales objRedesSociales = new RedesSociales();
            listRedes.Add(objRedesSociales);
        }

        //var menu = new MenusService(new HttpClient());
        var listMenu = await  _menusService.ListarMenus();// menu.ListarMenus();
        listMenu = listMenu.Where(item => item.TipoProyecto == "web").ToList();
        if (listMenu.Count == 0)
        {
            Result objResult = new Result();
            listMenu.Add(objResult);
        }

        //var subMenu = new MenusService(new HttpClient());
        var listSubMenu = await _menusService.ListarSubMenus();//subMenu.ListarSubMenus();
        if(listSubMenu.Count == 0)
        {
            SubMenus objSubMenu = new SubMenus();
            listSubMenu.Add(objSubMenu);
        }


        //var PiePaginaCab = new PiePaginaCabsService(new HttpClient());
        var listPie = await _piePaginaCabsService.ListarPiePaginasCabs();// PiePaginaCab.ListarPiePaginasCabs();
        if(listPie.Count == 0)
        {
            PiePaginaCabs objPaginaCab = new PiePaginaCabs();
            listPie.Add(objPaginaCab);
        }


        //var PieDet = new PiePaginaDetsService(new HttpClient());
        var listPieDet = await _piePaginaDetsService.ListarPiePaginaDets();// PieDet.ListarPiePaginaDets();
        

        //var IServicio = new ServiciosCabsService(new HttpClient());
        var listIServicios = await _serviciosCabsservice.ListarServiciosCabs(); //IServicio.ListarServiciosCabs();

        if(listIServicios.Count == 0)
        {
            TbIndServiciocab objIndServicioCab = new TbIndServiciocab();
            listIServicios.Add(objIndServicioCab);
        }


        //var ServicioDet = new ServiciosdetsService(new HttpClient());
        var listIServiciodets = await _serviciosdetsService.ListarServiciosdets(); //ServicioDet.ListarServiciosdets();
        if(listIServiciodets.Count == 0)
        {
            TbIndServiciodet objIndServicioDet = new TbIndServiciodet();
            listIServiciodets.Add(objIndServicioDet);
        }


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



        //var instancia = new CaracteristicasService(new HttpClient());
        var caracteristicasLista = await _caracteristicasService.ListarCaracteristicas(); //instancia.ListarCaracteristicas();
        if (caracteristicasLista.Count == 0)
        {
            TbIndCaracteristica objCaracteristicas = new TbIndCaracteristica();
            caracteristicasLista.Add(objCaracteristicas);
        }

        //var Slide = new SlideService(new HttpClient());
        var listSlide = await  _slideService.ListarSlide();
        if (listSlide.Count == 0)
        {
            TbIndSlidecab objSlide = new TbIndSlidecab();
            listSlide.Add(objSlide);
        }

        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);
        
        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        var model = new IndexVM()
        {

            Servicios = listIServicios,
            ServiciosDet =  listIServiciodets,
            SlideCad =  listSlide,
            Valores = caracteristicasLista,
            ModalCabs2 = modalcab2,
            ListModalDet6= modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9= modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };

        return View(model);

    }
    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ParkingCard(TbFormParkingcard tbFormParkingcard)
    {
        //var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await _entidadesService.ListarEntidades();// entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        //var servicio = new ParkingCardService(new HttpClient());
        if (ModelState.IsValid)
        {
         
            try
            {
                string mensaje = "Notificamos que hemos registrado su solicitud en parkingcardvip.";
                tbFormParkingcard.FecRegistro = DateTime.Now;
                tbFormParkingcard.Notificado = 1;
                await _parkingCardService.crearParkingCardRegistro(tbFormParkingcard);
                enviarEmail(tbFormParkingcard.Correo, mensaje, primerRegistro);
               
            }catch (Exception ex)
            {
                // Registrar un mensaje de error o lanzar una excepción o ambos.
                Console.WriteLine("Ocurrió un error al enviar el correo electrónico: " + ex.Message);
                throw;
            }

            return RedirectToAction("Index", "Home");
        }

        return View(tbFormParkingcard);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public async Task<IActionResult> Nosotros()
    {
        //var paginasCab = new PaginasCabsService(new HttpClient());
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        var nosotros = await _paginasCabsService.paginasCabsPorDefault();
        // paginasCab.paginasCabsPorDefault(),
        var model = new IndexVM()
        {
            PaginaCab = nosotros, 
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };
        if (model.PaginaCab == null)
        {
            TbConfPaginascab objPaginaCab = new TbConfPaginascab();
            model.PaginaCab = objPaginaCab;
            return View(model);
        }

        return View(model);
    }

    // ============================ Administracion de estacionamiento ============================
    public async Task<IActionResult> Adminestacionamiento()
    {
        int contador = 1;
        ServicioDetalleDtos objeto = new ServicioDetalleDtos();
        
        //var adminiestacionamiento = new ServicioDetalleService(new HttpClient());
        var servicio = await _servicioDetalleService.obtenerServicioDetalle(1);
        foreach (var valor in servicio)
        {
            if (contador == 1)
            {
                objeto.titulo = "ADMINISTRACIÓN DE ESTACIONAMIENTO";
                objeto.subtitulo1 = valor.Subtitulo;
                objeto.descripcion1 = valor.Descripcion;
                contador++;
            }
            else
            {
                objeto.subtitulo2 = valor.Subtitulo;
                objeto.descripcion2 = valor.Descripcion;
            }

        }
        return View(objeto);
    }

    public IActionResult Cotizacionadministracion()
    {
        return View();
    }

    // ============================ Abonados ============================
    public async Task<IActionResult> Abonados()
    {
        int contador = 1;
        ServiceDetails objeto = new ServiceDetails();
        //var adminiestacionamiento = new ServicioDetalleService(new HttpClient());
        var servicio = await _servicioDetalleService.obtenerServicioDetalle(2);
        foreach (var valor in servicio)
        {
            if (contador == 1)
            {
                objeto.titulo = "GESTIÓN DE ABONADOS";
                objeto.subtitulo1 = valor.Subtitulo;
                objeto.descripcion1 = valor.Descripcion;
                contador++;
            }
            else
            {
                objeto.subtitulo2 = valor.Subtitulo;
                objeto.descripcion2 = valor.Descripcion;
            }
            
        }
        //return View(objeto);
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(),
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
            ServicioDetalles= objeto,
        };
        return View(model);
    }
    public async Task<IActionResult> Cotizacionabonados()
    {
        //var cotizanoServicio = new CotizanosService(new HttpClient());
        var distritos = await _cotizanosService.obtenerDistritos("1501");
        if (distritos == null)
        {
            return NotFound();
        }

        var hoteldistritos = await _cotizanosService.obtenerHotelDistritos();
        if (hoteldistritos == null)
        {
            return NotFound();
        }
        var codigosDistritoDistintos = hoteldistritos
        .Select(h => h.CodDistrito)
        .Distinct()
        .ToList();

        distritos = distritos
        .Where(d => codigosDistritoDistintos.Any(h => h == d.CodUbi))
        .ToList();

        ViewData["Distritos"] = new SelectList(distritos, "CodUbi", "Dist");

        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(),
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };
        return View(model);
    }
    public async Task<IActionResult> GetHotelPorDistrito(string cod)
    {
        //var cotizanoServicio = new CotizanosService(new HttpClient());
        var hoteldistritos = await _cotizanosService.obtenerHotelDistritos();
        if (hoteldistritos == null)
        {
            return NotFound();
        }
        var codigosDistritoDistintos = hoteldistritos
        .Where(h=>h.CodDistrito== cod)
        .ToList();
        return Json(codigosDistritoDistintos);
    }
    // ============================ Otros servicios ============================
    public async Task<IActionResult> Otrosservicios()
    {
        //var otrosServicios = new ServicioCabeceraService(new HttpClient());
        var servicios = await _servicioCabeceraService.ListarServicios();
        //return View(servicios);
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(),
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
            ListServCabecera= servicios,
        };
        if (servicios.Count == 0)
        {
            TbServCabecera objServCabecera = new TbServCabecera();
            model.ListServCabecera.Add(objServCabecera);
            return View(model);
        }
        return View(model);
    }
    //----------------------------------------
    public async Task<IActionResult> ValetParking()
    {
        //var cotizanoServicio = new CotizanosService(new HttpClient());
        var distritos = await _cotizanosService.obtenerDistritos("1501");
        if (distritos == null)
        {
            return NotFound();
        }
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(),
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };

        return View(model);
    }
    public async Task<IActionResult> CotizacionValetParking()
    {
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(),
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };

        return View(model);
    }
    //----------------------------------------
    public async Task<IActionResult> Eventos()
    {
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(),
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };

        return View(model);
    }
    public async Task<IActionResult> CotizacionEventos()
    {
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(),
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };

        return View(model);
    }
    //----------------------------------------
    public async Task<IActionResult> Prevencion()
    {
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(),
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };

        return View(model);
    }
    public async Task<IActionResult> CotizacionPrevencion()
    {
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(),
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };

        return View(model);
    }
    //----------------------------------------
    public async Task<IActionResult> Rentabilizacion()
    {
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(),
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };

        return View(model);
    }
    public async Task<IActionResult> CotizacionRentabilizacion()
    {
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(),
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };

        return View(model);
    }
    //----------------------------------------
    // ============================ Contactanos ============================
    public async Task<IActionResult> Contactanos()
    {
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(),
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Contactanos([Bind("Id,Nombre,CorreoElectronico,Asunto,Mensaje,TipoServicio")] TbFormContactano tbFormContactano)
    {
        //var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await _entidadesService.ListarEntidades() ;// entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        //var contacto = new ContactanoService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su solicitud llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await _contactanoService.crearContactoRegistro(tbFormContactano);
            enviarEmail(tbFormContactano.CorreoElectronico,mensaje,primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormContactano);
    }

    // ============================ Cotizanos ============================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosAdministracion([Bind("Id,Distrito,Direccion,Ruc,RazonSocial,Contacto,Celular,Telefono,CorreoElectronico,TipoServicio")] TbFormCotizano tbFormCotizano)
    {
        //var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await _entidadesService.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        //var contacto = new CotizanosService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su cotización de Administración de Estacionamiento llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await _cotizanosService.crearCotizanoRegistro(tbFormCotizano);
            enviarEmail(tbFormCotizano.CorreoElectronico, mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizano);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosAbonados([Bind("Id,Distrito,TipoAbonado,Estacionamiento,Cantidad,Ruc,RazonSocial,Contacto,Celular,Telefono,CorreoElectronico,TipoServicio")] TbFormCotizano tbFormCotizano)
    {
        //var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await _entidadesService.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        //var contacto = new CotizanosService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su cotización de Gestión de Abonados llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await _cotizanosService.crearCotizanoRegistro(tbFormCotizano);
            enviarEmail(tbFormCotizano.CorreoElectronico, mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizano);
    }

    

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosValetParking([Bind("Id,Distrito,Direccion,Ruc,RazonSocial,Contacto,Celular,Telefono,CorreoElectronico,TipoServicio")] TbFormCotizano tbFormCotizano)
    {
        //var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await _entidadesService.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        //var contacto = new CotizanosService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su cotización de Valet Parking llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await _cotizanosService.crearCotizanoRegistro(tbFormCotizano);
            enviarEmail(tbFormCotizano.CorreoElectronico, mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizano);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosEventos([Bind("Id,Distrito,Direccion,Ruc,RazonSocial,Contacto,Celular,Telefono,FechaEvento,CorreoElectronico,Comentario,TipoServicio")] TbFormCotizano tbFormCotizano)
    {
        //var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await _entidadesService.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        //var contacto = new CotizanosService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su cotización de Eventos llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await _cotizanosService.crearCotizanoRegistro(tbFormCotizano);
            enviarEmail(tbFormCotizano.CorreoElectronico, mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizano);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosPrevencion([Bind("Id,Distrito,Direccion,Ruc,RazonSocial,Contacto,Celular,Telefono,CorreoElectronico,TipoServicio")] TbFormCotizano tbFormCotizano)
    {
        //var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await _entidadesService.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        //var contacto = new CotizanosService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su cotización de Prevención llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await _cotizanosService.crearCotizanoRegistro(tbFormCotizano);
            enviarEmail(tbFormCotizano.CorreoElectronico, mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizano);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosRentabilizacion([Bind("Id,Distrito,Direccion,Ruc,RazonSocial,Contacto,Celular,Telefono,CorreoElectronico,TipoServicio")] TbFormCotizano tbFormCotizano)
    {
        //var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await _entidadesService.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        //var contacto = new CotizanosService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su cotización de Rentabilización de Terrenos llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await _cotizanosService.crearCotizanoRegistro(tbFormCotizano);
            enviarEmail(tbFormCotizano.CorreoElectronico, mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizano);
    }

    // ============================ Trabaja con Nosotros ============================
    public async Task<IActionResult> Trabajaconnosotros()
    {
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(), 
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };

        if (model.Puestos.Count == 0)
        {
            TbTraPuesto obj = new TbTraPuesto();
            model.Puestos.Add(obj);
            return View(model);
        }

        return View(model);
    }

    public IActionResult Postulacion(int idpostulacion)
    {
        TbFormTbcnosotro form = new TbFormTbcnosotro();
        if (idpostulacion == 1)
        {
            form.Puesto = "Agente de prevención";
        }else if(idpostulacion==2){
            form.Puesto = "Valet Parking"  ;
        }
        else
        {
            form.Puesto = "Agente Servicio" ;
        }
        return View(form);
    }

    // POST: Postulacion/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Postulacion([Bind("Id,TipoDocumento,Nombre,Apellido,FechaNacimiento,CorreoElectronico,Departamento,Provincia,Distrito,Puesto,InformacionAdicional,NumeroDocumento,Celular,Medio")] TbFormTbcnosotro tbFormTbcnosotro)
    {
        //var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await _entidadesService.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        //var postulacion = new PostulacionService(new HttpClient());
        
        if (ModelState.IsValid)
        {
            string mensaje= $"Su solicitud de postulación para, {tbFormTbcnosotro.Puesto} ah sido registrada";
            await _postulacionService.crearPostulacion(tbFormTbcnosotro);
            enviarEmail(tbFormTbcnosotro.CorreoElectronico,mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormTbcnosotro);
    }

    // ============================ Proveedores ============================ 
    public async Task<IActionResult> Proveedores()
    {

        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        var model = new IndexVM()
        {
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };

        //Listando Rubros
        //var menu = new RubroService(new HttpClient());
        var menuLista = await _rubroService.ListarRubros();//menu.ListarRubros();
        var menuItems = menuLista.Select(m => new SelectListItem
        {
            Value = m.Rubro,
            Text = $"{m.Rubro}"
        });

        ViewData["vMenu"] = new SelectList(
            Enumerable.Repeat(new SelectListItem { Value = "", Text = "Selecciona" }, 1)
            .Concat(menuItems),
            "Value",
            "Text"
        );

        return View(model);
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Proveedores(TbFormProveedore tbFormProveedore)
    {
        //var proveedor = new ProveedorService(new HttpClient());

        if (ModelState.IsValid)
        {
           // string mensaje = "Su solicitud de postulación ah sido registrada";
            await _proveedorService.crearProveedorRegistro(tbFormProveedore);
         //   enviarEmail(tbFormProveedore., mensaje);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormProveedore);

    }
    
    // ============================ Hoja Reclamaciones ============================ 
    public async Task<IActionResult> HojaReclamaciones()
    {
        var modalcab2 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(2);
        var modaldet6 = await _modaleDetalleService.listarModalDetalle(6);

        var modalcab5 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(5);
        var modaldet9 = await _modaleDetalleService.listarModalDetalle(9);

        var modalcab7 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(7);
        var modaldet12 = await _modaleDetalleService.listarModalDetalle(12);
        var modalcab8 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(8);
        var modaldet13 = await _modaleDetalleService.listarModalDetalle(13);
        var modalcab9 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(9);
        var modaldet14 = await _modaleDetalleService.listarModalDetalle(14);
        var modalcab10 = await _modaleCabeceraService.obtenerModalCabeceraDetalle(10);
        var modaldet15 = await _modaleDetalleService.listarModalDetalle(15);
        //var puesto = new PuestoService(new HttpClient());puesto.ListarPuestos(),
        var model = new IndexVM()
        {
            Puestos = await _puestoService.ListarPuestos(),
            ModalCabs2 = modalcab2,
            ListModalDet6 = modaldet6,
            ModalCabs5 = modalcab5,
            ListModalDet9 = modaldet9,

            ModalCabs7 = modalcab7,
            ListModalDet12 = modaldet12,
            ModalCabs8 = modalcab8,
            ListModalDet13 = modaldet13,
            ModalCabs9 = modalcab9,
            ListModalDet14 = modaldet14,
            ModalCabs10 = modalcab10,
            ListModalDet15 = modaldet15,
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> HojaReclamaciones(TbFormHojareclamacione tbFormHojareclamacione)
    {
        //var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await _entidadesService.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        tbFormHojareclamacione.Fecha = DateTime.Now;
        //var servicio = new HojaReclamacioneService(new HttpClient());

        if (ModelState.IsValid)
        {
           
            string mensaje = "Su solicitud de reclamación ah sido registrada con éxito";
            await _hojaReclamacioneService.crearHojaReclamacioneRegistro(tbFormHojareclamacione);
            enviarEmail(tbFormHojareclamacione.Correo, mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormHojareclamacione);

    }


    private void enviarEmail(string correoDestinatario,string mensaje, Entidades entidades)
    {
        
        string server = entidades.Servidor?? "smtp.gmail.com";
        int port = entidades.Puerto?? 465;
        string correo = entidades.CorreoNotifica?? "centralparking153@gmail.com";
        string pass = entidades.ClaveNotifica?? "mwabukzuumewdbhn";


        string correoCC =entidades.CorreoConCopia?? "adelacruzcarlos@gmail.com";

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Remitente", correo));
        message.To.Add(new MailboxAddress("Destinatario", correoDestinatario));
        message.Cc.Add(new MailboxAddress("Copia", correoCC));
        message.Subject = "Agencia CentralParking Perú";

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = mensaje;

        message.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            try
            {
                client.Connect(server,port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(correo,pass);
                client.Send(message);
            }
            catch (Exception ex)
            {
                // Registrar un mensaje de error o lanzar una excepción o ambos.
                Console.WriteLine("Ocurrió un error al enviar el correo electrónico: " + ex.Message);
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }



}