using ApiBD.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Añade los servicios de Swagger y Endpoint API Explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CentralParkingContext>(optionsAction:_ =>
{
    _.UseMySql(connectionString:"server=localhost;port=3310;user=root;password=admin;database=centralparking", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.19-mariadb"));
});

var app = builder.Build();

// Configure el pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();