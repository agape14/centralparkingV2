using CentralParkingSystem.DTOs;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CentralParkingSystem.Services
{
    public class MenusService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public MenusService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<Result>> ListarMenus()
        {
            List<Result> menus = new List<Result>();

            try
            {
                var url = "/api/menu";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    menus = JsonSerializer.Deserialize<List<Result>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return menus;
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

            return menus;
        }

        public async Task<List<SubMenus>> ListarSubMenus()
        {
            List<SubMenus> subMenus = new List<SubMenus>();

            try
            {
                var url = "/api/menu/subMenus";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    subMenus = JsonSerializer.Deserialize<List<SubMenus>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return subMenus;
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

            return subMenus;
        }
    }
}
