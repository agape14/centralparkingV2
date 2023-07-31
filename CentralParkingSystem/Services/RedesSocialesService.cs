using CentralParkingSystem.DTOs;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class RedesSocialesService
    {
        private readonly HttpClient _httpClient;
        public RedesSocialesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RedesSociales>> ListarRedSociales()
        {
            List<RedesSociales> redesSociales = new List<RedesSociales>();

            try
            {
                var url = "http://localhost:82/api/entidades";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    redesSociales = JsonSerializer.Deserialize<List<RedesSociales>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return redesSociales;
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

            return redesSociales;
        }




    }
}
