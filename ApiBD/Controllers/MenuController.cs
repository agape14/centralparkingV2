using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/menu")]
    public class MenuController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public MenuController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbConfMenu>>> Get()
        {
            var menus = await _dbContext.TbConfMenus.ToListAsync();
            return menus;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbConfMenu>> GetById(int id)
        {
            var menu = await _dbContext.TbConfMenus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return menu;
        }

        [HttpPost]
        public async Task<ActionResult<TbConfMenu>> Create(TbConfMenu menu)
        {
            _dbContext.TbConfMenus.Add(menu);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = menu.Id }, menu);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbConfMenu menu)
        {
            if (id != menu.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(menu).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
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
            var menu = await _dbContext.TbConfMenus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            _dbContext.TbConfMenus.Remove(menu);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool MenuExists(int id)
        {
            return _dbContext.TbConfMenus.Any(e => e.Id == id);
        }
    }
}
