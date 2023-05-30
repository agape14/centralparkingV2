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
            var url = $"https://localhost:7260/api/serviciosdet/filtrarPorCodigo/{codigo}"; // Reemplaza con la URL correcta de tu API REST

            // Envía la solicitud HTTP GET para obtener la lista de servicio detalles filtrada por código
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            // Verifica si la respuesta es exitosa
            if (response.IsSuccessStatusCode)
            {
                // Deserializa el contenido de la respuesta a una lista de objetos TbIndServiciodet
                var servicioDetalles = await response.Content.ReadFromJsonAsync<List<TbIndServiciodet>>();

                return servicioDetalles;
            }
            else
            {
                // Ocurrió un error inesperado
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener los detalles de servicio. Código de estado: {response.StatusCode}, {errorContent}");
            }
        }




       
        public async Task<TbIndServiciodet> obtenerServicioDetDetalle(int id, int codigo)
        {
            var url = $"https://localhost:7260/api/serviciosdet/Details/{id}/{codigo}";

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
            var url = "https://localhost:7260/api/serviciosdet";

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



    }
}
