using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class ContactanoCmsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public ContactanoCmsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<TbFormContactano>> ListarContactos()
        {
            List<TbFormContactano> contactos = new List<TbFormContactano>();

            try
            {
                var url = "/api/contactanos";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    contactos = JsonSerializer.Deserialize<List<TbFormContactano>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return contactos;
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

            return contactos;
        }

        public async Task<TbFormContactano> obtenerContactoDetalle(int id)
        {
            var url = $"/api/contactanos/{id}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var contacto = await response.Content.ReadFromJsonAsync<TbFormContactano>();
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

        public async Task<TbFormContactano> crearContactoRegistro(TbFormContactano tbFormContactano)
        {
            var url = "/api/contactanos";

            var response = await _httpClient.PostAsJsonAsync(url, tbFormContactano);

            if (response.IsSuccessStatusCode)
            {
                var contacto = await response.Content.ReadFromJsonAsync<TbFormContactano>();
                return contacto;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbFormContactano> modificarContacto(int id, TbFormContactano tbFormContactano)
        {
            var url = $"/api/contactanos/{id}";

            var response = await _httpClient.PutAsJsonAsync(url, tbFormContactano);

            if (response.IsSuccessStatusCode)
            {
                var updatedContacto = await response.Content.ReadFromJsonAsync<TbFormContactano>();
                return updatedContacto;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarContacto(int id)
        {
            var url = $"/api/contactanos/{id}";

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
