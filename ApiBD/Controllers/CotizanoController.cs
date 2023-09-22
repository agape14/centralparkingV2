using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/cotizanos")]
    public class CotizanoController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public CotizanoController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("tipoServicio/{codigo}")]
        public async Task<List<TbFormCotizano>> Get(int codigo)
        {
            var contactos = await _dbContext.TbFormCotizanos.Where(p=>p.TipoServicio.Equals(codigo)).ToListAsync();
            return contactos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbFormCotizano>> GetById(int id)
        {
            var postulaciones = await _dbContext.TbFormCotizanos.FindAsync(id);
            if (postulaciones == null)
            {
                return NotFound();
            }
            return Ok(postulaciones);
        }


        [HttpPost]
        public async Task<ActionResult<TbFormCotizano>> Create(TbFormCotizano tbFormCotizano)
        {
            _dbContext.TbFormCotizanos.Add(tbFormCotizano);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tbFormCotizano.Id }, tbFormCotizano);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbFormCotizano tbFormCotizano)
        {
            if (id != tbFormCotizano.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(tbFormCotizano).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(tbFormCotizano);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contacto = await _dbContext.TbFormCotizanos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }

            _dbContext.TbFormCotizanos.Remove(contacto);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }



        private bool ContactoExists(int id)
        {
            return _dbContext.TbFormCotizanos.Any(e => e.Id == id);
        }
    }
}
