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
        public async Task<ActionResult<IEnumerable<TbProvRegistro>>> Get()
        {
            var proveedores = await _dbContext.TbProvRegistros.ToListAsync();
            return proveedores;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TbProvRegistro>> GetById(int id)
        {
            var proveedor = await _dbContext.TbProvRegistros.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return proveedor;
        }

        [HttpPost]
        public async Task<ActionResult<TbProvRegistro>> Create(TbProvRegistro proveedor)
        {
            _dbContext.TbProvRegistros.Add(proveedor);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = proveedor.Id }, proveedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbProvRegistro proveedor)
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
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var proveedor = await _dbContext.TbProvRegistros.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            _dbContext.TbProvRegistros.Remove(proveedor);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool ProveedorExists(int id)
        {
            return _dbContext.TbProvRegistros.Any(e => e.Id == id);
        }
    }
}
