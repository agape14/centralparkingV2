using ApiBD.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class EstacionamientoCmsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public EstacionamientoCmsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<TbEstacionamiento>> listarEstacionamientos(string codUbi)
        {
            List<TbEstacionamiento> estacionamientos = new List<TbEstacionamiento>();

            try
            {
                var url = $"/api/estacionamientos/vertodoxid/{codUbi}";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    estacionamientos = JsonSerializer.Deserialize<List<TbEstacionamiento>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return estacionamientos;
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

            return estacionamientos;
        }

        public async Task<List<TbEstacionamiento>> obtenerTablaEstacionamiento(string codUbi)
        {
            List<TbEstacionamiento> esstac = new List<TbEstacionamiento>();
            var url = $"/api/estacionamientos/tblestacio/{codUbi}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                esstac = JsonSerializer.Deserialize<List<TbEstacionamiento>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return esstac;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("No se encontraron provincias para el departamento especificado.");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbEstacionamiento> verEstacionamientoPorDistrito(int id)
        {
            var url = $"/api/estacionamientos/verestacionamiento/{id}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var estacionamiento = await response.Content.ReadFromJsonAsync<TbEstacionamiento>();
                    return estacionamiento;
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

            //List<TbEstacionamiento> estacionamientos = new List<TbEstacionamiento>();

            //try
            //{
            //    var url = $"/api/estacionamientos/verestacionamiento/{codUbi}/{vestacionam}";

            //    var response = await _httpClient.GetAsync(url);

            //    if (response.IsSuccessStatusCode)
            //    {
            //        var content = await response.Content.ReadAsStringAsync();
            //        estacionamientos = JsonSerializer.Deserialize<List<TbEstacionamiento>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            //        return estacionamientos;
            //    }
            //    else
            //    {
            //        Console.WriteLine("No se ha podido conectar a la API");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error: {ex.Message}");
            //}

            //return estacionamientos;
        }


        public async Task<TbEstacionamiento> modificarEstacionamiento(int id, TbEstacionamiento tbEstacionamiento)
        {
            var url = $"/api/estacionamientos/{id}";

            var jsonContent = new StringContent(JsonSerializer.Serialize(tbEstacionamiento), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var modificarEstacionamiento = await response.Content.ReadFromJsonAsync<TbEstacionamiento>();
                return modificarEstacionamiento;
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new Exception("Solicitud incorrecta. Verifica los datos del TbEstacionamiento.");
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

        public async Task<bool> eliminarEstacionamiento(int id)
        {
            var url = $"/api/estacionamientos/{id}";

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

        public async Task<TbEstacionamiento> crearEstacionamiento(TbEstacionamiento tbEstacionamiento)
        {
            var url = "/api/estacionamientos";

            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(tbEstacionamiento), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var crearEstacionamiento = await response.Content.ReadFromJsonAsync<TbEstacionamiento>();
                    return crearEstacionamiento;
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
    }


}
