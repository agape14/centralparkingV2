using ApiBD.Models;
using System.Net;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class ModaleCabeceraService
    {
        private readonly HttpClient _httpClient;

        public ModaleCabeceraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<TbConfPiepaginadet>> listarEntrada()
        {
            List<TbConfPiepaginadet> lista = new List<TbConfPiepaginadet>();

            try
            {
                var url = "http://localhost:82/api/modalcabecera/entrada";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    lista = JsonSerializer.Deserialize<List<TbConfPiepaginadet>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return lista;
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

            return lista;
        }

        public async Task<List<TbConfModalcab>> listarModalCabecera()
        {
            List<TbConfModalcab> lista = new List<TbConfModalcab>();

            try
            {
                var url = "http://localhost:82/api/modalcabecera";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    lista = JsonSerializer.Deserialize<List<TbConfModalcab>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return lista;
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

            return lista;
        }

        public async Task<TbConfModalcab> obtenerModalCabeceraDetalle(int id)
        {
            var url = $"http://localhost:82/api/modalcabecera/{id}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var modal = await response.Content.ReadFromJsonAsync<TbConfModalcab>();
                return modal;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("La característica no fue encontrada.");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbConfModalcab> obtenerModalCabeceraDetalleFijo(int id)
        {
            var url = $"http://localhost:82/api/modalcabecera/obtenerCabeceraFija/{id}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var modal = await response.Content.ReadFromJsonAsync<TbConfModalcab>();
                return modal;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("La característica no fue encontrada.");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbConfModalcab> crearModalCabRegistro(TbConfModalcab tbConfModalcab)
        {
            var url = "http://localhost:82/api/modalcabecera";

            var response = await _httpClient.PostAsJsonAsync(url, tbConfModalcab);

            if (response.IsSuccessStatusCode)
            {
                var modal = await response.Content.ReadFromJsonAsync<TbConfModalcab>();
                return modal;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbConfModalcab> modificarModalCab(int id, TbConfModalcab tbConfModalcab)
        {
            var url = $"http://localhost:82/api/modalcabecera/{id}";

            var response = await _httpClient.PutAsJsonAsync(url, tbConfModalcab);

            if (response.IsSuccessStatusCode)
            {
                var modal = await response.Content.ReadFromJsonAsync<TbConfModalcab>();
                return modal;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarModalCab(int id)
        {
            var url = $"http://localhost:82/api/modalcabecera/{id}";

            var response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }
    }
}
