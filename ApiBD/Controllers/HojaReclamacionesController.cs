using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/hojareclamaciones")]
    public class HojaReclamacionesController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public HojaReclamacionesController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbFormHojareclamacione>>> Get()
        {
            var lista = await _dbContext.TbFormHojareclamaciones.ToListAsync();
            return lista;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbFormHojareclamacione>> GetById(int id)
        {
            var hojareclamacione = await _dbContext.TbFormHojareclamaciones.FindAsync(id);
            if (hojareclamacione == null)
            {
                return NotFound();
            }
            return hojareclamacione;
        }

        [HttpPost]
        public async Task<ActionResult<TbFormHojareclamacione>> Create(TbFormHojareclamacione tbFormHojareclamacione)
        {
            _dbContext.TbFormHojareclamaciones.Add(tbFormHojareclamacione);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tbFormHojareclamacione.Id }, tbFormHojareclamacione);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbFormHojareclamacione tbFormHojareclamacione)
        {
            if (id != tbFormHojareclamacione.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(tbFormHojareclamacione).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HojaReclamacioneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(tbFormHojareclamacione);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var hojareclamacione = await _dbContext.TbFormHojareclamaciones.FindAsync(id);
            if (hojareclamacione == null)
            {
                return NotFound();
            }
            _dbContext.TbFormHojareclamaciones.Remove(hojareclamacione);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool HojaReclamacioneExists(int id)
        {
            return _dbContext.TbFormHojareclamaciones.Any(e => e.Id == id);
        }

    }
}
