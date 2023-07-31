using ApiBD.Models;
using System.Net;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class ServicioCabeceraCmsService
    {
        private readonly HttpClient _httpClient;
        public ServicioCabeceraCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TbServCabecera>> listarServiciosCabecera()
        {
            List<TbServCabecera> servicioCabecera = new List<TbServCabecera>();

            try
            {
                var url = "http://localhost:82/api/servicioCabecera/cms";

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
            var url = $"http://localhost:82/api/servicioCabecera/{id}";

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
            var url = "http://localhost:82/api/servicioCabecera";

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
            var url = $"http://localhost:82/api/servicioCabecera/{id}";

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
            var url = $"http://localhost:82/api/servicioCabecera/{id}";

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
