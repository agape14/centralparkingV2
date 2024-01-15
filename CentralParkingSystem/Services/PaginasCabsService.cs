﻿using ApiBD.Models;
using CentralParkingSystem.DTOs;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class PaginasCabsService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("Properties", "launchSettings.json");
        private string apiUrl = "";
        public PaginasCabsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            if (File.Exists(launchSettingsPath))
            {
                var launchSettingsJson = File.ReadAllText(launchSettingsPath);
                var launchSettings = JObject.Parse(launchSettingsJson);

                // Acceder al perfil "ApiBD" y obtener la URL
                apiUrl = launchSettings["profiles"]?["CentralParkingSystem"]?["apiUrl"]?.ToString();
            }
        }

        public async Task<TbConfPaginascab> paginasCabsPorDefault()
        {
            TbConfPaginascab paginasCabs = new TbConfPaginascab();

            try
            {
                var url = apiUrl+"/api/paginas/nosotros";

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
