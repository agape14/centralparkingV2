using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class ParkingCardService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public ParkingCardService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<TbFormParkingcard>> ListarParkingCard()
        {
            List<TbFormParkingcard> lista = new List<TbFormParkingcard>();

            try
            {
                var url = "/api/parkingcard";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    lista = JsonSerializer.Deserialize<List<TbFormParkingcard>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return lista;
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

            return lista;
        }

        public async Task<TbFormParkingcard> obtenerParkingCardDetalle(int id)
        {
            var url = $"/api/parkingcard/{id}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var parkingcard = await response.Content.ReadFromJsonAsync<TbFormParkingcard>();
                return parkingcard;
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

        public async Task<TbFormParkingcard> crearParkingCardRegistro(TbFormParkingcard tbFormParkingcard)
        {
            var url = "/api/parkingcard";

            var response = await _httpClient.PostAsJsonAsync(url, tbFormParkingcard);

            if (response.IsSuccessStatusCode)
            {
                var parkingcard = await response.Content.ReadFromJsonAsync<TbFormParkingcard>();
                return parkingcard;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbFormParkingcard> modificarParkingCard(int id, TbFormParkingcard tbFormParkingcard)
        {
            var url = $"/api/parkingcard/{id}";

            var response = await _httpClient.PutAsJsonAsync(url, tbFormParkingcard);

            if (response.IsSuccessStatusCode)
            {
                var updatedParkingCard = await response.Content.ReadFromJsonAsync<TbFormParkingcard>();
                return updatedParkingCard;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarParkingCard(int id)
        {
            var url = $"/api/parkingcard/{id}";

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
