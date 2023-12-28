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
        private string launchSettingsPath = Path.Combine("..", "ApiBD", "Properties", "launchSettings.json");
        private string apiUrl = "";
        public CaracteristicasService(HttpClient httpClient)
        { 
            _httpClient = httpClient;
            if (File.Exists(launchSettingsPath))
            {
                var launchSettingsJson = File.ReadAllText(launchSettingsPath);
                var launchSettings = JObject.Parse(launchSettingsJson);

                // Acceder al perfil "ApiBD" y obtener la URL
                apiUrl = launchSettings["profiles"]?["ApiBD"]?["applicationUrl"]?.ToString();
            }
        }


        public async Task<List<TbIndCaracteristica>> ListarCaracteristicas()
        {
            List<TbIndCaracteristica> caracteristicas = new List<TbIndCaracteristica>();

            try
            {
                var url = apiUrl+"/api/caracteristica";

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
