using ApiBD.Models;
using CentralParkingSystem.DTOs;
using Microsoft.AspNetCore.Hosting.Server;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class CaracteristicasService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public CaracteristicasService(HttpClient httpClient, IConfiguration configuration)
        { 
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }


        public async Task<List<TbIndCaracteristica>> ListarCaracteristicas()
        {
            List<TbIndCaracteristica> caracteristicas = new List<TbIndCaracteristica>();

            try
            {
                var url = "/api/caracteristica";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    caracteristicas = JsonSerializer.Deserialize<List<TbIndCaracteristica>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return caracteristicas;
                }
                else
                {
                    Console.WriteLine("No se ha podido conectar a la API");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return caracteristicas;
        }

    }
    
}
