using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/rol")]
    public class RolController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public RolController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<List<TbConfRole>> Get()
        {
            var roles = await _dbContext.TbConfRoles.ToListAsync();
            return roles;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfRole>> GetById(int id)
        {
            var rol = await _dbContext.TbConfRoles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return rol;
        }

        [HttpPost]
        public async Task<ActionResult<TbConfRole>> Create(TbConfRole rol)
        {
            _dbContext.TbConfRoles.Add(rol);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = rol.Id }, rol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbConfRole rol)
        {
            if (id != rol.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(rol).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(rol);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rol = await _dbContext.TbConfRoles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            _dbContext.TbConfRoles.Remove(rol);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool RolExists(int id)
        {
            return _dbContext.TbConfRoles.Any(e => e.Id == id);
        }
    }
}
