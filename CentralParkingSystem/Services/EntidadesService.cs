using ApiBD.Models;
using CentralParkingSystem.DTOs;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;


namespace CentralParkingSystem.Services
{
    public class EntidadesService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public EntidadesService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<Entidades>> ListarEntidades()
        {
            List<Entidades> entidades = new List<Entidades>();

            try
            {
                var url = "/api/entidades";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    entidades = JsonSerializer.Deserialize<List<Entidades>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return entidades;
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

            return entidades;
        }
        public async Task<List<TbConfUbigeo>> obtenerDepartamento()
        {
            List<TbConfUbigeo> distritos = new List<TbConfUbigeo>();
            var url = $"/api/ubigeo/departmentos";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                distritos = JsonSerializer.Deserialize<List<TbConfUbigeo>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return distritos;
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
        public async Task<List<TbConfUbigeo>> obtenerProvinciasPorDepartamento(string departamentoId)
        {
            List<TbConfUbigeo> provincias = new List<TbConfUbigeo>();
            var url = $"/api/ubigeo/provincias/{departamentoId}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                provincias = JsonSerializer.Deserialize<List<TbConfUbigeo>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return provincias;
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

        public async Task<List<TbConfUbigeo>> obtenerDistritosPorProvincia(string provinciaId)
        {
            List<TbConfUbigeo> distritos = new List<TbConfUbigeo>();
            var url = $"/api/ubigeo/distritos/{provinciaId}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                distritos = JsonSerializer.Deserialize<List<TbConfUbigeo>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return distritos;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("No se encontraron distritos para la provincia especificada.");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }
    }
}
