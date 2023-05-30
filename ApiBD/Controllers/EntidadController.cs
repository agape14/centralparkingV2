using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/entidades")]
    public class EntidadController : ControllerBase
    {
        private readonly CentralParkingContext _dbContext;

        public EntidadController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/entidades
        [HttpGet]
        public async Task<ActionResult<List<TbConfEntidad>>> Get()
        {
            var listEntidad = from datos in _dbContext.TbConfEntidads
                              select datos;

            var entidades = await listEntidad.ToListAsync();

            return Ok(entidades);
        }

       



        // GET: api/entidades/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfEntidad>> GetById(int id)
        {
            var entidad = await _dbContext.TbConfEntidads.FindAsync(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        // POST: api/entidades
        [HttpPost]
        public async Task<ActionResult<TbConfEntidad>> Create(TbConfEntidad entidad)
        {
            _dbContext.TbConfEntidads.Add(entidad);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entidad.Id }, entidad);
        }

        // PUT: api/entidades/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbConfEntidad entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(entidad).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntidadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(entidad);
        }

        // DELETE: api/entidades/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _dbContext.TbConfEntidads.FindAsync(id);
            if (entidad == null)
            {
                return NotFound();
            }
            _dbContext.TbConfEntidads.Remove(entidad);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool EntidadExists(int id)
        {
            return _dbContext.TbConfEntidads.Any(e => e.Id == id);
        }
    }
}
