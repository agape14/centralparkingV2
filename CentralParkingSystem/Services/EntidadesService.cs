using CentralParkingSystem.DTOs;
using Newtonsoft.Json.Linq;
using System.Text.Json;


namespace CentralParkingSystem.Services
{
    public class EntidadesService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("..", "ApiBD", "Properties", "launchSettings.json");
        private string apiUrl = "";
        public EntidadesService(HttpClient httpClient)
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

        public async Task<List<Entidades>> ListarEntidades()
        {
            List<Entidades> entidades = new List<Entidades>();

            try
            {
                var url = apiUrl+ "/api/entidades";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    entidades = JsonSerializer.Deserialize<List<Entidades>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return entidades;
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

            return entidades;
        }
    }
}
