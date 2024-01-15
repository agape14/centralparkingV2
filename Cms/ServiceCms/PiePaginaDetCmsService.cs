using ApiBD.Models;
using System.Net;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Cms.ServiceCms
{
    public class PiePaginaDetCmsService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("Properties", "launchSettings.json");
        private string apiUrl = "";
        public PiePaginaDetCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            if (File.Exists(launchSettingsPath))
            {
                var launchSettingsJson = File.ReadAllText(launchSettingsPath);
                var launchSettings = JObject.Parse(launchSettingsJson);

                // Acceder al perfil "ApiBD" y obtener la URL
                apiUrl = launchSettings["profiles"]?["Cms"]?["apiUrl"]?.ToString();
            }
        }

        public async Task<List<TbConfPiepaginadet>> listarPiePaginaDetPorCodigoId(int id)
        {
            List<TbConfPiepaginadet> lista = new List<TbConfPiepaginadet>();

            try
            {
                var url = $"{apiUrl}/api/piepaginadet/piePaginaDetId/{id}";

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

        public async Task<List<TbConfPiepaginadet>> listarPiePaginaDet()
        {
            List<TbConfPiepaginadet> lista = new List<TbConfPiepaginadet>();

            try
            {
                var url = apiUrl+"/api/piepaginadet";

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

        public async Task<TbConfPiepaginadet> obtenerPiePaginaDetDetalle(int id)
        {
            var url = $"{apiUrl}/api/piepaginadet/{id}"; 

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var piePaginaDet = await response.Content.ReadFromJsonAsync<TbConfPiepaginadet>();
                    return piePaginaDet;
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new Exception("El botón no fue encontrado.");
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
                Console.WriteLine($"Error al obtener el botón: {ex.Message}");
                throw;
            }
        }

        public async Task<TbConfPiepaginadet> crearPiePaginaDet(TbConfPiepaginadet piePaginaDet)
        {
            var url = apiUrl + "/api/piepaginadet"; 

            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(piePaginaDet), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var crearPiePaginaDet = await response.Content.ReadFromJsonAsync<TbConfPiepaginadet>();
                    return crearPiePaginaDet;
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
                Console.WriteLine($"Error al crear el botón: {ex.Message}");
                throw;
            }
        }


        public async Task<bool> eliminarPiePaginaDet(int id)
        {
            var url = $"{apiUrl}/api/piepaginadet/{id}"; 

            var response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("El botón no fue encontrado.");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbConfPiepaginadet> modificarPiePaginaDet(int id, TbConfPiepaginadet boton)
        {
            var url = $"{apiUrl}/api/piepaginadet/{id}"; 

            var jsonContent = new StringContent(JsonSerializer.Serialize(boton), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var updatedPiePaginaDet = await response.Content.ReadFromJsonAsync<TbConfPiepaginadet>();
                return updatedPiePaginaDet;
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new Exception("Solicitud incorrecta. Verifica los datos del botón.");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("El botón no fue encontrado.");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }
    }
}
