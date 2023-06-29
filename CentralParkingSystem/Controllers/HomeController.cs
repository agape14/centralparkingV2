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
using System.Diagnostics.Contracts;

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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ParkingCard(TbFormParkingcard tbFormParkingcard)
    {
        var servicio = new ParkingCardService(new HttpClient());
        if (ModelState.IsValid)
        {
         
            try
            {
                string mensaje = "Notificamos que hemos registrado su solicitud en parkingcardvip.";
                tbFormParkingcard.FecRegistro = DateTime.Now;
                tbFormParkingcard.Notificado = 1;
                await servicio.crearParkingCardRegistro(tbFormParkingcard);
                enviarEmail(tbFormParkingcard.Correo, mensaje);
               
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
        var paginasCab = new PaginasCabsService(new HttpClient());
        var model = new IndexVM()
        {
            PaginaCab = await paginasCab.paginasCabsPorDefault()
        };

        return View(model);
    }

    // ============================ Administracion de estacionamiento ============================
    public async Task<IActionResult> Adminestacionamiento()
    {
        int contador = 1;
        ServicioDetalleDtos objeto = new ServicioDetalleDtos();
        
        var adminiestacionamiento = new ServicioDetalleService(new HttpClient());
        var servicio = await adminiestacionamiento.obtenerServicioDetalle(1);
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
        ServicioDetalleDtos objeto = new ServicioDetalleDtos();
        var adminiestacionamiento = new ServicioDetalleService(new HttpClient());
        var servicio = await adminiestacionamiento.obtenerServicioDetalle(1);
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
        return View(objeto);
    }
    public IActionResult Cotizacionabonados()
    {
        return View();
    }

    // ============================ Otros servicios ============================
    public async Task<IActionResult> Otrosservicios()
    {
        var otrosServicios = new ServicioCabeceraService(new HttpClient());
        var servicios = await otrosServicios.ListarServicios();
        return View(servicios);
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Contactanos([Bind("Id,Nombre,CorreoElectronico,Asunto,Mensaje,TipoServicio")] TbFormContactano tbFormContactano)
    {
        
        var contacto = new ContactanoService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su solicitud llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await contacto.crearContactoRegistro(tbFormContactano);
            enviarEmail(tbFormContactano.CorreoElectronico,mensaje);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormContactano);
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
        var postulacion = new PostulacionService(new HttpClient());
        
        if (ModelState.IsValid)
        {
            string mensaje= $"Su solicitud de postulación para, {tbFormTbcnosotro.Puesto} ah sido registrada";
            await postulacion.crearPostulacion(tbFormTbcnosotro);
            enviarEmail(tbFormTbcnosotro.CorreoElectronico,mensaje);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormTbcnosotro);
    }

    // ============================ Proveedores ============================ 
    public IActionResult Proveedores()
    {
        return View();
    }
    
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Proveedores(TbFormProveedore tbFormProveedore)
    {
        var proveedor = new ProveedorService(new HttpClient());

        if (ModelState.IsValid)
        {
           // string mensaje = "Su solicitud de postulación ah sido registrada";
            await proveedor.crearProveedorRegistro(tbFormProveedore);
         //   enviarEmail(tbFormProveedore., mensaje);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormProveedore);

    }
    
    // ============================ Hoja Reclamaciones ============================ 
    public IActionResult HojaReclamaciones()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> HojaReclamaciones(TbFormHojareclamacione tbFormHojareclamacione)
    {
        tbFormHojareclamacione.Fecha = DateTime.Now;
        var servicio = new HojaReclamacioneService(new HttpClient());

        if (ModelState.IsValid)
        {
           
            string mensaje = "Su solicitud de reclamación ah sido registrada con éxito";
            await servicio.crearHojaReclamacioneRegistro(tbFormHojareclamacione);
            enviarEmail(tbFormHojareclamacione.Correo, mensaje);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormHojareclamacione);

    }


    private void enviarEmail(string correoDestinatario,string mensaje)
    {

        string server = "smtp.gmail.com";
        int port = 465;
        string correo = "centralparking153@gmail.com";
        string pass = "mwabukzuumewdbhn";


        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Remitente", correo));
        message.To.Add(new MailboxAddress("Destinatario", correoDestinatario));
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