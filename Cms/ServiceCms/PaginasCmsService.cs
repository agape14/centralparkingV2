using ApiBD.Models;
using CentralParkingSystem.DTOs;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class PaginasCmsService
    {
        private readonly HttpClient _httpClient;

        public PaginasCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TbConfPaginascab>> paginasListar()
        {
            List<TbConfPaginascab> paginasCabs = new List<TbConfPaginascab>();

            try
            {
                var url = "https://localhost:7260/api/paginas";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    paginasCabs = JsonSerializer.Deserialize<List<TbConfPaginascab>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return paginasCabs;
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

            return paginasCabs;
        }

        public async Task<TbConfPaginascab> obtenerPaginaDetalle(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7260/api/paginas/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var pagina = JsonSerializer.Deserialize<TbConfPaginascab>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return pagina;
            }

            // Manejar otros códigos de estado de respuesta según tus necesidades
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            throw new Exception("Error al obtener el objeto TbConfPaginascab.");
        }

        public async Task<TbConfPaginascab> crearPagina(TbConfPaginascab tbConfPaginascab)
        {
            var url = "https://localhost:7260/api/paginas"; // Reemplaza con la URL correcta de tu API

            var response = await _httpClient.PostAsJsonAsync(url, tbConfPaginascab);

            if (response.IsSuccessStatusCode)
            {
                var createdPaginasCabs = await response.Content.ReadFromJsonAsync<TbConfPaginascab>();
                return createdPaginasCabs;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }


        public async Task<TbConfPaginascab> modificarPagina(int id, TbConfPaginascab tbConfPaginascab)
        {
            var url = $"https://localhost:7260/api/paginas/{id}"; // Reemplaza con la URL correcta de tu API

            var response = await _httpClient.PutAsJsonAsync(url, tbConfPaginascab);

            if (response.IsSuccessStatusCode)
            {
                var updatedPagina = await response.Content.ReadFromJsonAsync<TbConfPaginascab>();
                return updatedPagina;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarPagina(int id)
        {
            var url = $"https://localhost:7260/api/paginas/{id}"; // Reemplaza con la URL correcta de tu API

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
