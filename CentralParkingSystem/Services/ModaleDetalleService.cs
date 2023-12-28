using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class ModaleDetalleService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("..", "ApiBD", "Properties", "launchSettings.json");
        private string apiUrl = "";
        public ModaleDetalleService(HttpClient httpClient)
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

       

        public async Task<List<TbConfModaldet>> listarModalDetalle(int id)
        {
            List<TbConfModaldet> lista = new List<TbConfModaldet>();

            try
            {
                var url = $"{apiUrl}/api/modaldetalle/detalle/{id}";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    lista = JsonSerializer.Deserialize<List<TbConfModaldet>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return lista;
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

            return lista;
        }

        public async Task<TbConfModaldet> obtenerModalDetalle(int id)
        {
            var url = $"{apiUrl}/api/modaldetalle/{id}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var modal = await response.Content.ReadFromJsonAsync<TbConfModaldet>();
                return modal;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("La característica no fue encontrada.");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbConfModaldet> crearModalDetRegistro(TbConfModaldet tbConfModaldet)
        {
            var url = apiUrl+"/api/modaldetalle";

            var response = await _httpClient.PostAsJsonAsync(url, tbConfModaldet);

            if (response.IsSuccessStatusCode)
            {
                var modal = await response.Content.ReadFromJsonAsync<TbConfModaldet>();
                return modal;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbConfModaldet> modificarModalDet(int id, TbConfModaldet tbConfModaldet)
        {
            var url = $"{apiUrl}/api/modaldetalle/{id}";

            var response = await _httpClient.PutAsJsonAsync(url, tbConfModaldet);

            if (response.IsSuccessStatusCode)
            {
                var modal = await response.Content.ReadFromJsonAsync<TbConfModaldet>();
                return modal;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarModalDet(int id)
        {
            var url = $"{apiUrl}/api/modaldetalle/{id}";

            var response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }
    }
}
