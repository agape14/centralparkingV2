using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class HojaReclamacioneService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("Properties", "launchSettings.json");
        private string apiUrl = "";
        public HojaReclamacioneService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            if (File.Exists(launchSettingsPath))
            {
                var launchSettingsJson = File.ReadAllText(launchSettingsPath);
                var launchSettings = JObject.Parse(launchSettingsJson);

                // Acceder al perfil "ApiBD" y obtener la URL
                apiUrl = launchSettings["profiles"]?["CentralParkingSystem"]?["apiUrl"]?.ToString();
            }
        }

        public async Task<List<TbFormHojareclamacione>> ListarHojaReclamaciones()
        {
            List<TbFormHojareclamacione> lista = new List<TbFormHojareclamacione>();

            try
            {
                var url = apiUrl+"/api/hojareclamaciones";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    lista = JsonSerializer.Deserialize<List<TbFormHojareclamacione>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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

        public async Task<TbFormHojareclamacione> obtenerHojaReclamacionesDetalle(int id)
        {
            var url = $"{apiUrl}/ api/hojareclamaciones/{id}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var hoja = await response.Content.ReadFromJsonAsync<TbFormHojareclamacione>();
                return hoja;
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

        public async Task<TbFormHojareclamacione> crearHojaReclamacioneRegistro(TbFormHojareclamacione tbFormHojareclamacione)
        {
            var url = apiUrl + "/api/hojareclamaciones";

            var response = await _httpClient.PostAsJsonAsync(url, tbFormHojareclamacione);

            if (response.IsSuccessStatusCode)
            {
                var hoja = await response.Content.ReadFromJsonAsync<TbFormHojareclamacione>();
                return hoja;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbFormHojareclamacione> modificarHojaReclamacion(int id, TbFormHojareclamacione tbFormHojareclamacione)
        {
            var url = $"{apiUrl}/ api/hojareclamaciones/{id}";

            var response = await _httpClient.PutAsJsonAsync(url, tbFormHojareclamacione);

            if (response.IsSuccessStatusCode)
            {
                var updatedHoja = await response.Content.ReadFromJsonAsync<TbFormHojareclamacione>();
                return updatedHoja;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarHojaReclamacion(int id)
        {
            var url = $"{apiUrl}/api/hojareclamaciones/{id}";

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
