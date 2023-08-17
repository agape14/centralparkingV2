using ApiBD.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CentralParkingSystem.Services
{
    public class SlideService
    {
        private readonly HttpClient _httpClient;

        public SlideService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TbIndSlidecab>> ListarSlide()
        {
            List<TbIndSlidecab> slides = new List<TbIndSlidecab>();

            try
            {
                var url = "http://localhost:82/api/slide";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    slides = JsonSerializer.Deserialize<List<TbIndSlidecab>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return slides;
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

            return slides;
        }


        


    }
}
