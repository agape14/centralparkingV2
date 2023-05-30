using ApiBD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//builder.Services.AddDbContext<CentralParkingContext>(optionsAction: _ =>
//{
//    _.UseMySql(connectionString: "server=localhost;port=3310;user=root;password=admin;database=centralparking", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.19-mariadb"));
//});

//builder.Services.AddDbContext<CentralParkingContext>(options => options.UseMySql(configuration.GetConnectionString(nameof(BooksContext))));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CentralParkingContext>();


builder.Services.AddMvc()
        .AddSessionStateTempDataProvider();
builder.Services.AddSession();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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