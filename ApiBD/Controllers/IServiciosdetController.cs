using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/serviciosdet")]
    public class IServiciosdetController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public IServiciosdetController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<TbIndServiciodet>>> Get()
        {
            var listIServiciodets = from datos in this._dbContext.TbIndServiciodets
                                    select datos;
            var iServicioDet = await listIServiciodets.ToListAsync();

            return Ok(iServicioDet);
        }

        [HttpGet("filtrarPorCodigo/{codigo}")]
        public async Task<ActionResult<List<TbIndServiciodet>>> FiltrarPorCodigo(int codigo)
        {
            var servicioDetLista = await _dbContext.TbIndServiciodets
                .Where(p => p.IdCab == codigo)
                .ToListAsync();

            return Ok(servicioDetLista);
        }


        [HttpGet("Details/{id}/{codigo}")]
        public async Task<IActionResult> Details(int id, int codigo)
        {
            var tbIndServiciodet = await _dbContext.TbIndServiciodets
                .Include(t => t.IdCabNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (tbIndServiciodet == null)
            {
                return NotFound();
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            var serializedObject = JsonSerializer.Serialize(tbIndServiciodet, options);

            return Content(serializedObject, "application/json");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TbIndServiciodet>> GetById(int id)
        {
            var serviciodet = await _dbContext.TbIndServiciodets.FindAsync(id);
            if (serviciodet == null)
            {
                return NotFound();
            }
            return serviciodet;
        }

        [HttpPost]
        public async Task<ActionResult<TbIndServiciodet>> Create(TbIndServiciodet serviciodet)
        {
            _dbContext.TbIndServiciodets.Add(serviciodet);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = serviciodet.Id }, serviciodet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbIndServiciodet serviciodet)
        {
            if (id != serviciodet.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(serviciodet).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciodetExists(id))
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
            var serviciodet = await _dbContext.TbIndServiciodets.FindAsync(id);
            if (serviciodet == null)
            {
                return NotFound();
            }
            _dbContext.TbIndServiciodets.Remove(serviciodet);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool ServiciodetExists(int id)
        {
            return _dbContext.TbIndServiciodets.Any(e => e.Id == id);
        }
    }
}
