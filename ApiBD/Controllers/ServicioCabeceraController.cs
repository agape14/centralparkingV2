using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/servicioCabecera")]
    public class ServicioCabeceraController : Controller
    {

        private readonly CentralParkingContext _dbContext;

        public ServicioCabeceraController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbServCabecera>>> Get()
        {
            var servicio = await _dbContext.TbServCabeceras.Where(x=>x.IsMenu == 0).ToListAsync();
            return servicio;
        }

        
    }
}
