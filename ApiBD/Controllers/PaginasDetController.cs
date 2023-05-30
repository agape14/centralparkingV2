using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/paginasdet")]
    public class PaginasDetController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public PaginasDetController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<TbConfPaginasdet>>> Get()
        {
            var paginasdets = await _dbContext.TbConfPaginasdets.ToListAsync();
            return paginasdets;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfPaginasdet>> GetById(int id)
        {
            var paginadet = await _dbContext.TbConfPaginasdets.FindAsync(id);
            if (paginadet == null)
            {
                return NotFound();
            }
            return paginadet;
        }

        [HttpPost]
        public async Task<ActionResult<TbConfPaginasdet>> Create(TbConfPaginasdet paginadet)
        {
            _dbContext.TbConfPaginasdets.Add(paginadet);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = paginadet.Id }, paginadet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbConfPaginasdet paginadet)
        {
            if (id != paginadet.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(paginadet).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaginadetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(paginadet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var paginadet = await _dbContext.TbConfPaginasdets.FindAsync(id);
            if (paginadet == null)
            {
                return NotFound();
            }
            _dbContext.TbConfPaginasdets.Remove(paginadet);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool PaginadetExists(int id)
        {
            return _dbContext.TbConfPaginasdets.Any(e => e.Id == id);
        }
    }
}
