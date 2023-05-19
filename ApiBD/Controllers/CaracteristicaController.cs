using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/caracteristica")]
    public class CaracteristicaController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public CaracteristicaController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbIndCaracteristica>>> Get()
        {
            var caracteristicas = await _dbContext.TbIndCaracteristicas.ToListAsync();
            return caracteristicas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbIndCaracteristica>> GetById(int id)
        {
            var caracteristica = await _dbContext.TbIndCaracteristicas.FindAsync(id);
            if (caracteristica == null)
            {
                return NotFound();
            }
            return caracteristica;
        }

        [HttpPost]
        public async Task<ActionResult<TbIndCaracteristica>> Create(TbIndCaracteristica caracteristica)
        {
            _dbContext.TbIndCaracteristicas.Add(caracteristica);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = caracteristica.Id }, caracteristica);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbIndCaracteristica caracteristica)
        {
            if (id != caracteristica.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(caracteristica).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaracteristicaExists(id))
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
            var caracteristica = await _dbContext.TbIndCaracteristicas.FindAsync(id);
            if (caracteristica == null)
            {
                return NotFound();
            }
            _dbContext.TbIndCaracteristicas.Remove(caracteristica);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool CaracteristicaExists(int id)
        {
            return _dbContext.TbIndCaracteristicas.Any(e => e.Id == id);
        }
    }
}
