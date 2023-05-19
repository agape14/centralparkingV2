using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbConfUser>>> Get()
        {
            var usuarios = await _dbContext.TbConfUsers.ToListAsync();
            return usuarios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfUser>> GetById(int id)
        {
            var usuario = await _dbContext.TbConfUsers.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
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
