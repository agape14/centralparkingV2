﻿using ApiBD.Models;
using System.Net;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class RolCmsService
    {
        private readonly HttpClient _httpClient;

        public RolCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TbConfRole>> listarRoles()
        {
            List<TbConfRole> roles = new List<TbConfRole>();

            try
            {
                var url = "https://localhost:7260/api/rol";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    roles = JsonSerializer.Deserialize<List<TbConfRole>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return roles;
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

            return roles;
        }

        public async Task<TbConfRole> obtenerRolDetalle(int id)
        {
            var url = $"https://localhost:7260/api/rol/{id}"; // Reemplaza con la URL correcta de tu API

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var rol = await response.Content.ReadFromJsonAsync<TbConfRole>();
                return rol;
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

        public async Task<TbConfRole> crearRol(TbConfRole tbConfRole)
        {
            var url = "https://localhost:7260/api/rol"; // Reemplaza con la URL correcta de tu API

            var response = await _httpClient.PostAsJsonAsync(url, tbConfRole);

            if (response.IsSuccessStatusCode)
            {
                var crearRol = await response.Content.ReadFromJsonAsync<TbConfRole>();
                return crearRol;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }


        public async Task<TbConfRole> modificarRol(int id, TbConfRole tbConfRole)
        {
            var url = $"https://localhost:7260/api/rol/{id}"; // Reemplaza con la URL correcta de tu API

            var response = await _httpClient.PutAsJsonAsync(url, tbConfRole);

            if (response.IsSuccessStatusCode)
            {
                var modificarRol = await response.Content.ReadFromJsonAsync<TbConfRole>();
                return modificarRol;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarRol(int id)
        {
            var url = $"https://localhost:7260/api/rol/{id}"; // Reemplaza con la URL correcta de tu API

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