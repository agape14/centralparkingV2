using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace CentralParkingSystem.Services
{
    public class PostulacionService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public PostulacionService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }


        public async Task<TbFormTbcnosotro> crearPostulacion(TbFormTbcnosotro tbFormTbcnosotro)
        {
            var url = "/api/postulacion";

            var response = await _httpClient.PostAsJsonAsync(url, tbFormTbcnosotro);

            if (response.IsSuccessStatusCode)
            {
                var postulacion = await response.Content.ReadFromJsonAsync<TbFormTbcnosotro>();
                return postulacion;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }
    }
}
