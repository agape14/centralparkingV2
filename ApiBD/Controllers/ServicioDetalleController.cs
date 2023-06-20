using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/servicioDetalle")]
    public class ServicioDetalleController : Controller
    {

        private readonly CentralParkingContext _dbContext;

        public ServicioDetalleController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbServDetalle>>> Get()
        {
            var lista = await _dbContext.TbServDetalles.ToListAsync();
            return lista;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbServDetalle>> GetById(int id)
        {
            var servicioDetalle = await _dbContext.TbServDetalles.Where(x=>x.IdServicio == id).ToListAsync();
            if (servicioDetalle == null)
            {
                return NotFound();
            }
            return Ok(servicioDetalle);
        }


        [HttpGet("serviciodetalle/{id}")]
        public async Task<ActionResult<TbServDetalle>> GetById2(int id)
        {
            var servicioDetalle = await _dbContext.TbServDetalles.FirstOrDefaultAsync(x=>x.Id==id);
            if (servicioDetalle == null)
            {
                return NotFound();
            }
            return Ok(servicioDetalle);
        }

        [HttpPost]
        public async Task<ActionResult<TbServDetalle>> Create(TbServDetalle servicio)
        {
            _dbContext.TbServDetalles.Add(servicio);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById2), new { id = servicio.Id }, servicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbServDetalle tbServDetalle)
        {
            if (id != tbServDetalle.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(tbServDetalle).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlideExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(tbServDetalle);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var servicioDetalle = await _dbContext.TbServDetalles.FindAsync(id);
            if (servicioDetalle == null)
            {
                return NotFound();
            }

            _dbContext.TbServDetalles.Remove(servicioDetalle);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }



        private bool SlideExists(int id)
        {
            return _dbContext.TbServDetalles.Any(e => e.Id == id);
        }

    }
}
