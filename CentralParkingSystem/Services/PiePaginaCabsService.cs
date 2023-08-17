using CentralParkingSystem.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CentralParkingSystem.Services
{
    public class PiePaginaCabsService
    {
        private readonly HttpClient _httpClient;

        public PiePaginaCabsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PiePaginaCabs>> ListarPiePaginasCabs()
        {
            List<PiePaginaCabs> piePaginaCabs = new List<PiePaginaCabs>();

            try
            {
                var url = "http://localhost:82/api/piepagina";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    piePaginaCabs = JsonSerializer.Deserialize<List<PiePaginaCabs>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return piePaginaCabs;
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

            return piePaginaCabs;
        }
    }
}
