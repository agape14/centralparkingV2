using ApiBD.Models;
using CentralParkingSystem.Helpers;
using CentralParkingSystem.Services;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using CentralParkingSystem.DTOs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CentralParkingContext>();

// Agregar configuración para IHttpClientFactory y IConfiguration 
builder.Services.AddHttpClient<ContactanoService>();
builder.Services.AddHttpClient<CotizanosService>();
builder.Services.AddHttpClient<HojaReclamacioneService>();
builder.Services.AddHttpClient<ParkingCardService>();
builder.Services.AddHttpClient<PostulacionService>();
builder.Services.AddHttpClient<ProveedorService>();
builder.Services.AddHttpClient<ServicioCabeceraService>();
builder.Services.AddHttpClient<ServicioDetalleService>();
builder.Services.AddHttpClient<SlideService>();
builder.Services.AddHttpClient<ServiciosCabsService>();
builder.Services.AddHttpClient<ServiciosdetsService>();
builder.Services.AddHttpClient<CaracteristicasService>();
builder.Services.AddHttpClient<ModaleCabeceraService>();
builder.Services.AddHttpClient<ModaleDetalleService>();
builder.Services.AddHttpClient<RedesSocialesService>();
builder.Services.AddHttpClient<MenusService>();
builder.Services.AddHttpClient<PiePaginaCabsService>();
builder.Services.AddHttpClient<PiePaginaDetsService>();
builder.Services.AddHttpClient<EntidadesService>();
builder.Services.AddHttpClient<PaginasCabsService>();
builder.Services.AddHttpClient<PuestoService>();
builder.Services.AddHttpClient<RubroService>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddMvc()
        .AddSessionStateTempDataProvider();
builder.Services.AddSession();
builder.Services.AddSingleton<CopiarArchivosPDF>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
// Middleware de carga de datos
app.Use(async (context, next) =>
{
    var cache = context.RequestServices.GetRequiredService<IMemoryCache>();
    var httpContextAccessor = context.RequestServices.GetRequiredService<IHttpContextAccessor>();
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

    var userActivityCookie = context.Request.Cookies["LastActivity"];

    if (string.IsNullOrEmpty(userActivityCookie))
    {
        context.Response.Cookies.Append("LastActivity", DateTime.UtcNow.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMinutes(0) });
        var menusService = context.RequestServices.GetRequiredService<MenusService>();
        var entidadesService = context.RequestServices.GetRequiredService<EntidadesService>();
        if (!cache.TryGetValue("menus", out List<Result> listMenu))
        {
            listMenu = await menusService.ListarMenus();
            cache.Set("menus", listMenu, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("submenus", out List<SubMenus> listSubMenu))
        {
            listSubMenu = await menusService.ListarSubMenus();
            cache.Set("submenus", listSubMenu, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("entidades", out List<Entidades> listEntidad))
        {
            listEntidad = await entidadesService.ListarEntidades();
            cache.Set("entidades", listEntidad, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("dpto", out List<TbConfUbigeo> listDpto))
        {
            listDpto = await entidadesService.obtenerDepartamento();
            cache.Set("dpto", listDpto, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("redessociales", out List<RedesSociales> listRedes))
        {
            var redesSocialesService = context.RequestServices.GetRequiredService<RedesSocialesService>();
            listRedes = await redesSocialesService.ListarRedSociales();
            cache.Set("redessociales", listRedes, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("piepag", out List<PiePaginaCabs> listPie))
        {
            var piePaginaCabsService = context.RequestServices.GetRequiredService<PiePaginaCabsService>();
            listPie = await piePaginaCabsService.ListarPiePaginasCabs();
            cache.Set("piepag", listPie, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("piepagdet", out List<TbConfPiepaginadet> lisPiedet))
        {
            var piePaginaDetsService = context.RequestServices.GetRequiredService<PiePaginaDetsService>();
            lisPiedet = await piePaginaDetsService.ListarPiePaginaDets();
            cache.Set("piepagdet", lisPiedet, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("iservices", out List<TbIndServiciocab> listIServicios))
        {
            var serviciosCabsservice = context.RequestServices.GetRequiredService<ServiciosCabsService>();
            listIServicios = await serviciosCabsservice.ListarServiciosCabs();
            cache.Set("iservices", listIServicios, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("iservicesdet", out List<TbIndServiciodet> listIServiciodets))
        {
            var serviciosdetsService = context.RequestServices.GetRequiredService<ServiciosdetsService>();
            listIServiciodets = await serviciosdetsService.ListarServiciosdets();
            cache.Set("iservicesdet", listIServiciodets, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("caracteristicass", out List<TbIndCaracteristica> caracteristicasLista))
        {
            var caracteristicasService = context.RequestServices.GetRequiredService<CaracteristicasService>();
            caracteristicasLista = await caracteristicasService.ListarCaracteristicas();
            cache.Set("caracteristicass", caracteristicasLista, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("slides", out List<TbIndSlidecab> listSlide))
        {
            var slideService = context.RequestServices.GetRequiredService<SlideService>();
            listSlide = await slideService.ListarSlide();
            cache.Set("slides", listSlide, TimeSpan.Zero);
        }

        var modaleCabeceraService = context.RequestServices.GetRequiredService<ModaleCabeceraService>();
        var modaleDetalleService = context.RequestServices.GetRequiredService<ModaleDetalleService>();
        if (!cache.TryGetValue("modalcab2", out TbConfModalcab modalcab2))
        {
            modalcab2 = await modaleCabeceraService.obtenerModalCabeceraDetalle(2);
            cache.Set("modalcab2", modalcab2, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("modalcab5", out TbConfModalcab modalcab5))
        {
            modalcab5 = await modaleCabeceraService.obtenerModalCabeceraDetalle(5);
            cache.Set("modalcab5", modalcab5, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("modalcab7", out TbConfModalcab modalcab7))
        {
            modalcab7 = await modaleCabeceraService.obtenerModalCabeceraDetalle(7);
            cache.Set("modalcab7", modalcab7, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("modalcab8", out TbConfModalcab modalcab8))
        {
            modalcab8 = await modaleCabeceraService.obtenerModalCabeceraDetalle(8);
            cache.Set("modalcab8", modalcab8, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("modalcab9", out TbConfModalcab modalcab9))
        {
            modalcab9 = await modaleCabeceraService.obtenerModalCabeceraDetalle(9);
            cache.Set("modalcab9", modalcab9, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("modalcab10", out TbConfModalcab modalcab10))
        {
            modalcab10 = await modaleCabeceraService.obtenerModalCabeceraDetalle(10);
            cache.Set("modalcab10", modalcab10, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("modaldet6", out List<TbConfModaldet> modaldet6))
        {
            modaldet6 = await modaleDetalleService.listarModalDetalle(6);
            cache.Set("modaldet6", modaldet6, TimeSpan.Zero);
        }
        if (!cache.TryGetValue("modaldet9", out List<TbConfModaldet> modaldet9))
        {
            modaldet9 = await modaleDetalleService.listarModalDetalle(9);
            cache.Set("modaldet9", modaldet9, TimeSpan.Zero);
        }
        if (!cache.TryGetValue("modaldet12", out List<TbConfModaldet> modaldet12))
        {
            modaldet12 = await modaleDetalleService.listarModalDetalle(12);
            cache.Set("modaldet12", modaldet12, TimeSpan.Zero);
        }
        if (!cache.TryGetValue("modaldet13", out List<TbConfModaldet> modaldet13))
        {
            modaldet13 = await modaleDetalleService.listarModalDetalle(13);
            cache.Set("modaldet13", modaldet13, TimeSpan.Zero);
        }
        if (!cache.TryGetValue("modaldet14", out List<TbConfModaldet> modaldet14))
        {
            modaldet14 = await modaleDetalleService.listarModalDetalle(14);
            cache.Set("modaldet14", modaldet14, TimeSpan.Zero);
        }
        if (!cache.TryGetValue("modaldet15", out List<TbConfModaldet> modaldet15))
        {
            modaldet15 = await modaleDetalleService.listarModalDetalle(15);
            cache.Set("modaldet15", modaldet15, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("paginascabs", out TbConfPaginascab listPaginasCabs))
        {
            var paginascabsService = context.RequestServices.GetRequiredService<PaginasCabsService>();
            listPaginasCabs = await paginascabsService.paginasCabsPorDefault();
            cache.Set("paginascabs", listPaginasCabs, TimeSpan.Zero);
        }

        if (!cache.TryGetValue("listpuestos", out List<TbTraPuesto> listPuestos))
        {
            var puestoService = context.RequestServices.GetRequiredService<PuestoService>();
            listPuestos = await puestoService.ListarPuestos();
            cache.Set("listpuestos", listPuestos, TimeSpan.Zero);
        }
    }

    await next.Invoke();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
