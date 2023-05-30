using ApiBD.Models;
using CentralParkingSystem.DTOs;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class PaginasCabsService
    {
        private readonly HttpClient _httpClient;

        public PaginasCabsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TbConfPaginascab> paginasCabsPorDefault()
        {
            TbConfPaginascab paginasCabs = new TbConfPaginascab();

            try
            {
                var url = "https://localhost:7260/api/paginas/nosotros";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    paginasCabs = JsonSerializer.Deserialize<TbConfPaginascab>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return paginasCabs;
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

            return paginasCabs;
        }
    }
}
