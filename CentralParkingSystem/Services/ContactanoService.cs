using ApiBD.Models;

namespace CentralParkingSystem.Services
{
    public class ContactanoService
    {
        private readonly HttpClient _httpClient;

        public ContactanoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<TbFormContactano> crearContactoRegistro(TbFormContactano tbFormContactano)
        {
            var url = "https://localhost:7260/api/contactanos";

            var response = await _httpClient.PostAsJsonAsync(url, tbFormContactano);

            if (response.IsSuccessStatusCode)
            {
                var contacto = await response.Content.ReadFromJsonAsync<TbFormContactano>();
                return contacto;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }
    }
}

