using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/serviciosdet")]
    public class IServiciosdetController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public IServiciosdetController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbIndServiciodet>>> Get()
        {
            var serviciodets = await _dbContext.TbIndServiciodets.ToListAsync();
            return serviciodets;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbIndServiciodet>> GetById(int id)
        {
            var serviciodet = await _dbContext.TbIndServiciodets.FindAsync(id);
            if (serviciodet == null)
            {
                return NotFound();
            }
            return serviciodet;
        }

        [HttpPost]
        public async Task<ActionResult<TbIndServiciodet>> Create(TbIndServiciodet serviciodet)
        {
            _dbContext.TbIndServiciodets.Add(serviciodet);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = serviciodet.Id }, serviciodet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbIndServiciodet serviciodet)
        {
            if (id != serviciodet.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(serviciodet).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciodetExists(id))
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
            var serviciodet = await _dbContext.TbIndServiciodets.FindAsync(id);
            if (serviciodet == null)
            {
                return NotFound();
            }
            _dbContext.TbIndServiciodets.Remove(serviciodet);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool ServiciodetExists(int id)
        {
            return _dbContext.TbIndServiciodets.Any(e => e.Id == id);
        }
    }
}
