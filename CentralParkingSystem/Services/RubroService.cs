using ApiBD.Models;
using System.Net;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class RubroService
    {
        private readonly HttpClient _httpClient;

        public RubroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TbConfRubro>> ListarRubros()
        {
            List<TbConfRubro> rubros = new List<TbConfRubro>();

            try
            {
                var url = "http://localhost:82/api/rubro";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    rubros = JsonSerializer.Deserialize<List<TbConfRubro>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return rubros;
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

            return rubros;
        }

    }
}
