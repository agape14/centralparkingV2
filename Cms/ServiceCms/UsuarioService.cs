using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Cms.Service
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TbConfUser> validacionUsuario(TbConfUser user)
        {
            TbConfUser usuario = null;

            try
            {
                var url = "https://localhost:7260/api/usuario/validacionUser";

            

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
