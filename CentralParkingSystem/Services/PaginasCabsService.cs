using ApiBD.Models;
using CentralParkingSystem.DTOs;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class PaginasCabsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public PaginasCabsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<TbConfPaginascab> paginasCabsPorDefault()
        {
            TbConfPaginascab paginasCabs = new TbConfPaginascab();

            try
            {
                var url = "/api/paginas/nosotros";

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
