using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/contactanos")]
    public class ContactanoController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public ContactanoController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<List<TbFormContactano>> Get()
        {
            var contactos = await _dbContext.TbFormContactanos.ToListAsync();
            return contactos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbFormContactano>> GetById(int id)
        {
            var postulaciones = await _dbContext.TbFormContactanos.FindAsync(id);
            if (postulaciones == null)
            {
                return NotFound();
            }
            return Ok(postulaciones);
        }


        [HttpPost]
        public async Task<ActionResult<TbFormContactano>> Create(TbFormContactano tbFormContactano)
        {
            _dbContext.TbFormContactanos.Add(tbFormContactano);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tbFormContactano.Id }, tbFormContactano);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbFormContactano tbFormContactano)
        {
            if (id != tbFormContactano.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(tbFormContactano).State = EntityState.Modified;
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
            return Ok(tbFormContactano);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contacto = await _dbContext.TbFormContactanos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }

            _dbContext.TbFormContactanos.Remove(contacto);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }



        private bool ContactoExists(int id)
        {
            return _dbContext.TbFormContactanos.Any(e => e.Id == id);
        }
    }
}
