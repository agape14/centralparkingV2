﻿using ApiBD.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class ConfBotonesCmsService
    {
        private readonly HttpClient _httpClient;
        public ConfBotonesCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TbConfBotone>> listarBotones()
        {
            List<TbConfBotone> botones = new List<TbConfBotone>();

            try
            {
                var url = "https://localhost:7260/api/botones";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    botones = JsonSerializer.Deserialize<List<TbConfBotone>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return botones;
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

            return botones;
        }

        public async Task<TbConfBotone> obtenerBotonDetalle(int id)
        {
            var url = $"https://localhost:7260/api/botones/{id}"; // Reemplaza con la URL correcta de tu API

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var boton = await response.Content.ReadFromJsonAsync<TbConfBotone>();
                    return boton;
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

        public async Task<TbConfBotone> crearBoton(TbConfBotone boton)
        {
            var url = "https://localhost:7260/api/botones"; // Reemplaza con la URL correcta de tu API

            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(boton), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var createdBoton = await response.Content.ReadFromJsonAsync<TbConfBotone>();
                    return createdBoton;
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


        public async Task<bool> eliminarBoton(int id)
        {
            var url = $"https://localhost:7260/api/botones/{id}"; // Reemplaza con la URL correcta de tu API

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

        public async Task<TbConfBotone> modificarBoton(int id, TbConfBotone boton)
        {
            var url = $"https://localhost:7260/api/botones/{id}"; // Reemplaza con la URL correcta de tu API

            var jsonContent = new StringContent(JsonSerializer.Serialize(boton), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var updatedBoton = await response.Content.ReadFromJsonAsync<TbConfBotone>();
                return updatedBoton;
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