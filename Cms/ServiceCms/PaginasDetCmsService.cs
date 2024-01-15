using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class PaginasDetCmsService
    {

        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("Properties", "launchSettings.json");
        private string apiUrl = "";
        public PaginasDetCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            if (File.Exists(launchSettingsPath))
            {
                var launchSettingsJson = File.ReadAllText(launchSettingsPath);
                var launchSettings = JObject.Parse(launchSettingsJson);

                // Acceder al perfil "ApiBD" y obtener la URL
                apiUrl = launchSettings["profiles"]?["Cms"]?["apiUrl"]?.ToString();
            }
        }

        public async Task<List<TbConfPaginasdet>> paginasDetListar()
        {
            List<TbConfPaginasdet> paginasDets = new List<TbConfPaginasdet>();

            try
            {
                var url = apiUrl+"/api/paginasdet";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    paginasDets = JsonSerializer.Deserialize<List<TbConfPaginasdet>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return paginasDets;
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

            return paginasDets;
        }

        public async Task<TbConfPaginasdet> obtenerPaginaDetDetalle(int id)
        {
            var response = await _httpClient.GetAsync($"{apiUrl}/api/paginasdet/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var pagina = JsonSerializer.Deserialize<TbConfPaginasdet>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return pagina;
            }

            
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            throw new Exception("Error al obtener el objeto TbConfPaginascab.");
        }

        public async Task<TbConfPaginasdet> crearPaginaDet(TbConfPaginasdet tbConfPaginasdet)
        {
            var url = apiUrl + "/api/paginasdet";

            var response = await _httpClient.PostAsJsonAsync(url, tbConfPaginasdet);

            if (response.IsSuccessStatusCode)
            {
                var createdPaginasDets = await response.Content.ReadFromJsonAsync<TbConfPaginasdet>();
                return createdPaginasDets;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbConfPaginasdet> modificarPaginaDet(int id, TbConfPaginasdet tbConfPaginasdet)
        {
            var url = $"{apiUrl}/api/paginasdet/{id}"; 

            var response = await _httpClient.PutAsJsonAsync(url, tbConfPaginasdet);

            if (response.IsSuccessStatusCode)
            {
                var updatedPaginaDet = await response.Content.ReadFromJsonAsync<TbConfPaginasdet>();
                return updatedPaginaDet;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarPaginaDet(int id)
        {
            var url = $"{apiUrl}/api/paginasdet/{id}"; 

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
