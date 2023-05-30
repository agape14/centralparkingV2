using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/puesto")]
    public class PuestoController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public PuestoController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<TbTraPuesto>>> Get()
        {
            var puestos = await _dbContext.TbTraPuestos.ToListAsync();
            return puestos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbTraPuesto>> GetById(int id)
        {
            var puesto = await _dbContext.TbTraPuestos.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }
            return puesto;
        }

        [HttpPost]
        public async Task<ActionResult<TbTraPuesto>> Create(TbTraPuesto puesto)
        {
            _dbContext.TbTraPuestos.Add(puesto);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = puesto.Id }, puesto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbTraPuesto puesto)
        {
            if (id != puesto.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(puesto).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(puesto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var puesto = await _dbContext.TbTraPuestos.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }
            _dbContext.TbTraPuestos.Remove(puesto);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool PuestoExists(int id)
        {
            return _dbContext.TbTraPuestos.Any(e => e.Id == id);
        }
    }
}
