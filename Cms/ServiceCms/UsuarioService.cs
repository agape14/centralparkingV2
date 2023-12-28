using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Cms.Service
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;
        private string launchSettingsPath = Path.Combine("..", "ApiBD", "Properties", "launchSettings.json");
        private string apiUrl = "";
        public UsuarioService(HttpClient httpClient)
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

        public async Task<TbConfUser> validacionUsuario(TbConfUser user)
        {
            TbConfUser usuario = null;

            try
            {
                var url = apiUrl + "/api/usuario/validacionUser";

            

                var json = JsonSerializer.Serialize(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    usuario = JsonSerializer.Deserialize<TbConfUser>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    throw new Exception("Error al conectar con la API");
                }
            }
            catch (Exception ex)
            {
                return usuario;
            }

            return usuario;
        }



       


    }
}
