using ApiBD.Models;
using CentralParkingSystem.DTOs;
using Cms.Helpers;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class UbigeoServicioscmsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string apiUrl = "";
        public UbigeoServicioscmsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            apiUrl = _configuration.GetValue<string>("ApiSettings:ApiUrl");
            _httpClient.BaseAddress = new Uri(apiUrl);
        }

        public async Task<List<TbConfUbigeoServicio>> listarDistritosPorServicio()
        {
            List<TbConfUbigeoServicio> permisos = new List<TbConfUbigeoServicio>();

            try
            {
                var url = "/api/ubigeoServicio";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var permisoLista = JsonSerializer.Deserialize<List<TbConfUbigeoServicio>>(content, jsonOptions);
                    return permisoLista;
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

            return permisos;
        }

        public async Task<List<TbConfUbigeoServicio>> listarUbigeoPorServicio(int id)
        {
            List<TbConfUbigeoServicio> listUbigeoServicio = new List<TbConfUbigeoServicio>();

            try
            {
                var url = $"/api/ubigeoServicio/{id}";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var ubigeoServicio = JsonSerializer.Deserialize<List<TbConfUbigeoServicio>>(content, jsonOptions);
                    listUbigeoServicio = ubigeoServicio;
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

            return listUbigeoServicio;
        }

        public async Task<List<TbConfUbigeo>> obtenerDistritos(string cod)
        {
            List<TbConfUbigeo> distritos = new List<TbConfUbigeo>();
            var url = $"/api/ubigeo/distritos/{cod}";

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

        public async Task<TbConfUbigeoServicio> crearUbigeoServicio(TbConfUbigeoServicio tbUbigeoServicio)
        {
            var url = "/api/ubigeoServicio";

            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(tbUbigeoServicio), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var crearUbigeoServicio = await response.Content.ReadFromJsonAsync<TbConfUbigeoServicio>();
                    return crearUbigeoServicio;
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

        public async Task<bool> eliminarUbigeoServicio(int idservicio,string codubi)
        {
            var url = $"/api/ubigeoServicio/{idservicio}/{codubi}";

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

        public async Task<List<TbConfUbigeoServicio>>  getEliminarUbigeoPorServicio(int idservicio, string codubi)
        {
            var url = $"/api/ubigeoServicio/{idservicio}/{codubi}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var distritos = JsonSerializer.Deserialize<List<TbConfUbigeoServicio>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return distritos;
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

    }
}
