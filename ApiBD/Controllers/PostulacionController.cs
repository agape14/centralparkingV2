using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    
    [ApiController]
    [Route("api/postulacion")]
    public class PostulacionController : Controller
    {

        private readonly CentralParkingContext _dbContext;

        public PostulacionController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("vertodos")]
        public async Task<ActionResult<IEnumerable<TbFormTbcnosotro>>> GetAll()
        {
            //var postulaciones = await _dbContext.TbFormTbcnosotros.OrderByDescending(p => p.Id).ToListAsync();
            var postulaciones = await _dbContext.TbFormTbcnosotros
                                        .OrderByDescending(p => p.Id)
                                        .ToListAsync();
            return postulaciones;
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<TbFormTbcnosotro>> GetPostulacionById(int id)
        {
            var postulaciones = await _dbContext.TbFormTbcnosotros.FindAsync(id);
            if (postulaciones == null)
            {
                return NotFound();
            }
            return Ok(postulaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbIndCaracteristica>> GetById(int id)
        {
            var postulaciones = await _dbContext.TbFormTbcnosotros.FindAsync(id);
            if (postulaciones == null)
            {
                return NotFound();
            }
            return Ok(postulaciones);
        }


        [HttpPost]
        public async Task<ActionResult<TbFormTbcnosotro>> Create(TbFormTbcnosotro tbFormTbcnosotro)
        {
            if (tbFormTbcnosotro.Distrito.ToString().Length == 6)
            {
                var tbldistrito = await _dbContext.TbConfUbigeos.FirstOrDefaultAsync(u => u.CodUbi == tbFormTbcnosotro.Distrito.ToString());
                if (tbldistrito != null)
                {
                    tbFormTbcnosotro.Departamento = tbldistrito.Dist;
                }
            }
            _dbContext.TbFormTbcnosotros.Add(tbFormTbcnosotro);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tbFormTbcnosotro.Id }, tbFormTbcnosotro);
        }

       
    }
}
