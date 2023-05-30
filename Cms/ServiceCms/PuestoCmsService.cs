using ApiBD.Models;
using System.Net;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class PuestoCmsService
    {
        private readonly HttpClient _httpClient;

        public PuestoCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TbTraPuesto>> puestoListar()
        {
            List<TbTraPuesto> puestos = new List<TbTraPuesto>();

            try
            {
                var url = "https://localhost:7260/api/puesto";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    puestos = JsonSerializer.Deserialize<List<TbTraPuesto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return puestos;
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

            return puestos;
        }

        public async Task<TbTraPuesto> obtenerPuestoDetalle(int id)
        {
            var url = $"https://localhost:7260/api/puesto/{id}"; // Reemplaza con la URL correcta de tu API

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var puesto = await response.Content.ReadFromJsonAsync<TbTraPuesto>();
                return puesto;
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

        public async Task<TbTraPuesto> crearPuesto(TbTraPuesto tbTraPuesto)
        {
            var url = "https://localhost:7260/api/puesto"; // Reemplaza con la URL correcta de tu API

            var response = await _httpClient.PostAsJsonAsync(url, tbTraPuesto);

            if (response.IsSuccessStatusCode)
            {
                var crearPuesto = await response.Content.ReadFromJsonAsync<TbTraPuesto>();
                return crearPuesto;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbTraPuesto> modificarPuesto(int id, TbTraPuesto tbTraPuesto)
        {
            var url = $"https://localhost:7260/api/puesto/{id}"; // Reemplaza con la URL correcta de tu API

            var response = await _httpClient.PutAsJsonAsync(url, tbTraPuesto);

            if (response.IsSuccessStatusCode)
            {
                var modificarPuesto = await response.Content.ReadFromJsonAsync<TbTraPuesto>();
                return modificarPuesto;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarPuesto(int id)
        {
            var url = $"https://localhost:7260/api/puesto/{id}"; // Reemplaza con la URL correcta de tu API

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
