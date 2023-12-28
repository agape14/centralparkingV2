﻿using ApiBD.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class PiePaginaCmsService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("..", "ApiBD", "Properties", "launchSettings.json");
        private string apiUrl = "";
        public PiePaginaCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            if (File.Exists(launchSettingsPath))
            {
                var launchSettingsJson = File.ReadAllText(launchSettingsPath);
                var launchSettings = JObject.Parse(launchSettingsJson);

                // Acceder al perfil "ApiBD" y obtener la URL
                apiUrl = launchSettings["profiles"]?["ApiBD"]?["applicationUrl"]?.ToString();
            }
        }

        public async Task<List<TbConfPiepaginacab>> listarPiePaginasCab()
        {
            List<TbConfPiepaginacab> piePaginasCabs = new List<TbConfPiepaginacab>();

            try
            {
                var url = apiUrl+"/api/piepagina/listaPiePaginas";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    piePaginasCabs = JsonSerializer.Deserialize<List<TbConfPiepaginacab>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return piePaginasCabs;
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

            return piePaginasCabs;
        }

        public async Task<TbConfPiepaginacab> obtenerPiePaginaCabsDetalle(int id)
        {
            var url = $"{apiUrl}/api/piepagina/{id}"; 

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var piePaginaCab = await response.Content.ReadFromJsonAsync<TbConfPiepaginacab>();
                return piePaginaCab;
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

        public async Task<TbConfPiepaginacab> crearPiePaginaCab(TbConfPiepaginacab tbConfPiepaginacab)
        {
            var url = apiUrl + "/api/piepagina"; 

            var response = await _httpClient.PostAsJsonAsync(url, tbConfPiepaginacab);

            if (response.IsSuccessStatusCode)
            {
                var crearPiePaginaCab= await response.Content.ReadFromJsonAsync<TbConfPiepaginacab>();
                return crearPiePaginaCab;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbConfPiepaginacab> modificarPiePaginaCab(int id, TbConfPiepaginacab tbConfPiepaginacab)
        {
            var url = $"{apiUrl}/api/piepagina/{id}"; 

            var response = await _httpClient.PutAsJsonAsync(url, tbConfPiepaginacab);

            if (response.IsSuccessStatusCode)
            {
                var modificarPiePaginaCab = await response.Content.ReadFromJsonAsync<TbConfPiepaginacab>();
                return modificarPiePaginaCab;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarPiePaginaCab(int id)
        {
            var url = $"{apiUrl}/api/piepagina/{id}"; 

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
