using ApiBD.Models;
using CentralParkingSystem.DTOs;
using Microsoft.AspNetCore.Hosting.Server;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class CaracteristicasService
    {
        private readonly HttpClient _httpClient;
        public CaracteristicasService(HttpClient httpClient)
        { 
            _httpClient = httpClient;
        }


        public async Task<List<TbIndCaracteristica>> ListarCaracteristicas()
        {
            List<TbIndCaracteristica> caracteristicas = new List<TbIndCaracteristica>();

            try
            {
                var url = "http://localhost:82/api/caracteristica";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    caracteristicas = JsonSerializer.Deserialize<List<TbIndCaracteristica>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return caracteristicas;
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

            return caracteristicas;
        }

    }
    
}
