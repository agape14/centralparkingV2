using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/paginas")]
    public class PaginasController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public PaginasController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbConfPaginascab>>> Get()
        {
            var paginas = await _dbContext.TbConfPaginascabs.ToListAsync();
            return paginas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfPaginascab>> GetById(int id)
        {
            var pagina = await _dbContext.TbConfPaginascabs.FindAsync(id);
            if (pagina == null)
            {
                return NotFound();
            }
            return pagina;
        }

        [HttpPost]
        public async Task<ActionResult<TbConfPaginascab>> Create(TbConfPaginascab pagina)
        {
            _dbContext.TbConfPaginascabs.Add(pagina);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = pagina.Id }, pagina);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbConfPaginascab pagina)
        {
            if (id != pagina.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(pagina).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaginaExists(id))
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
            var pagina = await _dbContext.TbConfPaginascabs.FindAsync(id);
            if (pagina == null)
            {
                return NotFound();
            }
            _dbContext.TbConfPaginascabs.Remove(pagina);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool PaginaExists(int id)
        {
            return _dbContext.TbConfPaginascabs.Any(e => e.Id == id);
        }
    }
}
