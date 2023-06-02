using ApiBD.Models;
using System.Net;
using System.Text.Json;

namespace Cms.ServiceCms
{
    public class UsuarioCmsService
    {
        private readonly HttpClient _httpClient;

        public UsuarioCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TbConfUser>> listarUsuarios()
        {
            List<TbConfUser> usuarios = new List<TbConfUser>();

            try
            {
                var url = "https://localhost:7260/api/usuario";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    usuarios = JsonSerializer.Deserialize<List<TbConfUser>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return usuarios;
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

            return usuarios;
        }

        public async Task<TbConfUser> obtenerUsuarioDetalle(ulong id)
        {
            var url = $"https://localhost:7260/api/usuario/{id}"; 

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var usuario = await response.Content.ReadFromJsonAsync<TbConfUser>();
                return usuario;
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

        public async Task<TbConfUser> crearUsuario(TbConfUser tbConfUser)
        {
            var url = "https://localhost:7260/api/usuario"; 

            var response = await _httpClient.PostAsJsonAsync(url, tbConfUser);

            if (response.IsSuccessStatusCode)
            {
                var crearUsuario = await response.Content.ReadFromJsonAsync<TbConfUser>();
                return crearUsuario;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<TbConfUser> modificarUsuario(ulong id, TbConfUser tbConfUser)
        {
            var url = $"https://localhost:7260/api/usuario/{id}"; 

            var response = await _httpClient.PutAsJsonAsync(url, tbConfUser);

            if (response.IsSuccessStatusCode)
            {
                var modificarUsuario = await response.Content.ReadFromJsonAsync<TbConfUser>();
                return modificarUsuario;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error en la solicitud HTTP: {response.StatusCode}, {errorContent}");
            }
        }

        public async Task<bool> eliminarUsuario(ulong id)
        {
            var url = $"https://localhost:7260/api/usuario/{id}"; 

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
