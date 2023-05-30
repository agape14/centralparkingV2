using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        public async Task<IActionResult> Get()
        {
            try
            {
                var slides = await _dbContext.TbIndSlidecabs
                    .Include(i => i.IdBtn1Navigation)
                    .ToListAsync();

                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };

                var json = JsonSerializer.Serialize(slides, options);

                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                // Manejar la excepción y devolver una respuesta de error apropiada
                return StatusCode(500, "Ocurrió un error en el servidor.");
            }
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<TbIndSlidecab>> GetDetails(uint id)
        {
            var tbIndSlidecab = await _dbContext.TbIndSlidecabs.FirstOrDefaultAsync(m => m.Id == id);

            if (tbIndSlidecab == null)
            {
                return NotFound();
            }

            return Ok(tbIndSlidecab);
        }


        [HttpPost]
        public async Task<IActionResult> Create(TbIndSlidecab tbIndSlidecab)
        {
            _dbContext.TbIndSlidecabs.Add(tbIndSlidecab);
            await _dbContext.SaveChangesAsync();

            // El ID se generará automáticamente en la base de datos y se actualizará en el objeto tbIndSlidecab
            return Ok(tbIndSlidecab);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(uint id, TbIndSlidecab slide)
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
            return Ok(slide);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(uint id)
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



        private bool SlideExists(uint id)
        {
            return _dbContext.TbIndSlidecabs.Any(e => e.Id == id);
        }
        
    }
}
