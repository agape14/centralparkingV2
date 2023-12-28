using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace CentralParkingSystem.Services
{
    public class PostulacionService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("..", "ApiBD", "Properties", "launchSettings.json");
        private string apiUrl = "";
        public PostulacionService(HttpClient httpClient)
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


        public async Task<TbFormTbcnosotro> crearPostulacion(TbFormTbcnosotro tbFormTbcnosotro)
        {
            var url = apiUrl+"/api/postulacion";

            var response = await _httpClient.PostAsJsonAsync(url, tbFormTbcnosotro);

            if (response.IsSuccessStatusCode)
            {
                var postulacion = await response.Content.ReadFromJsonAsync<TbFormTbcnosotro>();
                return postulacion;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }
    }
}
