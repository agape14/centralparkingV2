using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;

namespace CentralParkingSystem.Services
{
    public class ServicioDetalleService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("CentralParkingSystem", "Properties", "launchSettings.json");
        private string apiUrl = "";
        public ServicioDetalleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            if (File.Exists(launchSettingsPath))
            {
                var launchSettingsJson = File.ReadAllText(launchSettingsPath);
                var launchSettings = JObject.Parse(launchSettingsJson);

                // Acceder al perfil "ApiBD" y obtener la URL
                apiUrl = launchSettings["profiles"]?["CentralParkingSystem"]?["apiUrl"]?.ToString();
            }
        }

        public async Task<List<TbServDetalle>> listar()
        {
            List<TbServDetalle> servicios = new List<TbServDetalle>();

            try
            {
                var url = apiUrl+"/api/servicioDetalle";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    servicios = JsonSerializer.Deserialize<List<TbServDetalle>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return servicios;
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

            return servicios;
        }

        public async Task<List<TbServDetalle>> obtenerServicioDetalle(int id)
        {
            var url = $"{apiUrl}/api/servicioDetalle/{id}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var servicio = await response.Content.ReadFromJsonAsync<List<TbServDetalle>>();
                    return servicio;
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


            public async Task<TbServDetalle> obtenerServicioEspecifico(int id)
            {
                var url = $"{apiUrl}/api/servicioDetalle/serviciodetalle/{id}";

                try
                {
                    var response = await _httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var servicio = await response.Content.ReadFromJsonAsync<TbServDetalle>();
                        return servicio;
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

        public async Task<TbServDetalle> crearServicioDetalle(TbServDetalle tbServDetalle)
        {
            var url = apiUrl+"/api/servicioDetalle";

            var response = await _httpClient.PostAsJsonAsync(url, tbServDetalle);

            if (response.IsSuccessStatusCode)
            {
                var createdServicio = await response.Content.ReadFromJsonAsync<TbServDetalle>();
                return createdServicio;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbServDetalle> modificarServicioDetalle(int id, TbServDetalle tbServDetalle)
        {
            var url = $"{apiUrl}/api/servicioDetalle/{id}";

            var response = await _httpClient.PutAsJsonAsync(url, tbServDetalle);

            if (response.IsSuccessStatusCode)
            {
                var modificarServicioDetalle = await response.Content.ReadFromJsonAsync<TbServDetalle>();
                return modificarServicioDetalle;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarServicioDetalle(int id)
        {
            var url = $"{apiUrl}/api/servicioDetalle/{id}";

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
