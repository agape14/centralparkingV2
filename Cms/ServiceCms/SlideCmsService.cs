using ApiBD.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class SlideCmsService
    {

        private readonly HttpClient _httpClient;

        public SlideCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TbIndSlidecab> GetDetails(uint id)
        {
            TbIndSlidecab tbIndSlidecab = null;

            try
            {
                var url = $"https://localhost:7260/api/slide/{id}";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    tbIndSlidecab = JsonSerializer.Deserialize<TbIndSlidecab>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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

            return tbIndSlidecab;
        }



        public async Task<TbIndSlidecab> CreateSlide(TbIndSlidecab tbIndSlidecab)
        {
            var url = "https://localhost:7260/api/slide"; 

            try
            {
                var jsonContent = JsonSerializer.Serialize(tbIndSlidecab);
                var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, httpContent);
                response.EnsureSuccessStatusCode();

                var createdSlide = await response.Content.ReadFromJsonAsync<TbIndSlidecab>();
                return createdSlide;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                throw new Exception("Error en la solicitud HTTP", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el slide: {ex.Message}");
                throw;
            }
        }


        public async Task<bool> DeleteSlide(uint id)
        {
            var url = $"https://localhost:7260/api/slide/{id}"; 

            try
            {
                var response = await _httpClient.DeleteAsync(url);
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                throw new Exception("Error en la solicitud HTTP", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el slide: {ex.Message}");
                throw;
            }
        }


        public async Task<TbIndSlidecab> UpdateSlide(uint id, TbIndSlidecab slide)
        {
            var url = $"https://localhost:7260/api/slide/{id}"; 

            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(slide), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var updatedSlide = await response.Content.ReadFromJsonAsync<TbIndSlidecab>();
                    return updatedSlide;
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new Exception("La solicitud es inválida. Verifica los datos enviados.");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("La diapositiva no fue encontrada.");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
                    throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                throw new Exception("Error en la solicitud HTTP", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la diapositiva: {ex.Message}");
                throw;
            }
        }


    }
}
