using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var permisos = await _dbContext.TbConfPermisos.ToListAsync();
            return permisos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfPermiso>> GetById(int id)
        {
            var permiso = await _dbContext.TbConfPermisos.FindAsync(id);
            if (permiso == null)
            {
                return NotFound();
            }
            return permiso;
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
            return NoContent();
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
