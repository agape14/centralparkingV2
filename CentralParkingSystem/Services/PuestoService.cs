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
    public class PuestoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public PuestoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }


        public async Task<List<TbTraPuesto>> ListarPuestos()
        {

            List<TbTraPuesto> puestos = new List<TbTraPuesto>();

            try
            {
                var url = "/api/puesto";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    puestos = JsonSerializer.Deserialize<List<TbTraPuesto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return puestos;
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

            return puestos;

        }
    }
}
