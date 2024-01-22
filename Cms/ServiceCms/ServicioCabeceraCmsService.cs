using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class ServicioCabeceraCmsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public ServicioCabeceraCmsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<TbServCabecera>> listarServiciosCabecera()
        {
            List<TbServCabecera> servicioCabecera = new List<TbServCabecera>();

            try
            {
                var url = "/api/servicioCabecera/cms";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    servicioCabecera = JsonSerializer.Deserialize<List<TbServCabecera>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return servicioCabecera;
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

            return servicioCabecera;
        }

        public async Task<TbServCabecera> obtenerServicioCabecera(int id)
        {
            var url = $"/api/servicioCabecera/{id}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var servicio = await response.Content.ReadFromJsonAsync<TbServCabecera>();
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

        public async Task<TbServCabecera> crearServicioCabecera(TbServCabecera tbServCabecera)
        {
            var url = "/api/servicioCabecera";

            var response = await _httpClient.PostAsJsonAsync(url, tbServCabecera);

            if (response.IsSuccessStatusCode)
            {
                var createdServicio = await response.Content.ReadFromJsonAsync<TbServCabecera>();
                return createdServicio;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbServCabecera> modificarServicioCabecera(int id, TbServCabecera tbServCabecera)
        {
            var url = $"/api/servicioCabecera/{id}";

            var response = await _httpClient.PutAsJsonAsync(url, tbServCabecera);

            if (response.IsSuccessStatusCode)
            {
                var modificarServicioCabecera = await response.Content.ReadFromJsonAsync<TbServCabecera>();
                return modificarServicioCabecera;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarServicioCabecera(int id)
        {
            var url = $"/api/servicioCabecera/{id}";

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

        public async Task<List<TbIndServiciocab>> ListarServiciosCabs()
        {
            List<TbIndServiciocab> serviciosCabs = new List<TbIndServiciocab>();

            try
            {
                var url = "/api/servicios";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    serviciosCabs = JsonSerializer.Deserialize<List<TbIndServiciocab>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return serviciosCabs;
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

            return serviciosCabs;
        }
    }
}
