using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/rubro")]
    public class RubroController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public RubroController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<List<TbConfRubro>> Get()
        {
            var rubros = await _dbContext.TbConfRubros.ToListAsync();
            return rubros;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfRubro>> GetById(int id)
        {
            var rubro = await _dbContext.TbConfRubros.FindAsync(id);
            if (rubro == null)
            {
                return NotFound();
            }
            return rubro;
        }

        [HttpPost]
        public async Task<ActionResult<TbConfRubro>> Create(TbConfRubro rubro)
        {
            _dbContext.TbConfRubros.Add(rubro);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = rubro.Id }, rubro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbConfRubro rubro)
        {
            if (id != rubro.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(rubro).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RubroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(rubro);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rubro = await _dbContext.TbConfRubros.FindAsync(id);
            if (rubro == null)
            {
                return NotFound();
            }
            _dbContext.TbConfRubros.Remove(rubro);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool RubroExists(int id)
        {
            return _dbContext.TbConfRubros.Any(e => e.Id == id);
        }
    }
}
