using CentralParkingSystem.DTOs;
using System.Text.Json;


namespace CentralParkingSystem.Services
{
    public class EntidadesService
    {
        private readonly HttpClient _httpClient;

        public EntidadesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Entidades>> ListarEntidades()
        {
            List<Entidades> entidades = new List<Entidades>();

            try
            {
                var url = "https://localhost:7260/api/entidades";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    entidades = JsonSerializer.Deserialize<List<Entidades>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return entidades;
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

            return entidades;
        }
    }
}
