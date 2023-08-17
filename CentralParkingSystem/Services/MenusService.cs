using CentralParkingSystem.DTOs;
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

        public MenusService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Result>> ListarMenus()
        {
            List<Result> menus = new List<Result>();

            try
            {
                var url = "http://localhost:82/api/menu";

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
                var url = "http://localhost:82/api/menu/subMenus";

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
