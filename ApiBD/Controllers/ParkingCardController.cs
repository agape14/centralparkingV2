using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/parkingcard")]
    public class ParkingCardController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public ParkingCardController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbFormParkingcard>>> Get()
        {
            var lista = await _dbContext.TbFormParkingcards.ToListAsync();
            return lista;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbFormParkingcard>> GetById(int id)
        {
            var parkingcard = await _dbContext.TbFormParkingcards.FindAsync(id);
            if (parkingcard == null)
            {
                return NotFound();
            }
            return parkingcard;
        }

        [HttpPost]
        public async Task<ActionResult<TbFormParkingcard>> Create(TbFormParkingcard tbFormParkingcard)
        {
            _dbContext.TbFormParkingcards.Add(tbFormParkingcard);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tbFormParkingcard.Id }, tbFormParkingcard);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbFormParkingcard tbFormParkingcard)
        {
            if (id != tbFormParkingcard.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(tbFormParkingcard).State = EntityState.Modified;
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
            return Ok(tbFormParkingcard);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var parkingcard = await _dbContext.TbFormParkingcards.FindAsync(id);
            if (parkingcard == null)
            {
                return NotFound();
            }
            _dbContext.TbFormParkingcards.Remove(parkingcard);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool ProveedorExists(int id)
        {
            return _dbContext.TbFormParkingcards.Any(e => e.Id == id);
        }
    }
}
