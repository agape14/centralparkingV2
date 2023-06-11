using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/contactanos")]
    public class ContactanoController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public ContactanoController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbFormContactano>> GetById(int id)
        {
            var postulaciones = await _dbContext.TbFormContactanos.FindAsync(id);
            if (postulaciones == null)
            {
                return NotFound();
            }
            return Ok(postulaciones);
        }


        [HttpPost]
        public async Task<ActionResult<TbFormContactano>> Create(TbFormContactano tbFormContactano)
        {
            _dbContext.TbFormContactanos.Add(tbFormContactano);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tbFormContactano.Id }, tbFormContactano);
        }
    }
}
