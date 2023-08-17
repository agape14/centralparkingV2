using ApiBD.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Añade los servicios de Swagger y Endpoint API Explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CentralParkingContext>();

var app = builder.Build();


// Configure el pipeline de solicitud HTTP

if (app.Environment.IsProduction())
{
    
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIBD"); });

}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();