using ApiBD.Models;
using System.Net;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class PostulacionCmsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public PostulacionCmsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<TbFormTbcnosotro>> listarPostulaciones()
        {
            List<TbFormTbcnosotro> Postulaciones = new List<TbFormTbcnosotro>();

            try
            {
                var url = "/api/postulacion/vertodos";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Postulaciones = JsonSerializer.Deserialize<List<TbFormTbcnosotro>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return Postulaciones;
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

            return Postulaciones;
        }

        public async Task<TbFormTbcnosotro> obtenerPostulacionByid(int id)
        {
            var url = $"/api/postulacion/getbyid/{id}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var rol = await response.Content.ReadFromJsonAsync<TbFormTbcnosotro>();
                return rol;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("La TbFormTbcnosotro no fue encontrada.");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }
    }
}
