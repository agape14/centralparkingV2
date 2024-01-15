using ApiBD.Models;
using CentralParkingSystem.DTOs;
using Newtonsoft.Json.Linq;
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
        private readonly IConfiguration _configuration;
        private string launchSettingsPath = Path.Combine("Properties", "launchSettings.json");
        private string apiUrl = "";
        public PiePaginaDetsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            //if (File.Exists(launchSettingsPath))
            //{
            //    var launchSettingsJson = File.ReadAllText(launchSettingsPath);
            //    var launchSettings = JObject.Parse(launchSettingsJson);

            //    // Acceder al perfil "ApiBD" y obtener la URL
            //    apiUrl = launchSettings["profiles"]?["CentralParkingSystem"]?["apiUrl"]?.ToString();
            //}
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
        }


        public async Task<List<TbConfPiepaginadet>> ListarPiePaginaDets()
        {

            List<TbConfPiepaginadet> piePaginaDets = new List<TbConfPiepaginadet>();

            try
            {
                var url = apiUrl+"/api/piepaginadet";

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
