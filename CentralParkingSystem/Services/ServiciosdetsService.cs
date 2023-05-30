using ApiBD.Models;
using CentralParkingSystem.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CentralParkingSystem.Services
{
    public class ServiciosdetsService
    {
        private readonly HttpClient _httpClient;

        public ServiciosdetsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TbIndServiciodet>> ListarServiciosdets()
        {
            List<TbIndServiciodet> serviciosDets = new List<TbIndServiciodet>();

            try
            {
                var url = "https://localhost:7260/api/serviciosdet";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    serviciosDets = JsonSerializer.Deserialize<List<TbIndServiciodet>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return serviciosDets;
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

            return serviciosDets;
        }
    }
}
