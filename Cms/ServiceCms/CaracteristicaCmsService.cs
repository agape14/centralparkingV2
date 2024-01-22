using ApiBD.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class CaracteristicaCmsService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public CaracteristicaCmsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }
        public async Task<List<TbIndCaracteristica>> ListarCaracteristicas()
        {
            List<TbIndCaracteristica> caracteristicas = new List<TbIndCaracteristica>();

            try
            {
                var url = "/api/caracteristica";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    caracteristicas = JsonSerializer.Deserialize<List<TbIndCaracteristica>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return caracteristicas;
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

            return caracteristicas;
        }

        public async Task<TbIndCaracteristica> obtenerCaracteristicaDetalle(uint id)
        {
            var url = $"/api/caracteristica/{id}"; 

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var caracteristica = await response.Content.ReadFromJsonAsync<TbIndCaracteristica>();
                return caracteristica;
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


        public async Task<TbIndCaracteristica> crearCaracteristica(TbIndCaracteristica caracteristica)
        {
            var url = "/api/caracteristica"; 

            var response = await _httpClient.PostAsJsonAsync(url, caracteristica);

            if (response.IsSuccessStatusCode)
            {
                var createdCaracteristica = await response.Content.ReadFromJsonAsync<TbIndCaracteristica>();
                return createdCaracteristica;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbIndCaracteristica> modificarCaracteristica(uint id, TbIndCaracteristica caracteristica)
        {
            var url = $"/api/caracteristica/{id}"; 

            var response = await _httpClient.PutAsJsonAsync(url, caracteristica);

            if (response.IsSuccessStatusCode)
            {
                var updatedCaracteristica = await response.Content.ReadFromJsonAsync<TbIndCaracteristica>();
                return updatedCaracteristica;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarCaracteristica(uint id)
        {
            var url = $"/api/caracteristica/{id}"; 

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
