using ApiBD.Models;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class ServicioCabeceraService
    {
        private readonly HttpClient _httpClient;
        public ServicioCabeceraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<TbServCabecera>> ListarServicios()
        {
            List<TbServCabecera> servicios = new List<TbServCabecera>();

            try
            {
                var url = "http://localhost:82/api/servicioCabecera";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    servicios = JsonSerializer.Deserialize<List<TbServCabecera>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return servicios;
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

            return servicios;
        }

    }
}
