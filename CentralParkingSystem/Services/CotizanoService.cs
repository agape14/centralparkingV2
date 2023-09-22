using ApiBD.Models;
using System.Net;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class CotizanosService
    {
        private readonly HttpClient _httpClient;

        public CotizanosService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TbFormCotizano>> ListarCotizanos(int codigo)
        {
            List<TbFormCotizano> cotizanos = new List<TbFormCotizano>();

            try
            {
                var url = $"http://localhost:82/api/cotizanos/tipoServicio/{codigo}";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    cotizanos = JsonSerializer.Deserialize<List<TbFormCotizano>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return cotizanos;
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

            return cotizanos;
        }

        public async Task<TbFormCotizano> obtenerCotizanoDetalle(int id)
        {
            var url = $"http://localhost:82/api/cotizanos/{id}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var contacto = await response.Content.ReadFromJsonAsync<TbFormCotizano>();
                return contacto;
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

        public async Task<TbFormCotizano> crearCotizanoRegistro(TbFormCotizano tbFormCotizanos)
        {
            var url = "http://localhost:82/api/cotizanos";

            var response = await _httpClient.PostAsJsonAsync(url, tbFormCotizanos);

            if (response.IsSuccessStatusCode)
            {
                var contacto = await response.Content.ReadFromJsonAsync<TbFormCotizano>();
                return contacto;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbFormCotizano> modificarCotizano(int id, TbFormCotizano tbFormCotizanos)
        {
            var url = $"http://localhost:82/api/cotizanos/{id}";

            var response = await _httpClient.PutAsJsonAsync(url, tbFormCotizanos);

            if (response.IsSuccessStatusCode)
            {
                var updatedCotizano = await response.Content.ReadFromJsonAsync<TbFormCotizano>();
                return updatedCotizano;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarCotizano(int id)
        {
            var url = $"http://localhost:82/api/cotizanos/{id}";

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

