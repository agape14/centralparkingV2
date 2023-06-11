using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;

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
            _dbContext.TbFormTbcnosotros.Add(tbFormTbcnosotro);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tbFormTbcnosotro.Id }, tbFormTbcnosotro);
        }

       
    }
}
