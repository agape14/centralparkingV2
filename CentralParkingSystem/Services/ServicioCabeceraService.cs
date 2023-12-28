using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class ServicioCabeceraService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("..", "ApiBD", "Properties", "launchSettings.json");
        private string apiUrl = "";
        public ServicioCabeceraService(HttpClient httpClient)
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


        public async Task<List<TbServCabecera>> ListarServicios()
        {
            List<TbServCabecera> servicios = new List<TbServCabecera>();

            try
            {
                var url = apiUrl+"/api/servicioCabecera";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    servicios = JsonSerializer.Deserialize<List<TbServCabecera>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return servicios;
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

            return servicios;
        }

    }
}
