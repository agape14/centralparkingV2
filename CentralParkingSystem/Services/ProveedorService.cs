using ApiBD.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class ProveedorService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public ProveedorService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<TbFormProveedore>> ListarProveedores()
        {
            List<TbFormProveedore> proveedor = new List<TbFormProveedore>();

            try
            {
                var url = "/api/proveedor";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    proveedor = JsonSerializer.Deserialize<List<TbFormProveedore>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return proveedor;
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

            return proveedor;
        }

        public async Task<TbFormProveedore> obtenerProveedorDetalle(int id)
        {
            var url = $"/api/proveedor/{id}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var proveedor = await response.Content.ReadFromJsonAsync<TbFormProveedore>();
                return proveedor;
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

        public async Task<TbFormProveedore> crearProveedorRegistro(TbFormProveedore tbFormProveedore)
        {
            var url = "/api/proveedor";

            var response = await _httpClient.PostAsJsonAsync(url, tbFormProveedore);

            if (response.IsSuccessStatusCode)
            {
                var proveedor = await response.Content.ReadFromJsonAsync<TbFormProveedore>();
                return proveedor;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbFormProveedore> modificarProveedor(int id, TbFormProveedore tbFormProveedore)
        {
            var url = $"/api/proveedor/{id}";

            var response = await _httpClient.PutAsJsonAsync(url, tbFormProveedore);

            if (response.IsSuccessStatusCode)
            {
                var updatedProveedor = await response.Content.ReadFromJsonAsync<TbFormProveedore>();
                return updatedProveedor;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarProveedor(int id)
        {
            var url = $"/api/proveedor/{id}";

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
