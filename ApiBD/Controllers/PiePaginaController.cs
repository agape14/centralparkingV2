using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/piepagina")]
    public class PiePaginaController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public PiePaginaController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbConfPiepaginacab>>> Get()
        {
            var piepaginas = await _dbContext.TbConfPiepaginacabs.ToListAsync();
            return piepaginas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfPiepaginacab>> GetById(int id)
        {
            var piepagina = await _dbContext.TbConfPiepaginacabs.FindAsync(id);
            if (piepagina == null)
            {
                return NotFound();
            }
            return piepagina;
        }

        [HttpPost]
        public async Task<ActionResult<TbConfPiepaginacab>> Create(TbConfPiepaginacab piepagina)
        {
            _dbContext.TbConfPiepaginacabs.Add(piepagina);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = piepagina.Id }, piepagina);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbConfPiepaginacab piepagina)
        {
            if (id != piepagina.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(piepagina).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PiepaginaExists(id))
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
            var piepagina = await _dbContext.TbConfPiepaginacabs.FindAsync(id);
            if (piepagina == null)
            {
                return NotFound();
            }
            _dbContext.TbConfPiepaginacabs.Remove(piepagina);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool PiepaginaExists(int id)
        {
            return _dbContext.TbConfPiepaginacabs.Any(e => e.Id == id);
        }
    }
}
