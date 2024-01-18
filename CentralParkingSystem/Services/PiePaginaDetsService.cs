using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CentralParkingSystem.Services
{
    public class PiePaginaDetsService
    {
        private readonly HttpClient _httpClient;
        private readonly string apiUrl;

        public PiePaginaDetsService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            var launchSettingsPath = Path.Combine("CentralParkingSystem", "Properties", "launchSettings.json");
            if (File.Exists(launchSettingsPath))
            {
                var launchSettingsJson = File.ReadAllText(launchSettingsPath);
                var launchSettings = JObject.Parse(launchSettingsJson);

                // Acceder al perfil "ApiBD" y obtener la URL
                apiUrl = launchSettings["profiles"]?["CentralParkingSystem"]?["apiUrl"]?.ToString();

                if (!string.IsNullOrWhiteSpace(apiUrl))
                {
                    _httpClient.BaseAddress = new Uri(apiUrl);
                }
                else
                {
                    throw new InvalidOperationException("La URL de la API no está configurada correctamente.");
                }
            }
            else
            {
                throw new FileNotFoundException("El archivo launchSettings.json no se encontró.");
            }
        }

        public async Task<List<TbConfPiepaginadet>> ListarPiePaginaDets()
        {
            List<TbConfPiepaginadet> piePaginaDets = new List<TbConfPiepaginadet>();

            try
            {
                var url = "/api/piepaginadet";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    piePaginaDets = JsonSerializer.Deserialize<List<TbConfPiepaginadet>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return piePaginaDets;
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

            return piePaginaDets;
        }
    }
}
