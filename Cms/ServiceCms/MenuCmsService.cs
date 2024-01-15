using ApiBD.Models;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;
using CentralParkingSystem.DTOs;

namespace Cms.ServiceCms
{
    public class MenuCmsService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("Properties", "launchSettings.json");
        private string apiUrl = "";
        public MenuCmsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            if (File.Exists(launchSettingsPath))
            {
                var launchSettingsJson = File.ReadAllText(launchSettingsPath);
                var launchSettings = JObject.Parse(launchSettingsJson);

                // Acceder al perfil "ApiBD" y obtener la URL
                apiUrl = launchSettings["profiles"]?["Cms"]?["apiUrl"]?.ToString();
            }
        }

        public async Task<List<TbConfTipomenu>> listarTipoMenu()
        {
            List<TbConfTipomenu> tipoMenus = new List<TbConfTipomenu>();

            try
            {
                var url = apiUrl+"/api/menu/tipoMenu";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    tipoMenus = JsonSerializer.Deserialize<List<TbConfTipomenu>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return tipoMenus;
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

            return tipoMenus;
        }

        public async Task<List<TbConfMenu>> listarMenus()
        {
            List<TbConfMenu> menus = new List<TbConfMenu>();

            try
            {
                var url = apiUrl + "/api/menu/menusController";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    menus = JsonSerializer.Deserialize<List<TbConfMenu>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return menus;
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

            return menus;
        }

        public async Task<TbConfMenu> obtenerMenuDetalle(int id)
        {
            var url = $"{apiUrl}/api/menu/{id}"; 

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var menu = await response.Content.ReadFromJsonAsync<TbConfMenu>();
                    return menu;
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

        public async Task<TbConfMenu> crearMenu(TbConfMenu tbConfMenu)
        {
            var url = apiUrl + "/api/menu"; 

            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(tbConfMenu), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var crearMenu = await response.Content.ReadFromJsonAsync<TbConfMenu>();
                    return crearMenu;
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


        public async Task<bool> eliminarMenu(int id)
        {
            var url = $"{apiUrl}/api/menu/{id}"; 

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

        public async Task<TbConfMenu> modificarMenu(int id, TbConfMenu tbConfMenu)
        {
            var url = $"{apiUrl}/api/menu/{id}"; 

            var jsonContent = new StringContent(JsonSerializer.Serialize(tbConfMenu), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                var modificarMenu = await response.Content.ReadFromJsonAsync<TbConfMenu>();
                return modificarMenu;
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

        public async Task<List<TbConfMenu>> ListarSubMenus()
        {
            List<TbConfMenu> subMenus = new List<TbConfMenu>();

            try
            {
                var url = apiUrl + "/api/menu/subMenus";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    subMenus = JsonSerializer.Deserialize<List<TbConfMenu>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return subMenus;
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

            return subMenus;
        }
        public async Task<List<Result>> ListarMenusv2()
        {
            List<Result> menus = new List<Result>();

            try
            {
                var url = apiUrl + "/api/menu";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    menus = JsonSerializer.Deserialize<List<Result>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return menus;
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

            return menus;
        }

    }
}
