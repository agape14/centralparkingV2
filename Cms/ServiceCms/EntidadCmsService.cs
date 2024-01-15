using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class EntidadCmsService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("Properties", "launchSettings.json");
        private string apiUrl = "";
        public EntidadCmsService(HttpClient httpClient)
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

        public async Task<List<TbConfEntidad>> listarEntidades()
        {
            List<TbConfEntidad> entidades = new List<TbConfEntidad>();

            try
            {
                var url = apiUrl+"/api/entidades/getEntidades";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    entidades = JsonSerializer.Deserialize<List<TbConfEntidad>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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

        public async Task<TbConfEntidad> obtenerEntidadDetalle(int id)
        {
            var url = $"{apiUrl}/api/entidades/{id}"; 

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var entidad = await response.Content.ReadFromJsonAsync<TbConfEntidad>();
                return entidad;
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

        public async Task<TbConfEntidad> crearEntidad(TbConfEntidad tbConfEntidad)
        {
            var url = apiUrl + "/api/entidades"; 

            var response = await _httpClient.PostAsJsonAsync(url, tbConfEntidad);

            if (response.IsSuccessStatusCode)
            {
                var crearEntidad = await response.Content.ReadFromJsonAsync<TbConfEntidad>();
                return crearEntidad;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbConfEntidad> modificarEntidad(int id, TbConfEntidad tbConfEntidad)
        {
            var url = $"{apiUrl}/api/entidades/{id}"; 

            var response = await _httpClient.PutAsJsonAsync(url, tbConfEntidad);

            if (response.IsSuccessStatusCode)
            {
                var modificarEntidad = await response.Content.ReadFromJsonAsync<TbConfEntidad>();
                return modificarEntidad;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarEntidad(int id)
        {
            var url = $"{apiUrl}/api/entidades/{id}"; 

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
