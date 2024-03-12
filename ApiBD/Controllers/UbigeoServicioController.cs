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

        //[HttpGet("{id}")]
        //public async Task<ActionResult<TbConfUbigeoServicio>> GetUbigeoByIdServicio(int id)
        //{
        //    var ubigeoservicio = await _dbContext.TbConfUbigeoServicios
        //                        .Include(t => t.TbConfUbigeo)
        //                        .Include(t => t.TbServCabecera)
        //                        .AsNoTracking()
        //                        .FirstOrDefaultAsync(m => m.IdServicio == id);
        //    if (ubigeoservicio == null)
        //    {
        //        return NotFound();
        //    }

        //    var options = new JsonSerializerOptions
        //    {
        //        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        //        MaxDepth = 64
        //    };

        //    var permisoJson = JsonSerializer.Serialize(ubigeoservicio, options);
        //    // Retorna la respuesta JSON
        //    return Content(permisoJson, "application/json");
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TbConfUbigeoServicio>>> GetUbigeoByIdServicio(int id)
        {
            var ubigeoservicio = _dbContext.TbConfUbigeoServicios
                .Include(t => t.TbConfUbigeo)
                .Include(t => t.TbServCabecera)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.IdServicio == id); ; // Evita el seguimiento de entidades para mejorar el rendimiento

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
