﻿using CentralParkingSystem.DTOs;
using Newtonsoft.Json.Linq;
using System.Text.Json;


namespace CentralParkingSystem.Services
{
    public class EntidadesService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public EntidadesService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<Entidades>> ListarEntidades()
        {
            List<Entidades> entidades = new List<Entidades>();

            try
            {
                var url = "/api/entidades";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    entidades = JsonSerializer.Deserialize<List<Entidades>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return entidades;
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

            return entidades;
        }
    }
}
