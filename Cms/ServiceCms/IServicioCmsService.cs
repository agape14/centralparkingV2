using ApiBD.Models;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using System.Text;

namespace Cms.ServiceCms
{
    public class IServicioCmsService
    {
        private readonly HttpClient _httpClient;

        public IServicioCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TbIndServiciocab> obtenerServicioDetalle(int id)
        {
            var url = $"https://localhost:7260/api/servicios/{id}"; // Reemplaza con la URL correcta de tu API

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
            var url = "https://localhost:7260/api/servicios"; // Reemplaza con la URL correcta de tu API REST

            // Serializa el objeto servicio a JSON
            var json = JsonSerializer.Serialize(servicio);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Envía la solicitud HTTP POST para crear el servicio
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            // Verifica si la respuesta es exitosa
            if (response.IsSuccessStatusCode)
            {
                // Lee el contenido de la respuesta como un objeto TbIndServiciocab
                var responseJson = await response.Content.ReadAsStringAsync();
                var createdServicio = JsonSerializer.Deserialize<TbIndServiciocab>(responseJson);
                return createdServicio;
            }
            else
            {
                // Ocurrió un error inesperado
                throw new Exception($"Error al crear el servicio. Código de estado: {response.StatusCode}");
            }
        }

        public async Task<TbIndServiciocab> editarServicio(int id, TbIndServiciocab servicio)
        {
            var url = $"https://localhost:7260/api/servicios/{id}"; // Reemplaza con la URL correcta de tu API REST

            // Serializa el objeto servicio a JSON
            var json = JsonSerializer.Serialize(servicio);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Envía la solicitud HTTP PUT para actualizar el servicio
            HttpResponseMessage response = await _httpClient.PutAsync(url, content);

            // Verifica si la respuesta es exitosa
            if (response.IsSuccessStatusCode)
            {
                // Lee el contenido de la respuesta como un objeto TbIndServiciocab
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
                // Ocurrió un error inesperado
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar el servicio. Código de estado: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task eliminarServicio(int id)
        {
            var url = $"https://localhost:7260/api/servicios/{id}"; // Reemplaza con la URL correcta de tu API REST

            // Envía la solicitud HTTP DELETE para eliminar el servicio
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);

            // Verifica si la respuesta es exitosa
            if (response.IsSuccessStatusCode)
            {
                // El servicio se eliminó correctamente
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("El servicio no fue encontrado.");
            }
            else
            {
                // Ocurrió un error inesperado
                throw new Exception($"Error al eliminar el servicio. Código de estado: {response.StatusCode}");
            }
        }


    }
}
