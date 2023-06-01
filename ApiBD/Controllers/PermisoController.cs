using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/permiso")]
    public class PermisoController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public PermisoController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbConfPermiso>>> Get()
        {
            var permiso = _dbContext.TbConfPermisos
                .Include(t => t.Menu)
                .Include(t => t.Rol)
                .AsNoTracking(); // Evita el seguimiento de entidades para mejorar el rendimiento

            var permisoLista = await permiso.ToListAsync();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                MaxDepth = 64
            };

            var permisoJson = JsonSerializer.Serialize(permisoLista, options);

            // Retorna la respuesta JSON
            return Ok(permisoJson);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfPermiso>> GetById(int id)
        {
            var permiso = await _dbContext.TbConfPermisos
                                .Include(t => t.Menu)
                                .Include(t => t.Rol)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(m => m.Id == id);
            if (permiso == null)
            {
                return NotFound();
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                MaxDepth = 64
            };

            var permisoJson = JsonSerializer.Serialize(permiso, options);

            // Retorna la respuesta JSON
            return Content(permisoJson, "application/json");
        }


        [HttpPost]
        public async Task<ActionResult<TbConfPermiso>> Create(TbConfPermiso permiso)
        {
            _dbContext.TbConfPermisos.Add(permiso);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = permiso.Id }, permiso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbConfPermiso permiso)
        {
            if (id != permiso.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(permiso).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(permiso);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var permiso = await _dbContext.TbConfPermisos.FindAsync(id);
            if (permiso == null)
            {
                return NotFound();
            }
            _dbContext.TbConfPermisos.Remove(permiso);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool PermisoExists(int id)
        {
            return _dbContext.TbConfPermisos.Any(e => e.Id == id);
        }
    }
}
