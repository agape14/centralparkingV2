using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/servicioCabecera")]
    public class ServicioCabeceraController : Controller
    {

        private readonly CentralParkingContext _dbContext;

        public ServicioCabeceraController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbServCabecera>>> Get()
        {
            var servicio = await _dbContext.TbServCabeceras.Where(x=>x.IsMenu == 0).ToListAsync();
            return servicio;
        }

        [HttpGet]
        [Route("cms")]
        public async Task<ActionResult<IEnumerable<TbServCabecera>>> GetAllServicios()
        {
            var servicio = await _dbContext.TbServCabeceras.ToListAsync();
            return servicio;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbServCabecera>> GetById(int id)
        {
            var servicio = await _dbContext.TbServCabeceras.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }
            return Ok(servicio);
        }

        [HttpPost]
        public async Task<ActionResult<TbServCabecera>> Create(TbServCabecera servicio)
        {
            _dbContext.TbServCabeceras.Add(servicio);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = servicio.Id }, servicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbServCabecera tbServCabecera)
        {
            if (id != tbServCabecera.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(tbServCabecera).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabeceraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(tbServCabecera);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cabecera = await _dbContext.TbServCabeceras.FindAsync(id);
            if (cabecera == null)
            {
                return NotFound();
            }
            _dbContext.TbServCabeceras.Remove(cabecera);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool CabeceraExists(int id)
        {
            return _dbContext.TbServCabeceras.Any(e => e.Id == id);
        }


    }
}
