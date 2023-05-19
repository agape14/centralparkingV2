using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/piepaginadet")]
    public class PiePaginaDetController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public PiePaginaDetController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbConfPiepaginadet>>> Get()
        {
            var piepaginadets = await _dbContext.TbConfPiepaginadets.ToListAsync();
            return piepaginadets;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfPiepaginadet>> GetById(int id)
        {
            var piepaginadet = await _dbContext.TbConfPiepaginadets.FindAsync(id);
            if (piepaginadet == null)
            {
                return NotFound();
            }
            return piepaginadet;
        }

        [HttpPost]
        public async Task<ActionResult<TbConfPiepaginadet>> Create(TbConfPiepaginadet piepaginadet)
        {
            _dbContext.TbConfPiepaginadets.Add(piepaginadet);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = piepaginadet.Id }, piepaginadet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbConfPiepaginadet piepaginadet)
        {
            if (id != piepaginadet.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(piepaginadet).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiepaginadetExists(id))
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
            var piepaginadet = await _dbContext.TbConfPiepaginadets.FindAsync(id);
            if (piepaginadet == null)
            {
                return NotFound();
            }
            _dbContext.TbConfPiepaginadets.Remove(piepaginadet);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool PiepaginadetExists(int id)
        {
            return _dbContext.TbConfPiepaginadets.Any(e => e.Id == id);
        }
    }
}
