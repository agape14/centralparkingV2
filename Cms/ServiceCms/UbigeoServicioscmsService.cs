using ApiBD.Models;
using Cms.Helpers;
using System.Net;
using System.Net.Http;
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

        public async Task<TbConfUbigeoServicio> listarUbigeoPorServicio(int id)
        {
            TbConfUbigeoServicio listUbigeoServicio = new TbConfUbigeoServicio();

            try
            {
                var url = $"/api/ubigeoServicio/{id}";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<ApiResponse<TbConfUbigeoServicio>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (result != null && result.Result != null)
                    {
                        listUbigeoServicio = result.Result;
                        // Aquí puedes usar el objeto ubigeoServicio como desees
                        //return ubigeoServicio;
                    }
                    else
                    {
                        throw new Exception("No se pudo deserializar correctamente el objeto TbConfUbigeoServicio.");
                    }
                    //var ubigeoServicio = JsonSerializer.Deserialize<TbConfUbigeoServicio>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    //return ubigeoServicio;
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


        //public async Task<TbConfUbigeoServicio> listarUbigeoPorServicio(int id)
        //{
        //    var url = $"/api/ubigeoServicio/{id}";

        //    var response = await _httpClient.GetAsync(url);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var servicio = await response.Content.ReadFromJsonAsync<TbConfUbigeoServicio>();
        //        return servicio;
        //    }
        //    else if (response.StatusCode == HttpStatusCode.NotFound)
        //    {
        //        throw new Exception("El servicio no fue encontrado.");
        //    }
        //    else
        //    {
        //        var errorContent = await response.Content.ReadAsStringAsync();
        //        throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
        //    }
        //}

    }
}
