using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/botones")]
    public class BotonController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public BotonController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbConfBotone>>> Get()
        {
            var botones = await _dbContext.TbConfBotones.ToListAsync();
            return botones;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfBotone>> GetById(int id)
        {
            var boton = await _dbContext.TbConfBotones.FindAsync(id);
            if (boton == null)
            {
                return NotFound();
            }
            return Ok(boton);
        }

        [HttpPost]
        public async Task<ActionResult<TbConfBotone>> Create(TbConfBotone boton)
        {
            _dbContext.TbConfBotones.Add(boton);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = boton.Id }, boton);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbConfBotone boton)
        {
            if (id != boton.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(boton).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BotonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(boton);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var boton = await _dbContext.TbConfBotones.FindAsync(id);
            if (boton == null)
            {
                return NotFound();
            }
            _dbContext.TbConfBotones.Remove(boton);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool BotonExists(int id)
        {
            return _dbContext.TbConfBotones.Any(e => e.Id == id);
        }
    }
}
    