using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/servicioDetalle")]
    public class ServicioDetalleController : Controller
    {

        private readonly CentralParkingContext _dbContext;

        public ServicioDetalleController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbServDetalle>>> Get()
        {
            var lista = await _dbContext.TbServDetalles.ToListAsync();
            return lista;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbServDetalle>> GetById(int id)
        {
            var servicioDetalle = await _dbContext.TbServDetalles.FindAsync(id);
            if (servicioDetalle == null)
            {
                return NotFound();
            }
            return Ok(servicioDetalle);
        }

    }
}
