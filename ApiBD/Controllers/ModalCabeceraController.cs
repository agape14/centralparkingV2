using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/modalcabecera")]
    public class ModalCabeceraController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public ModalCabeceraController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [Route("entrada")]
        public async Task<ActionResult<IEnumerable<TbConfPiepaginadet>>> GetALL()
        {
            var lista = await _dbContext.TbConfPiepaginadets
                             .Where(p => p.Titulo != null && p.Ruta != null)
                             .ToListAsync();

            return lista;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbConfModalcab>>> Get()
        {
            var lista = await _dbContext.TbConfModalcabs.ToListAsync();
            return lista;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfModalcab>> GetById(int id)
        {
            var modalcabera = await _dbContext.TbConfModalcabs.FindAsync(id);
            if (modalcabera == null)
            {
                return NotFound();
            }
            return modalcabera;
        }

        [HttpPost]
        public async Task<ActionResult<TbConfModalcab>> Create(TbConfModalcab tbConfModalcab)
        {
            _dbContext.TbConfModalcabs.Add(tbConfModalcab);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tbConfModalcab.Id }, tbConfModalcab);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbConfModalcab tbConfModalcab)
        {
            if (id != tbConfModalcab.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(tbConfModalcab).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(tbConfModalcab);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var modalcabecera = await _dbContext.TbConfModalcabs.FindAsync(id);
            if (modalcabecera == null)
            {
                return NotFound();
            }
            _dbContext.TbConfModalcabs.Remove(modalcabecera);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool ProveedorExists(int id)
        {
            return _dbContext.TbConfModalcabs.Any(e => e.Id == id);
        }
    }
}
