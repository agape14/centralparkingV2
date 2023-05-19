using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/slide")]
    public class SlideController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public SlideController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbIndSlidecab>>> Get()
        {
            var slides = await _dbContext.TbIndSlidecabs.ToListAsync();
            return slides;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbIndSlidecab>> GetById(int id)
        {
            var slide = await _dbContext.TbIndSlidecabs.FindAsync(id);
            if (slide == null)
            {
                return NotFound();
            }
            return slide;
        }

        [HttpPost]
        public async Task<ActionResult<TbIndSlidecab>> Create(TbIndSlidecab slide)
        {
            _dbContext.TbIndSlidecabs.Add(slide);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = slide.Id }, slide);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbIndSlidecab slide)
        {
            if (id != slide.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(slide).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlideExists(id))
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
            var slide = await _dbContext.TbIndSlidecabs.FindAsync(id);
            if (slide == null)
            {
                return NotFound();
            }
            _dbContext.TbIndSlidecabs.Remove(slide);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool SlideExists(int id)
        {
            return _dbContext.TbIndSlidecabs.Any(e => e.Id == id);
        }
    }
}
