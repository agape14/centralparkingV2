using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public UsuarioController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }



        // GET: Usuario/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null || _dbContext.TbConfUsers == null)
            {
                return NotFound();
            }

            var tbConfUser = await _dbContext.TbConfUsers
                .Include(t => t.Rol)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbConfUser == null)
            {
                return NotFound();
            }

            return Ok(tbConfUser);
        }



        // GET: Usuario/Edit/5
        [HttpPut]
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null || _dbContext.TbConfUsers == null)
            {
                return NotFound();
            }

            var tbConfUser = await _dbContext.TbConfUsers.FindAsync(id);
            if (tbConfUser == null)
            {
                return NotFound();
            }
          
            return Ok(tbConfUser);
        }



        // GET: Usuario/Delete/5
        [HttpDelete]
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null || _dbContext.TbConfUsers == null)
            {
                return NotFound();
            }

            var tbConfUser = await _dbContext.TbConfUsers
                .Include(t => t.Rol)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbConfUser == null)
            {
                return NotFound();
            }

            return Ok(tbConfUser);
        }

      

       

    }
}
