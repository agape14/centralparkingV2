using ApiBD.Models;
using CentralParkingSystem.DTOs;
using CentralParkingSystem.Services;
using Cms.Helpers;
using Cms.Providers;
using Cms.Service;
using Cms.ServiceCms;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CentralParkingContext>();

builder.Services.AddHttpClient<CaracteristicaCmsService>();
builder.Services.AddHttpClient<ConfBotonesCmsService>();
builder.Services.AddHttpClient<ContactanoCmsService>();
builder.Services.AddHttpClient<CotizanoCmsService>();
builder.Services.AddHttpClient<EntidadCmsService>();
builder.Services.AddHttpClient<HojaReclamacioneCmsService>();
builder.Services.AddHttpClient<IServicioCmsService>();
builder.Services.AddHttpClient<IServiciodetCmsService>();
builder.Services.AddHttpClient<MenuCmsService>();
builder.Services.AddHttpClient<ModaleCabeceraCmsService>();
builder.Services.AddHttpClient<ModaleDetalleCmsService>();
builder.Services.AddHttpClient<PaginasCmsService>();
builder.Services.AddHttpClient<PaginasDetCmsService>();
builder.Services.AddHttpClient<ParkingCardCmsService>();
builder.Services.AddHttpClient<PermisoCmsService>();
builder.Services.AddHttpClient<PiePaginaCmsService>();
builder.Services.AddHttpClient<PiePaginaDetCmsService>();
builder.Services.AddHttpClient<ProveedorCmsService>();
builder.Services.AddHttpClient<PuestoCmsService>();
builder.Services.AddHttpClient<RedesSocialesCmsService>();
builder.Services.AddHttpClient<RolCmsService>();
builder.Services.AddHttpClient<RubroCmsService>();
builder.Services.AddHttpClient<ServicioCabeceraCmsService>();
builder.Services.AddHttpClient<ServicioDetalleCmsService>();
builder.Services.AddHttpClient<SlideCmsService>();
builder.Services.AddHttpClient<UsuarioCmsService>();
builder.Services.AddHttpClient<UsuarioService>();
builder.Services.AddHttpClient<UbigeoServicioscmsService>();
builder.Services.AddHttpClient<EstacionamientoCmsService>();
builder.Services.AddHttpClient<PostulacionCmsService>(); 
builder.Services.AddMvc()
        .AddSessionStateTempDataProvider();
builder.Services.AddSession();
builder.Services.AddSingleton<PathProvider>();
builder.Services.AddSingleton<HelperUploadFiles>();
builder.Services.AddSingleton<CopiarImagenes>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddMemoryCache();
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
var minutosCache = 10;
app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-store, no-cache";
    var cache = context.RequestServices.GetRequiredService<IMemoryCache>();
    var httpContextAccessor = context.RequestServices.GetRequiredService<IHttpContextAccessor>();
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

    var userActivityCookie = context.Request.Cookies["LastActivity"];

    if (string.IsNullOrEmpty(userActivityCookie))
    {
        context.Response.Cookies.Append("LastActivity", DateTime.UtcNow.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMinutes(minutosCache) });

        if (!cache.TryGetValue("users_list", out List<TbConfUser> listUsers))
        {
            var usuariosService = context.RequestServices.GetRequiredService<UsuarioCmsService>();
            listUsers = await usuariosService.listarUsuarios();
            cache.Set("users_list", listUsers, TimeSpan.FromMinutes(minutosCache));
        }

        if (!cache.TryGetValue("permisos_list", out List<TbConfPermiso> listPermisos))
        {
            var permisosService = context.RequestServices.GetRequiredService<PermisoCmsService>();
            listPermisos = await permisosService.listarPermisos();
            cache.Set("permisos_list", listPermisos, TimeSpan.FromMinutes(minutosCache));
        }

        if (!cache.TryGetValue("menus_list", out List<TbConfMenu> listMenus))
        {
            var menusService = context.RequestServices.GetRequiredService<MenuCmsService>();
            listMenus = await menusService.listarMenus();
            cache.Set("menus_list", listMenus, TimeSpan.FromMinutes(minutosCache));
        }

        if (!cache.TryGetValue("contactanos_list", out List<TbFormContactano> listContactanos))
        {
            var contactanosService = context.RequestServices.GetRequiredService<ContactanoCmsService>();
            listContactanos = await contactanosService.ListarContactos();
            cache.Set("contactanos_list", listContactanos, TimeSpan.FromMinutes(minutosCache));
        }
        if (!cache.TryGetValue("servicioscab_list", out List<TbServCabecera> listServicioscab))
        {
            var servicioscabService = context.RequestServices.GetRequiredService<ServicioCabeceraCmsService>();
            listServicioscab = await servicioscabService.listarServiciosCabecera();
            cache.Set("servicioscab_list", listServicioscab, TimeSpan.FromMinutes(minutosCache));
        }
        if (!cache.TryGetValue("proveedores_list", out List<TbFormProveedore> listProveedores))
        {
            var proveedoresService = context.RequestServices.GetRequiredService<ProveedorCmsService>();
            listProveedores = await proveedoresService.ListarProveedores();
            cache.Set("proveedores_list", listProveedores, TimeSpan.FromMinutes(minutosCache));
        }
        if (!cache.TryGetValue("reclamaciones_list", out List<TbFormHojareclamacione> listReclamaciones))
        {
            var reclamacionesService = context.RequestServices.GetRequiredService<HojaReclamacioneCmsService>();
            listReclamaciones = await reclamacionesService.ListarHojaReclamaciones();
            cache.Set("reclamaciones_list", listReclamaciones, TimeSpan.FromMinutes(minutosCache));
        }
        if (!cache.TryGetValue("parkingcard_list", out List<TbFormParkingcard> listParkingCards))
        {
            var parkingcardService = context.RequestServices.GetRequiredService<ParkingCardCmsService>();
            listParkingCards = await parkingcardService.ListarParkingCard();
            cache.Set("parkingcard_list", listParkingCards, TimeSpan.FromMinutes(minutosCache));
        }
        if (!cache.TryGetValue("puestos_list", out List<TbTraPuesto> listPuestos))
        {
            var puestosService = context.RequestServices.GetRequiredService<PuestoCmsService>();
            listPuestos = await puestosService.puestoListar();
            cache.Set("puestos_list", listPuestos, TimeSpan.FromMinutes(minutosCache));
        }
    }
    else
    {
        var lastActivityTime = DateTime.Parse(userActivityCookie);

        if (DateTime.UtcNow.Subtract(lastActivityTime).TotalMinutes > minutosCache)
        {
            logger.LogInformation("10 minutos han pasado, redirigiendo a Home/Index...");

            // Establecer la cabecera de respuesta para redirigir al cliente
            context.Response.Headers["Location"] = "/DashbordCms/Index";
            context.Response.StatusCode = (int)HttpStatusCode.Redirect;
            return;
        }
        else
        {
            context.Response.Cookies.Append("LastActivity", DateTime.UtcNow.ToString(), new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMinutes(minutosCache) });
        }
    }
    await next.Invoke();
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DashbordCms}/{action=Index}/{id?}");

app.Run();