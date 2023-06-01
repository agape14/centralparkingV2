using ApiBD.Models;
using System.Net;
using System.Text.Json;
using System.Text;

namespace Cms.ServiceCms
{
    public class PermisoCmsService
    {
        private readonly HttpClient _httpClient;
        public PermisoCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TbConfPermiso>> listarPermisos()
        {
            List<TbConfPermiso> permisos = new List<TbConfPermiso>();

            try
            {
                var url = "https://localhost:7260/api/permiso";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var permisoLista = JsonSerializer.Deserialize<List<TbConfPermiso>>(content, jsonOptions);

                    foreach (var permiso in permisoLista)
                    {
                        Console.WriteLine($"Id: {permiso.Id}, Permiso: {permiso.Permiso}");

                        // Acceder a la propiedad Menu
                        Console.WriteLine($"Menu Id: {permiso.Menu.Id}, Nombre: {permiso.Menu.Nombre}");

                        // Acceder a la propiedad Rol
                        Console.WriteLine($"Rol Id: {permiso.Rol.Id}, Rol: {permiso.Rol.Rol}");

                        Console.WriteLine("---");
                    }

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


        public async Task<TbConfPermiso> obtenerPermisoDetalle(int id)
        {
            var url = $"https://localhost:7260/api/permiso/{id}"; // Reemplaza con la URL correcta de tu API

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var permiso = await response.Content.ReadFromJsonAsync<TbConfPermiso>();
                    return permiso;
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

        public async Task<TbConfPermiso> crearPermiso(TbConfPermiso tbConfPermiso)
        {
            var url = "https://localhost:7260/api/permiso"; // Reemplaza con la URL correcta de tu API

            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(tbConfPermiso), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var crearPermiso = await response.Content.ReadFromJsonAsync<TbConfPermiso>();
                    return crearPermiso;
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


        public async Task<bool> eliminarPermiso(int id)
        {
            var url = $"https://localhost:7260/api/permiso/{id}"; // Reemplaza con la URL correcta de tu API

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

        public async Task<TbConfPermiso> modificarPermiso(int id, TbConfPermiso tbConfPermiso)
        {
            var url = $"https://localhost:7260/api/permiso/{id}"; // Reemplaza con la URL correcta de tu API

            var jsonContent = new StringContent(JsonSerializer.Serialize(tbConfPermiso), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var modificarPermiso = await response.Content.ReadFromJsonAsync<TbConfPermiso>();
                return modificarPermiso;
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
