using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class RubroService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("..", "ApiBD", "Properties", "launchSettings.json");
        private string apiUrl = "";
        public RubroService(HttpClient httpClient)
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

        public async Task<List<TbConfRubro>> ListarRubros()
        {
            List<TbConfRubro> rubros = new List<TbConfRubro>();

            try
            {
                var url = apiUrl+"/api/rubro";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    rubros = JsonSerializer.Deserialize<List<TbConfRubro>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return rubros;
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

            return rubros;
        }

    }
}
