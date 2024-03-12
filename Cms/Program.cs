using ApiBD.Models;
using Cms.Helpers;
using Cms.Providers;
using Cms.Service;
using Cms.ServiceCms;

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

builder.Services.AddMvc()
        .AddSessionStateTempDataProvider();
builder.Services.AddSession();
builder.Services.AddSingleton<PathProvider>();
builder.Services.AddSingleton<HelperUploadFiles>();
builder.Services.AddSingleton<CopiarImagenes>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DashbordCms}/{action=Index}/{id?}");

app.Run();