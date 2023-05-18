using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/redsocial")]
    public class RedesSocialesController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public RedesSocialesController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbIndRedsocial>>> Get()
        {
            var redessociales = await _dbContext.TbIndRedsocials.ToListAsync();
            return redessociales;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbIndRedsocial>> GetById(int id)
        {
            var redsocial = await _dbContext.TbIndRedsocials.FindAsync(id);
            if (redsocial == null)
            {
                return NotFound();
            }
            return redsocial;
        }

        [HttpPost]
        public async Task<ActionResult<TbIndRedsocial>> Create(TbIndRedsocial redsocial)
        {
            _dbContext.TbIndRedsocials.Add(redsocial);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = redsocial.Id }, redsocial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbIndRedsocial redsocial)
        {
            if (id != redsocial.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(redsocial).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RedsocialExists(id))
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
            var redsocial = await _dbContext.TbIndRedsocials.FindAsync(id);
            if (redsocial == null)
            {
                return NotFound();
            }
            _dbContext.TbIndRedsocials.Remove(redsocial);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool RedsocialExists(int id)
        {
            return _dbContext.TbIndRedsocials.Any(e => e.Id == id);
        }
    }
}
