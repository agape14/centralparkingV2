using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/servicios")]
    public class IServiciosController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public IServiciosController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbIndServiciocab>>> Get()
        {
            var servicios = await _dbContext.TbIndServiciocabs.ToListAsync();
            return servicios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbIndServiciocab>> GetById(int id)
        {
            var servicio = await _dbContext.TbIndServiciocabs.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }
            return servicio;
        }

        [HttpPost]
        public async Task<ActionResult<TbIndServiciocab>> Create(TbIndServiciocab servicio)
        {
            _dbContext.TbIndServiciocabs.Add(servicio);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = servicio.Id }, servicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbIndServiciocab servicio)
        {
            if (id != servicio.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(servicio).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioExists(id))
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
            var servicio = await _dbContext.TbIndServiciocabs.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }
            _dbContext.TbIndServiciocabs.Remove(servicio);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool ServicioExists(int id)
        {
            return _dbContext.TbIndServiciocabs.Any(e => e.Id == id);
        }
    }
}
