using ApiBD.Models;
using CentralParkingSystem.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CentralParkingSystem.Services
{
    public class PiePaginaDetsService
    {
        private readonly HttpClient _httpClient;
        public PiePaginaDetsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<TbConfPiepaginadet>> ListarPiePaginaDets()
        {

            List<TbConfPiepaginadet> piePaginaDets = new List<TbConfPiepaginadet>();

            try
            {
                var url = "https://localhost:7260/api/piepaginadet";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    piePaginaDets = JsonSerializer.Deserialize<List<TbConfPiepaginadet>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return piePaginaDets;
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

            return piePaginaDets;

        }
    }
}
