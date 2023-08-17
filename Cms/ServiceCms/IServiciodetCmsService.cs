using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IServiciodetCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TbIndServiciodet>> filtrarPorCodigo(int codigo)
        {
            var url = $"http://localhost:82/api/serviciosdet/filtrarPorCodigo/{codigo}"; 

            
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
            var url = $"http://localhost:82/api/serviciosdet/Details/{id}/{codigo}";

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
            var url = "http://localhost:82/api/serviciosdet";

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
            var url = $"http://localhost:82/api/serviciosdet/{id}"; // Reemplaza con la URL correcta de tu API

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
            var url = $"http://localhost:82/api/serviciosdet/{id}"; 

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
            var url = $"http://localhost:82/api/serviciosdet/{id}"; 

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

    }
}
