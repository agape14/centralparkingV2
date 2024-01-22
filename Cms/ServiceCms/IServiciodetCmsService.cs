using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cms.ServiceCms
{
    public class IServiciodetCmsService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public IServiciodetCmsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<TbIndServiciodet>> filtrarPorCodigo(int codigo)
        {
            var url = $"/api/serviciosdet/filtrarPorCodigo/{codigo}"; 

            
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            
            if (response.IsSuccessStatusCode)
            {
                
                var servicioDetalles = await response.Content.ReadFromJsonAsync<List<TbIndServiciodet>>();

                return servicioDetalles;
            }
            else
            {
                
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener los detalles de servicio. Código de estado: {response.StatusCode}, {errorContent}");
            }
        }




       
        public async Task<TbIndServiciodet> obtenerServicioDetDetalle(int id, int codigo)
        {
            var url = $"/api/serviciosdet/Details/{id}";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var serializedObject = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };
                var tbIndServiciodet = JsonSerializer.Deserialize<TbIndServiciodet>(serializedObject, options);
                return tbIndServiciodet;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener los detalles del servicio. Código de estado: {response.StatusCode}, {errorContent}");
            }
        }


        public async Task<ActionResult<TbIndServiciodet>> crearServicioDet(TbIndServiciodet serviciodet)
        {
            var url = "/api/serviciosdet";

            var serializedObject = JsonSerializer.Serialize(serviciodet);
            var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var createdServiciodet = JsonSerializer.Deserialize<TbIndServiciodet>(responseContent);

                return createdServiciodet;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear el servicio. Código de estado: {response.StatusCode}, {errorContent}");
            }
        }


        public async Task<bool> eliminarServicioDet(int id)
        {
            var url = $"/api/serviciosdet/{id}"; // Reemplaza con la URL correcta de tu API

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


        public async Task<TbIndServiciodet> obtenerServicioDeEspecificoDetalle(int id)
        {
            var url = $"/api/serviciosdet/{id}"; 

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var servicioDet = await response.Content.ReadFromJsonAsync<TbIndServiciodet>();
                return servicioDet;
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

        public async Task<TbIndServiciodet> modificarServicioDet(int id, TbIndServiciodet tbIndServiciodet)
        {
            var url = $"/api/serviciosdet/{id}"; 

            var response = await _httpClient.PutAsJsonAsync(url, tbIndServiciodet);

            if (response.IsSuccessStatusCode)
            {
                var modificarServicioDet = await response.Content.ReadFromJsonAsync<TbIndServiciodet>();
                return modificarServicioDet;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<List<TbIndServiciodet>> ListarServiciosdets()
        {
            List<TbIndServiciodet> serviciosDets = new List<TbIndServiciodet>();

            try
            {
                var url = "/api/serviciosdet";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    serviciosDets = JsonSerializer.Deserialize<List<TbIndServiciodet>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return serviciosDets;
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

            return serviciosDets;
        }
    }
}
