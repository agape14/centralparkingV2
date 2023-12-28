using ApiBD.Models;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Cms.ServiceCms
{
    public class RedesSocialesCmsService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("..", "ApiBD", "Properties", "launchSettings.json");
        private string apiUrl = "";
        public RedesSocialesCmsService(HttpClient httpClient)
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

        public async Task<List<TbIndRedsocial>> listarRedesSociales()
        {
            List<TbIndRedsocial> redesSociales = new List<TbIndRedsocial>();

            try
            {
                var url = apiUrl+"/api/redsocial";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    redesSociales = JsonSerializer.Deserialize<List<TbIndRedsocial>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return redesSociales;
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

            return redesSociales;
        }

        public async Task<TbIndRedsocial> obtenerRedSocialDetalle(int id)
        {
            var url = $"{apiUrl}/api/redsocial/{id}"; 

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var redSocial = await response.Content.ReadFromJsonAsync<TbIndRedsocial>();
                return redSocial;
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


        public async Task<TbIndRedsocial> crearRedSocial(TbIndRedsocial tbIndRedsocial)
        {
            var url = apiUrl + "/api/redsocial"; 

            var response = await _httpClient.PostAsJsonAsync(url, tbIndRedsocial);

            if (response.IsSuccessStatusCode)
            {
                var crearRedSocial = await response.Content.ReadFromJsonAsync<TbIndRedsocial>();
                return crearRedSocial;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbIndRedsocial> modificarRedSocial(int id, TbIndRedsocial tbIndRedsocial)
        {
            var url = $"{apiUrl}/api/redsocial/{id}";

            var response = await _httpClient.PutAsJsonAsync(url, tbIndRedsocial);

            if (response.IsSuccessStatusCode)
            {
                var modificarRedSocial = await response.Content.ReadFromJsonAsync<TbIndRedsocial>();
                return modificarRedSocial;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarRedSocial(int id)
        {
            var url = $"{apiUrl}/api/redsocial/{id}";

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
