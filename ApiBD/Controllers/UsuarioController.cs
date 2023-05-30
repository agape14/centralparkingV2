using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public UsuarioController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        [Route("validacionUser")]
        public async Task<IActionResult> ValidateUser([FromBody] TbConfUser user)
        {
            string newpass = GetSHA256("$C3P4Sy" + user.Password);
            var usuario = await _dbContext.TbConfUsers
                .FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == newpass);

            if (usuario != null)
            {
                // Usuario válido
                return Ok(usuario);
            }

            // Usuario no válido
            return BadRequest("Usuario no válido");
        }

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        [HttpGet]
        public async Task<List<TbConfUser>> Get()
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            var usuarios = await _dbContext.TbConfUsers.Include(t => t.Rol).ToListAsync();
            var usuariosJson = JsonSerializer.Serialize(usuarios, options);
            var usuariosDeserializados = JsonSerializer.Deserialize<List<TbConfUser>>(usuariosJson, options);

            return usuariosDeserializados;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfUser>> GetById(ulong id)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            var usuario = await _dbContext.TbConfUsers
                                        .Include(t => t.Rol)
                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioJson = JsonSerializer.Serialize(usuario, options);
            var usuarioDeserializado = JsonSerializer.Deserialize<TbConfUser>(usuarioJson, options);

            return usuarioDeserializado;
        }

        [HttpPost]
        public async Task<ActionResult<TbConfUser>> Create(TbConfUser usuario)
        {
            _dbContext.TbConfUsers.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(ulong id, TbConfUser usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(usuario).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _dbContext.TbConfUsers.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _dbContext.TbConfUsers.Remove(usuario);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool UsuarioExists(ulong id)
        {
            return _dbContext.TbConfUsers.Any(e => e.Id == id);
        }

    }
}
