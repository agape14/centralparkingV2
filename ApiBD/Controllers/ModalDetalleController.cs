using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/modaldetalle")]
    public class ModalDetalleController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public ModalDetalleController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


       

        [HttpGet]
        [Route("detalle/{id}")]
        public async Task<ActionResult<IEnumerable<TbConfModaldet>>> Get(int id)
        {
            var resultado = await _dbContext.TbConfModalcabs
                                   .FirstOrDefaultAsync(x => x.IdDetallePie == id);

            var lista = await _dbContext.TbConfModaldets.Where(x => x.ModalcabId == resultado.Id).ToListAsync();

            return lista;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfModaldet>> GetById(int id)
        {
            var modaldetalle = await _dbContext.TbConfModaldets.FindAsync(id);
            if (modaldetalle == null)
            {
                return NotFound();
            }
            return modaldetalle;
        }

        [HttpPost]
        public async Task<ActionResult<TbConfModaldet>> Create(TbConfModaldet tbConfModaldet)
        {
            _dbContext.TbConfModaldets.Add(tbConfModaldet);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tbConfModaldet.Id }, tbConfModaldet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbConfModaldet tbConfModaldet)
        {
            if (id != tbConfModaldet.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(tbConfModaldet).State = EntityState.Modified;
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
            return Ok(tbConfModaldet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var modaldetalle = await _dbContext.TbConfModaldets.FindAsync(id);
            if (modaldetalle == null)
            {
                return NotFound();
            }
            _dbContext.TbConfModaldets.Remove(modaldetalle);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool ProveedorExists(int id)
        {
            return _dbContext.TbConfModaldets.Any(e => e.Id == id);
        }
    }
}
