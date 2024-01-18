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
    public class ServiciosCabsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public ServiciosCabsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<TbIndServiciocab>> ListarServiciosCabs()
        {
            List<TbIndServiciocab> serviciosCabs = new List<TbIndServiciocab>();

            try
            {
                var url = "/api/servicios";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    serviciosCabs = JsonSerializer.Deserialize<List<TbIndServiciocab>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return serviciosCabs;
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

            return serviciosCabs;
        }
    }
}
