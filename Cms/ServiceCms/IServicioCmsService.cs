using ApiBD.Models;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Cms.ServiceCms
{
    public class IServicioCmsService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("Properties", "launchSettings.json");
        private string apiUrl = "";
        public IServicioCmsService(HttpClient httpClient)
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
        public async Task<List<TbIndServiciocab>> ListarServiciosCabs()
        {
            List<TbIndServiciocab> serviciosCabs = new List<TbIndServiciocab>();

            try
            {
                var url = apiUrl + "/api/servicios";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    serviciosCabs = JsonSerializer.Deserialize<List<TbIndServiciocab>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return serviciosCabs;
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

            return serviciosCabs;
        }
        public async Task<TbIndServiciocab> obtenerServicioDetalle(int id)
        {
            var url = $"{apiUrl}/api/servicios/{id}"; 

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var servicio = await response.Content.ReadFromJsonAsync<TbIndServiciocab>();
                return servicio;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("El servicio no fue encontrado.");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }


        public async Task<TbIndServiciocab>  crearServicio(TbIndServiciocab servicio)
        {
            var url = apiUrl + "/api/servicios";

            
            var json = JsonSerializer.Serialize(servicio);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

         
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

          
            if (response.IsSuccessStatusCode)
            {
          
                var responseJson = await response.Content.ReadAsStringAsync();
                var createdServicio = JsonSerializer.Deserialize<TbIndServiciocab>(responseJson);
                return createdServicio;
            }
            else
            {
        
                throw new Exception($"Error al crear el servicio. Código de estado: {response.StatusCode}");
            }
        }

        public async Task<TbIndServiciocab> editarServicio(int id, TbIndServiciocab servicio)
        {
            var url = $"{apiUrl}/api/servicios/{id}"; 

         
            var json = JsonSerializer.Serialize(servicio);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

        
            HttpResponseMessage response = await _httpClient.PutAsync(url, content);

         
            if (response.IsSuccessStatusCode)
            {
            
                var responseJson = await response.Content.ReadAsStringAsync();
                var updatedServicio = JsonSerializer.Deserialize<TbIndServiciocab>(responseJson);
                return updatedServicio;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception("Solicitud incorrecta. Verifica los datos enviados.");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("El servicio no fue encontrado.");
            }
            else
            {
          
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar el servicio. Código de estado: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task eliminarServicio(int id)
        {
            var url = $"{apiUrl}/api/servicios/{id}"; 

           
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);

   
            if (response.IsSuccessStatusCode)
            {
              
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("El servicio no fue encontrado.");
            }
            else
            {
           
                throw new Exception($"Error al eliminar el servicio. Código de estado: {response.StatusCode}");
            }
        }


    }
}
