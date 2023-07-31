using ApiBD.Models;
using System.Net.Http;

namespace CentralParkingSystem.Services
{
    public class PostulacionService
    {
        private readonly HttpClient _httpClient;

        public PostulacionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<TbFormTbcnosotro> crearPostulacion(TbFormTbcnosotro tbFormTbcnosotro)
        {
            var url = "http://localhost:82/api/postulacion";

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
