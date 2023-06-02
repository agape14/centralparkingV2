using ApiBD.Models;
using System.Net.Http;
using System.Net;

namespace Cms.ServiceCms
{
    public class CaracteristicaCmsService
    {

        private readonly HttpClient _httpClient;

        public CaracteristicaCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TbIndCaracteristica> obtenerCaracteristicaDetalle(uint id)
        {
            var url = $"https://localhost:7260/api/caracteristica/{id}"; 

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var caracteristica = await response.Content.ReadFromJsonAsync<TbIndCaracteristica>();
                return caracteristica;
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


        public async Task<TbIndCaracteristica> crearCaracteristica(TbIndCaracteristica caracteristica)
        {
            var url = "https://localhost:7260/api/caracteristica"; 

            var response = await _httpClient.PostAsJsonAsync(url, caracteristica);

            if (response.IsSuccessStatusCode)
            {
                var createdCaracteristica = await response.Content.ReadFromJsonAsync<TbIndCaracteristica>();
                return createdCaracteristica;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbIndCaracteristica> modificarCaracteristica(uint id, TbIndCaracteristica caracteristica)
        {
            var url = $"https://localhost:7260/api/caracteristica/{id}"; 

            var response = await _httpClient.PutAsJsonAsync(url, caracteristica);

            if (response.IsSuccessStatusCode)
            {
                var updatedCaracteristica = await response.Content.ReadFromJsonAsync<TbIndCaracteristica>();
                return updatedCaracteristica;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarCaracteristica(uint id)
        {
            var url = $"https://localhost:7260/api/caracteristica/{id}"; 

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
