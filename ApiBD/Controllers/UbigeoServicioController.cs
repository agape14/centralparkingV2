using ApiBD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/ubigeoServicio")]
    public class UbigeoServicioController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public UbigeoServicioController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbConfPermiso>>> Get()
        {
            var listUbiServs = _dbContext.TbConfUbigeoServicios
                .Include(t => t.TbConfUbigeo)
                .Include(t => t.TbServCabecera)
                .AsNoTracking(); // Evita el seguimiento de entidades para mejorar el rendimiento

            var ubiservsLista = await listUbiServs.ToListAsync();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                MaxDepth = 64
            };

            var ubiservsJson = JsonSerializer.Serialize(ubiservsLista, options);

            // Retorna la respuesta JSON
            return Ok(ubiservsJson);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TbConfUbigeoServicio>>> GetUbigeoByIdServicio(int id)
        {
            var listUbiServ = from datos in this._dbContext.TbConfUbigeoServicios
                              where datos.IdServicio == id
                              select datos;
            var ubigeoservicio = await listUbiServ
                .Include(t => t.TbConfUbigeo)
                .Include(t => t.TbServCabecera)
                .AsNoTracking()
                .ToListAsync();

            if (ubigeoservicio == null)
            {
                return NotFound();
            }
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                MaxDepth = 64
            };
            var ubiserJson = JsonSerializer.Serialize(ubigeoservicio, options);
            return Ok(ubiserJson);
        }

        [HttpPost]
        public async Task<ActionResult<TbConfUbigeoServicio>> Create(TbConfUbigeoServicio ubigeoservicio)
        {
            _dbContext.TbConfUbigeoServicios.Add(ubigeoservicio);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUbigeoByIdServicio), new { id = ubigeoservicio.IdServicio }, ubigeoservicio);
        }

        [HttpDelete("{idservicio}/{codubi}")]
        public async Task<IActionResult> Delete(int idservicio, string codubi)
        {
            //var ubigeoservicio = await _dbContext.TbConfUbigeoServicios.FindAsync(idservicio, codubi);
            var ubigeoservicio = await _dbContext.TbConfUbigeoServicios
                .FirstOrDefaultAsync(m => m.IdServicio == idservicio && m.CodUbi == codubi);
            if (ubigeoservicio == null)
            {
                return NotFound();
            }
            _dbContext.TbConfUbigeoServicios.Remove(ubigeoservicio);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{idservicio}/{codubi}")]
        public async Task<ActionResult<TbConfUbigeoServicio>> GetById(int idservicio, string codubi)
        {
            var listUbiServ = from datos in this._dbContext.TbConfUbigeoServicios
                              where datos.IdServicio == idservicio && datos.CodUbi== codubi
                              select datos;
            var ubigeoservicio = await listUbiServ
                .Include(t => t.TbConfUbigeo)
                .Include(t => t.TbServCabecera)
                .AsNoTracking()
                .ToListAsync();
            if (ubigeoservicio == null)
            {
                return NotFound();
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                MaxDepth = 64
            };

            var permisoJson = JsonSerializer.Serialize(ubigeoservicio, options);

            // Retorna la respuesta JSON
            return Content(permisoJson, "application/json");
        }

       
    }
}
