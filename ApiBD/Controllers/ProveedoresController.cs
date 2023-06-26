using ApiBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/proveedor")]
    public class ProveedoresController : Controller
    {
        private readonly CentralParkingContext _dbContext;

        public ProveedoresController(CentralParkingContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbFormProveedore>>> Get()
        {
            var proveedores = await _dbContext.TbFormProveedores.ToListAsync();
            return proveedores;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbFormProveedore>> GetById(int id)
        {
            var proveedor = await _dbContext.TbFormProveedores.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return proveedor;
        }

        [HttpPost]
        public async Task<ActionResult<TbFormProveedore>> Create(TbFormProveedore proveedor)
        {
            _dbContext.TbFormProveedores.Add(proveedor);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = proveedor.Id }, proveedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbFormProveedore proveedor)
        {
            if (id != proveedor.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(proveedor).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(proveedor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var proveedor = await _dbContext.TbFormProveedores.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            _dbContext.TbFormProveedores.Remove(proveedor);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool ProveedorExists(int id)
        {
            return _dbContext.TbFormProveedores.Any(e => e.Id == id);
        }
    }
}
