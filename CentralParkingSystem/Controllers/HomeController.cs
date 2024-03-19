﻿using ApiBD.Models.Home;
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
using CentralParkingSystem.Helpers;

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
    private readonly CopiarArchivosPDF _copiarArchivosPDF;
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
        ServicioDetalleService servicioDetalleService,
        CopiarArchivosPDF copiarArchivosPDF
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
        _copiarArchivosPDF = copiarArchivosPDF;
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
        ServiceDetails objeto = new ServiceDetails();
        
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
            ServicioDetalles = objeto,
        };
        return View(model);
    }

    public async Task<IActionResult> Cotizacionadministracion()
    {
        //return View();
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
        var listEntidad = await _entidadesService.ListarEntidades();// entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistroEntidad = listEntidad.FirstOrDefault();
        var ubigeoServicio = await _cotizanosService.listarDistritoPorServicio(1);
        var distritosSelectList = ubigeoServicio.Select(u => new SelectListItem
        {
            Value = u.TbConfUbigeo.CodUbi, // Valor del id
            Text = u.TbConfUbigeo.Dist // Texto a mostrar
        }).ToList();
        ViewData["Distritos"] = distritosSelectList;
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
            ListModalDet15 = modaldet15
        };
        ViewBag.primerRegistroEntidad = primerRegistroEntidad;
        return View(model);
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

        var ubigeoServicio = await _cotizanosService.listarDistritoPorServicio(2);
        // Crear lista de SelectListItem
        var distritosSelectList = ubigeoServicio.Select(u => new SelectListItem
        {
            Value = u.TbConfUbigeo.CodUbi, // Valor del id
            Text = u.TbConfUbigeo.Dist // Texto a mostrar
        }).ToList();
        // Agregar un elemento adicional al inicio de la lista
        //distritosSelectList.Insert(0, new SelectListItem
        //{
        //    Value = "", // Valor vacío
        //    Text = "Seleccione distrito" // Texto a mostrar
        //});
        // Establecer la lista en ViewData
        ViewData["Distritos"] = distritosSelectList;
        //ViewData["Distritos"] = new SelectList(distritos, "CodUbi", "Dist");

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
        var listEntidad = await _entidadesService.ListarEntidades();// entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistroEntidad = listEntidad.FirstOrDefault();
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
        ViewBag.primerRegistroEntidad = primerRegistroEntidad;
        return View(model);
    }
    public async Task<IActionResult> GetHotelPorDistrito(string cod)
    {
        //var cotizanoServicio = new CotizanosService(new HttpClient());
        var estacionamientos = await _cotizanosService.listarEstacionamientosPorDistrito(cod);
        if (estacionamientos == null || !estacionamientos.Any())
        {
            return NotFound();
        }

        return Json(estacionamientos);
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
        var listEntidad = await _entidadesService.ListarEntidades();// entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistroEntidad = listEntidad.FirstOrDefault();
        var ubigeoServicio = await _cotizanosService.listarDistritoPorServicio(3);
        var distritosSelectList = ubigeoServicio.Select(u => new SelectListItem
        {
            Value = u.TbConfUbigeo.CodUbi, // Valor del id
            Text = u.TbConfUbigeo.Dist // Texto a mostrar
        }).ToList();
        ViewData["Distritos"] = distritosSelectList;
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
        ViewBag.primerRegistroEntidad = primerRegistroEntidad;
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
        var listEntidad = await _entidadesService.ListarEntidades();// entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistroEntidad = listEntidad.FirstOrDefault();
        var ubigeoServicio = await _cotizanosService.listarDistritoPorServicio(4);
        var distritosSelectList = ubigeoServicio.Select(u => new SelectListItem
        {
            Value = u.TbConfUbigeo.CodUbi, // Valor del id
            Text = u.TbConfUbigeo.Dist // Texto a mostrar
        }).ToList();
        ViewData["Distritos"] = distritosSelectList;
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
        ViewBag.primerRegistroEntidad = primerRegistroEntidad;
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
        var listEntidad = await _entidadesService.ListarEntidades();// entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistroEntidad = listEntidad.FirstOrDefault();
        var ubigeoServicio = await _cotizanosService.listarDistritoPorServicio(5);
        var distritosSelectList = ubigeoServicio.Select(u => new SelectListItem
        {
            Value = u.TbConfUbigeo.CodUbi, // Valor del id
            Text = u.TbConfUbigeo.Dist // Texto a mostrar
        }).ToList();
        ViewData["Distritos"] = distritosSelectList;
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
        ViewBag.primerRegistroEntidad = primerRegistroEntidad;
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
        var listEntidad = await _entidadesService.ListarEntidades();// entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistroEntidad = listEntidad.FirstOrDefault();
        var ubigeoServicio = await _cotizanosService.listarDistritoPorServicio(6);
        var distritosSelectList = ubigeoServicio.Select(u => new SelectListItem
        {
            Value = u.TbConfUbigeo.CodUbi, // Valor del id
            Text = u.TbConfUbigeo.Dist // Texto a mostrar
        }).ToList();
        ViewData["Distritos"] = distritosSelectList;
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
        ViewBag.primerRegistroEntidad = primerRegistroEntidad;
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
    public async Task<IActionResult> Contactanos(IndexVM tbFormContactano)
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
            string titulonotificacion = "Gracias por contactarte con nosotros.";
            string mensaje = "Gracias por su consulta a través de nuestro formulario de contacto. Nos comunicaremos con ud. lo antes posible.";
            await _contactanoService.crearContactoRegistro(tbFormContactano.FormContactanos);
            bool envioExitoso = enviarEmailValidando(tbFormContactano.FormContactanos.CorreoElectronico, mensaje, primerRegistro, titulonotificacion);
            if (envioExitoso)
            {
                TempData["SuccessMessage"] = "El correo se envió correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Hubo un error al enviar el correo.";
            }

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormContactano);
    }

    // ============================ Cotizanos ============================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosAdministracion(IndexVM tbFormCotizaAdmin)
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
            string titulonotificacion = "Gracias por registrar la cotizacion.";
            string mensaje = "Recibimos su cotización de Administración de Estacionamiento llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await _cotizanosService.crearCotizanoRegistro(tbFormCotizaAdmin.TbFormCotizanos);
            bool envioExitoso = enviarEmailValidando(tbFormCotizaAdmin.TbFormCotizanos.CorreoElectronico, mensaje, primerRegistro, titulonotificacion);
            if (envioExitoso)
            {
                TempData["SuccessMessage"] = "El correo se envió correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Hubo un error al enviar el correo.";
            }

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizaAdmin);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosAbonados(IndexVM tbFormCotizaAbonados)
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
            string titulonotificacion = "Gracias por registrar la cotizacion.";
            string mensaje = "Recibimos su cotización de Gestión de Abonados llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await _cotizanosService.crearCotizanoRegistro(tbFormCotizaAbonados.TbFormCotizanos);
            bool envioExitoso = enviarEmailValidando(tbFormCotizaAbonados.TbFormCotizanos.CorreoElectronico, mensaje, primerRegistro, titulonotificacion);
            if (envioExitoso)
            {
                TempData["SuccessMessage"] = "El correo se envió correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Hubo un error al enviar el correo.";
            }
            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizaAbonados);
    }

    

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosValetParking(IndexVM tbFormCotizaValetParking)
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
            string titulonotificacion = "Gracias por registrar la cotizacion.";
            string mensaje = "Recibimos su cotización de Valet Parking llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await _cotizanosService.crearCotizanoRegistro(tbFormCotizaValetParking.TbFormCotizanos);
            bool envioExitoso = enviarEmailValidando(tbFormCotizaValetParking.TbFormCotizanos.CorreoElectronico, mensaje, primerRegistro, titulonotificacion);
            if (envioExitoso)
            {
                TempData["SuccessMessage"] = "El correo se envió correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Hubo un error al enviar el correo.";
            }
            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizaValetParking);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosEventos(IndexVM tbFormCotizaEventos)
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
            string titulonotificacion = "Gracias por registrar la cotizacion.";
            string mensaje = "Recibimos su cotización de Eventos llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await _cotizanosService.crearCotizanoRegistro(tbFormCotizaEventos.TbFormCotizanos);
            bool envioExitoso = enviarEmailValidando(tbFormCotizaEventos.TbFormCotizanos.CorreoElectronico, mensaje, primerRegistro, titulonotificacion);
            if (envioExitoso)
            {
                TempData["SuccessMessage"] = "El correo se envió correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Hubo un error al enviar el correo.";
            }
            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizaEventos);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosPrevencion(IndexVM tbFormCotizaPrevencion)
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
            string titulonotificacion = "Gracias por registrar la cotizacion.";
            string mensaje = "Recibimos su cotización de Prevención llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await _cotizanosService.crearCotizanoRegistro(tbFormCotizaPrevencion.TbFormCotizanos);
            bool envioExitoso = enviarEmailValidando(tbFormCotizaPrevencion.TbFormCotizanos.CorreoElectronico, mensaje, primerRegistro, titulonotificacion);
            if (envioExitoso)
            {
                TempData["SuccessMessage"] = "El correo se envió correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Hubo un error al enviar el correo.";
            }
            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizaPrevencion);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosRentabilizacion(IndexVM tbFormCotizaPrevencion)
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
            string titulonotificacion = "Gracias por registrar la cotizacion.";
            string mensaje = "Recibimos su cotización de Rentabilización de Terrenos llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await _cotizanosService.crearCotizanoRegistro(tbFormCotizaPrevencion.TbFormCotizanos);
            bool envioExitoso = enviarEmailValidando(tbFormCotizaPrevencion.TbFormCotizanos.CorreoElectronico, mensaje, primerRegistro, titulonotificacion);
            if (envioExitoso)
            {
                TempData["SuccessMessage"] = "El correo se envió correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Hubo un error al enviar el correo.";
            }
            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizaPrevencion);
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

    public async Task<IActionResult> Postulacion(int idpostulacion)
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
       // return View(form);
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
        var listDpto = await _entidadesService.obtenerDepartamento();
        ViewData["DptoId"] = new SelectList(listDpto, "CodUbi", "Dpto","15");
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
            TbFormTbcnosotros = form,
        };
        return View(model);
    }

    // POST: Postulacion/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Postulacion(IndexVM tbFormPostulacion)
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
            string titulonotificacion = "Gracias por registrar la postulacion.";
            string mensaje= $"Su solicitud de postulación para: {tbFormPostulacion.TbFormTbcnosotros.Puesto}, se registró correctamente.";
            // Verifica si el modelo es válido y si hay un archivo adjunto
            if (ModelState.IsValid && tbFormPostulacion.InformacionAdicionalFile != null)
            {
                // Guarda el archivo adjunto en el servidor
                var fileName = Path.GetFileName(tbFormPostulacion.InformacionAdicionalFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "docs", fileName);
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await tbFormPostulacion.InformacionAdicionalFile.CopyToAsync(stream);
                }

                // Agrega el nombre del archivo al modelo antes de guardarlo en la base de datos, si es necesario
                tbFormPostulacion.TbFormTbcnosotros.InformacionAdicional = fileName;

                await _postulacionService.crearPostulacion(tbFormPostulacion.TbFormTbcnosotros);
                _copiarArchivosPDF.envia_archivo_pdf();
                bool envioExitoso = enviarEmailValidando(tbFormPostulacion.TbFormTbcnosotros.CorreoElectronico, mensaje, primerRegistro, titulonotificacion);
                if (envioExitoso)
                {
                    TempData["SuccessMessage"] = "Se registro su postulacion y se envió correo correctamente.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Hubo un error al registrar y enviar el correo.";
                }
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");

        }
        return View(tbFormPostulacion);
    }

    public async Task<JsonResult> GetProvincias(string departamentoId)
    {
        var provincias = await _entidadesService.obtenerProvinciasPorDepartamento(departamentoId);
        return Json(provincias);
    }

    public async Task<JsonResult> GetDistritos(string provinciaId)
    {
        var distritos = await _entidadesService.obtenerDistritosPorProvincia(provinciaId);
        return Json(distritos);
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
    public async Task<IActionResult> Proveedores(IndexVM tbFormProveedores)
    {
        //var proveedor = new ProveedorService(new HttpClient());

        if (ModelState.IsValid)
        {
            string titulonotificacion = "Recibimos su registro de Proveedoresnos pondremos en contacto a la brevedad.";
            await _proveedorService.crearProveedorRegistro(tbFormProveedores.Proveedor);
            bool envioExitoso = true;
            if (envioExitoso)
            {
                TempData["SuccessMessage"] = titulonotificacion;
            }
            else
            {
                TempData["ErrorMessage"] = "Hubo un error al enviar el correo.";
            }

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormProveedores);

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
    public async Task<IActionResult> HojaReclamaciones(IndexVM tbFormReclamaciones)
    {
        //var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await _entidadesService.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        tbFormReclamaciones.HojaReclamaciones.Fecha = DateTime.Now;
        //var servicio = new HojaReclamacioneService(new HttpClient());

        if (ModelState.IsValid)
        {
            string titulonotificacion = "Gracias por registrar su reclamo.";
            string mensaje = "Su solicitud de reclamación ah sido registrada con éxito";
            await _hojaReclamacioneService.crearHojaReclamacioneRegistro(tbFormReclamaciones.HojaReclamaciones);
            bool envioExitoso = enviarEmailValidando(tbFormReclamaciones.TbFormCotizanos.CorreoElectronico, mensaje, primerRegistro, titulonotificacion);
            if (envioExitoso)
            {
                TempData["SuccessMessage"] = "El correo se envió correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Hubo un error al enviar el correo.";
            }
            return RedirectToAction("Index", "Home");
        }
        return View(tbFormReclamaciones);

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

    private bool enviarEmailValidando(string correoDestinatario, string mensaje, Entidades entidades, string titulonotificacion)
    {

        string server = entidades.Servidor ?? "smtp.gmail.com";
        int port = entidades.Puerto ?? 465;
        string correo = entidades.CorreoNotifica ?? "centralparking153@gmail.com";
        string pass = entidades.ClaveNotifica ?? "mwabukzuumewdbhn";


        string correoCC = entidades.CorreoConCopia ?? "adelacruzcarlos@gmail.com";

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Remitente", correo));
        message.To.Add(new MailboxAddress("Destinatario", correoDestinatario));
        message.Cc.Add(new MailboxAddress("Copia", correoCC));
        message.Subject = "CentralParking Perú";

        var bodyBuilder = new BodyBuilder();
        //bodyBuilder.TextBody = mensaje;
        bodyBuilder.HtmlBody = @"<!DOCTYPE html>
                             <html lang='en'>
                             <head>
                                 <meta charset='UTF-8'>
                                 <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                             </head>
                             <body style='background-color:#FEF9E7;'>
                                 <div style='width: 100%;margin: auto;box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);'>
                                     <table style='background-color:#FEF9E7;max-width:670px;margin:0 auto' width='100%' border='0' align='center' cellpadding='0' cellspacing='0'>
                                        <tbody>
                                        <tr>
                                            <td style='height:40px'>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td><table width='95%' border='0' align='center' cellpadding='0' cellspacing='0' style='max-width:670px;background:#fff;border-radius:3px;text-align:center'>
                                        <tbody>
                                        <tr>
                                            <td style='height:40px'>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style='padding:0 15px'>
                                                <h1 style='color:#F1C40F;font-weight:400;margin:0;font-size:30px'>" + titulonotificacion +@"</h1>
                                                <span style='display:inline-block;vertical-align:middle;margin:29px 0 26px;border-bottom:1px solid #cecece;width:100px'></span>
                                                <p style='color:#171f23de;font-size:15px;line-height:24px;margin:0'>
                                                    " + mensaje + @"
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style='height:40px'>&nbsp;</td>
                                        </tr>
                                        </tbody>
                                    </table></td>
                                        </tr>
                                        <tr>
                                            <td style='height:20px'>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style='text-align:center'>
                                                <p style='font-size:14px;color:#455056bd;line-height:18px;margin:0 0 0'><strong>Central Parking System</strong> | Todos los derechos reservados</p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style='height:80px'>&nbsp;</td>
                                        </tr>
                                        </tbody>
                                    </table>
                                 </div>
                             </body>
                             </html>";
        message.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            try
            {
                client.Connect(server, port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(correo, pass);
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                // Registrar un mensaje de error o lanzar una excepción o ambos.
                Console.WriteLine("Ocurrió un error al enviar el correo electrónico: " + ex.Message);
                return false;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }


}