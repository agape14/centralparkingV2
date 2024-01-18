﻿using CentralParkingSystem.DTOs;
using Newtonsoft.Json.Linq;
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
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public PiePaginaCabsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<PiePaginaCabs>> ListarPiePaginasCabs()
        {
            List<PiePaginaCabs> piePaginaCabs = new List<PiePaginaCabs>();

            try
            {
                var url = "/api/piepagina";

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
