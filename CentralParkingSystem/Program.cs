using ApiBD.Models;
using CentralParkingSystem.Helpers;
using CentralParkingSystem.Services;


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
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
