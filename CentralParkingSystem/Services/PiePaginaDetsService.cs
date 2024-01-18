using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CentralParkingSystem.Services
{
    public class PiePaginaDetsService
    {
        private readonly HttpClient _httpClient;
        private readonly string apiUrl;
        private readonly IConfiguration _configuration;
        public PiePaginaDetsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            // Acceder al perfil "ApiBD" y obtener la URL
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
            
           
        }

        public async Task<List<TbConfPiepaginadet>> ListarPiePaginaDets()
        {
            List<TbConfPiepaginadet> piePaginaDets = new List<TbConfPiepaginadet>();

            try
            {
                var url = "/api/piepaginadet";

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
