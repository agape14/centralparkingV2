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
    

    public async Task<IActionResult> Index()
    {
        var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await entidad.ListarEntidades();

        if(listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }


        var redSocial = new RedesSocialesService(new HttpClient());
        var listRedes = await redSocial.ListarRedSociales();
        if(listRedes.Count == 0)
        {
            RedesSociales objRedesSociales = new RedesSociales();
            listRedes.Add(objRedesSociales);
        }

        var menu = new MenusService(new HttpClient());
        var listMenu =await  menu.ListarMenus();
        listMenu = listMenu.Where(item => item.TipoProyecto == "web").ToList();
        if (listMenu.Count == 0)
        {
            Result objResult = new Result();
            listMenu.Add(objResult);
        }

        var subMenu = new MenusService(new HttpClient());
        var listSubMenu = await subMenu.ListarSubMenus();
        if(listSubMenu.Count == 0)
        {
            SubMenus objSubMenu = new SubMenus();
            listSubMenu.Add(objSubMenu);
        }


        var PiePaginaCab = new PiePaginaCabsService(new HttpClient());
        var listPie = await PiePaginaCab.ListarPiePaginasCabs();
        if(listPie.Count == 0)
        {
            PiePaginaCabs objPaginaCab = new PiePaginaCabs();
            listPie.Add(objPaginaCab);
        }


        var PieDet = new PiePaginaDetsService(new HttpClient());
        var listPieDet = await PieDet.ListarPiePaginaDets();
        

        var IServicio = new ServiciosCabsService(new HttpClient());
        var listIServicios = await IServicio.ListarServiciosCabs();

        if(listIServicios.Count == 0)
        {
            TbIndServiciocab objIndServicioCab = new TbIndServiciocab();
            listIServicios.Add(objIndServicioCab);
        }


        var ServicioDet = new ServiciosdetsService(new HttpClient());
        var listIServiciodets = await ServicioDet.ListarServiciosdets();
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



        var instancia = new CaracteristicasService(new HttpClient());
        var caracteristicasLista = await instancia.ListarCaracteristicas();
        if(caracteristicasLista.Count == 0)
        {
            TbIndCaracteristica objCaracteristicas = new TbIndCaracteristica();
            caracteristicasLista.Add(objCaracteristicas);
        }

        var Slide = new SlideService(new HttpClient());
        var listSlide = await Slide.ListarSlide();
        if (listSlide.Count == 0)
        {
            TbIndSlidecab objSlide = new TbIndSlidecab();
            listSlide.Add(objSlide);
        }


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
        var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        var servicio = new ParkingCardService(new HttpClient());
        if (ModelState.IsValid)
        {
         
            try
            {
                string mensaje = "Notificamos que hemos registrado su solicitud en parkingcardvip.";
                tbFormParkingcard.FecRegistro = DateTime.Now;
                tbFormParkingcard.Notificado = 1;
                await servicio.crearParkingCardRegistro(tbFormParkingcard);
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
        var paginasCab = new PaginasCabsService(new HttpClient());
        var model = new IndexVM()
        {
            PaginaCab = await paginasCab.paginasCabsPorDefault()
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
        var servicio = await adminiestacionamiento.obtenerServicioDetalle(2);
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
    public async Task<IActionResult> Cotizacionabonados()
    {
        var cotizanoServicio = new CotizanosService(new HttpClient());
        var distritos = await cotizanoServicio.obtenerDistritos("1501");
        if (distritos == null)
        {
            return NotFound();
        }

        var hoteldistritos = await cotizanoServicio.obtenerHotelDistritos();
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
        return View();
    }
    public async Task<IActionResult> GetHotelPorDistrito(string cod)
    {
        var cotizanoServicio = new CotizanosService(new HttpClient());
        var hoteldistritos = await cotizanoServicio.obtenerHotelDistritos();
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
        var otrosServicios = new ServicioCabeceraService(new HttpClient());
        var servicios = await otrosServicios.ListarServicios();
        if(servicios.Count == 0)
        {
            TbServCabecera objServCabecera = new TbServCabecera();
            servicios.Add(objServCabecera);
            return View(servicios);
        }


        return View(servicios);
    }
    //----------------------------------------
    public async Task<IActionResult> ValetParking()
    {
        var cotizanoServicio = new CotizanosService(new HttpClient());
        var distritos = await cotizanoServicio.obtenerDistritos("1501");
        if (distritos == null)
        {
            return NotFound();
        }
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
        var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        var contacto = new ContactanoService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su solicitud llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await contacto.crearContactoRegistro(tbFormContactano);
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
        var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        var contacto = new CotizanosService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su cotización de Administración de Estacionamiento llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await contacto.crearCotizanoRegistro(tbFormCotizano);
            enviarEmail(tbFormCotizano.CorreoElectronico, mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizano);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosAbonados([Bind("Id,Distrito,TipoAbonado,Estacionamiento,Cantidad,Ruc,RazonSocial,Contacto,Celular,Telefono,CorreoElectronico,TipoServicio")] TbFormCotizano tbFormCotizano)
    {
        var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        var contacto = new CotizanosService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su cotización de Gestión de Abonados llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await contacto.crearCotizanoRegistro(tbFormCotizano);
            enviarEmail(tbFormCotizano.CorreoElectronico, mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizano);
    }

    

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosValetParking([Bind("Id,Distrito,Direccion,Ruc,RazonSocial,Contacto,Celular,Telefono,CorreoElectronico,TipoServicio")] TbFormCotizano tbFormCotizano)
    {
        var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        var contacto = new CotizanosService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su cotización de Valet Parking llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await contacto.crearCotizanoRegistro(tbFormCotizano);
            enviarEmail(tbFormCotizano.CorreoElectronico, mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizano);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosEventos([Bind("Id,Distrito,Direccion,Ruc,RazonSocial,Contacto,Celular,Telefono,FechaEvento,CorreoElectronico,Comentario,TipoServicio")] TbFormCotizano tbFormCotizano)
    {
        var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        var contacto = new CotizanosService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su cotización de Eventos llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await contacto.crearCotizanoRegistro(tbFormCotizano);
            enviarEmail(tbFormCotizano.CorreoElectronico, mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizano);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosPrevencion([Bind("Id,Distrito,Direccion,Ruc,RazonSocial,Contacto,Celular,Telefono,CorreoElectronico,TipoServicio")] TbFormCotizano tbFormCotizano)
    {
        var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        var contacto = new CotizanosService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su cotización de Prevención llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await contacto.crearCotizanoRegistro(tbFormCotizano);
            enviarEmail(tbFormCotizano.CorreoElectronico, mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizano);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CotizanosRentabilizacion([Bind("Id,Distrito,Direccion,Ruc,RazonSocial,Contacto,Celular,Telefono,CorreoElectronico,TipoServicio")] TbFormCotizano tbFormCotizano)
    {
        var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        var contacto = new CotizanosService(new HttpClient());

        if (ModelState.IsValid)
        {
            string mensaje = "Recibimos su cotización de Rentabilización de Terrenos llenada en el formulario, nos pondremos en contacto a la brevedad.";
            await contacto.crearCotizanoRegistro(tbFormCotizano);
            enviarEmail(tbFormCotizano.CorreoElectronico, mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormCotizano);
    }

    // ============================ Trabaja con Nosotros ============================
    public async Task<IActionResult> Trabajaconnosotros()
    {
        var puesto = new PuestoService(new HttpClient());
        var model = new IndexVM()
        {
            Puestos = await puesto.ListarPuestos(),
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
        var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        var postulacion = new PostulacionService(new HttpClient());
        
        if (ModelState.IsValid)
        {
            string mensaje= $"Su solicitud de postulación para, {tbFormTbcnosotro.Puesto} ah sido registrada";
            await postulacion.crearPostulacion(tbFormTbcnosotro);
            enviarEmail(tbFormTbcnosotro.CorreoElectronico,mensaje, primerRegistro);

            return RedirectToAction("Index", "Home");
        }
        return View(tbFormTbcnosotro);
    }

    // ============================ Proveedores ============================ 
    public async Task<IActionResult> Proveedores()
    {

        //Listando Rubros
        var menu = new RubroService(new HttpClient());
        var menuLista = await menu.ListarRubros();
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
        var entidad = new EntidadesService(new HttpClient());
        var listEntidad = await entidad.ListarEntidades();

        if (listEntidad.Count == 0)
        {
            Entidades objEntidad = new Entidades();
            listEntidad.Add(objEntidad);
        }
        Entidades primerRegistro = listEntidad.FirstOrDefault();
        tbFormHojareclamacione.Fecha = DateTime.Now;
        var servicio = new HojaReclamacioneService(new HttpClient());

        if (ModelState.IsValid)
        {
           
            string mensaje = "Su solicitud de reclamación ah sido registrada con éxito";
            await servicio.crearHojaReclamacioneRegistro(tbFormHojareclamacione);
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