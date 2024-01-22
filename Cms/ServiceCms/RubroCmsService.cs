using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class RubroCmsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public RubroCmsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<TbConfRubro>> listarRubros()
        {
            List<TbConfRubro> Rubros = new List<TbConfRubro>();

            try
            {
                var url = "/api/rubro";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Rubros = JsonSerializer.Deserialize<List<TbConfRubro>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return Rubros;
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

            return Rubros;
        }

        public async Task<TbConfRubro> obtenerRubroDetalle(int id)
        {
            var url = $"/api/rubro/{id}"; 

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var rol = await response.Content.ReadFromJsonAsync<TbConfRubro>();
                return rol;
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

        public async Task<TbConfRubro> crearRubro(TbConfRubro TbConfRubro)
        {
            var url = "/api/rubro"; 

            var response = await _httpClient.PostAsJsonAsync(url, TbConfRubro);

            if (response.IsSuccessStatusCode)
            {
                var crearRol = await response.Content.ReadFromJsonAsync<TbConfRubro>();
                return crearRol;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }


        public async Task<TbConfRubro> modificarRubro(int id, TbConfRubro TbConfRubro)
        {
            var url = $"/api/rubro/{id}"; 

            var response = await _httpClient.PutAsJsonAsync(url, TbConfRubro);

            if (response.IsSuccessStatusCode)
            {
                var modificarRol = await response.Content.ReadFromJsonAsync<TbConfRubro>();
                return modificarRol;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarRubro(int id)
        {
            var url = $"/api/rubro/{id}"; 

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
