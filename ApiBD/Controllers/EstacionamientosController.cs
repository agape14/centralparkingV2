using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiBD.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ApiBD.Controllers
{
    [ApiController]
    [Route("api/estacionamientos")]
    public class EstacionamientosController : Controller
    {
        private readonly CentralParkingContext _context;

        public EstacionamientosController(CentralParkingContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbConfUbigeoServicio>>> Get()
        {
            var centralParkingContext = _context.TbEstacionamientos.Include(t => t.TbConfUbigeo);
            var estacionamientos=await centralParkingContext.ToListAsync();
            if (estacionamientos == null)
            {
                return NotFound();
            }
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                MaxDepth = 64
            };

            var estacionamientosJson = JsonSerializer.Serialize(estacionamientos, options);
            return Ok(estacionamientosJson);
        }

        [HttpGet("{codUbi}")]
        public async Task<ActionResult<IEnumerable<TbConfUbigeoServicio>>> GetByDistrito(string codUbi)
        {
            if (codUbi == null || _context.TbEstacionamientos == null)
            {
                return NotFound();
            }

            var listEstacionaiento = from datos in this._context.TbEstacionamientos
                              where datos.CodUbi == codUbi
                              select datos;
            var estacionamiento = await listEstacionaiento
                .Include(t => t.TbConfUbigeo)
                .AsNoTracking()
                .ToListAsync();

            if (estacionamiento == null)
            {
                return NotFound();
            }
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                MaxDepth = 64
            };

            var estacionamientoJson = JsonSerializer.Serialize(estacionamiento, options);
            return Ok(estacionamientoJson);
        }

        [HttpGet("vertodos")]
        public async Task<ActionResult<IEnumerable<TbEstacionamiento>>> GetAll()
        {
            var estacionamientos = await _context.TbEstacionamientos.ToListAsync();
            return estacionamientos;
        }

        [HttpGet("vertodoxid/{codUbi}")]
        public async Task<ActionResult<TbEstacionamiento>> GetAllByCodUbi(string codUbi)
        {
            var estacionamiento = await _context.TbEstacionamientos.Where(c => c.CodUbi == codUbi).ToListAsync();
            if (estacionamiento == null)
            {
                return NotFound();
            }
            return Ok(estacionamiento);
        }

        [HttpGet("tblestacio/{codUbi}")]
        public async Task<List<TbEstacionamiento>> GetTblEstacionamiento(string codUbi)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            var tblesta = await _context.TbEstacionamientos.Where(c => c.CodUbi == codUbi).ToListAsync();
            var tblestaJson = JsonSerializer.Serialize(tblesta, options);
            var DistritoDeserializados = JsonSerializer.Deserialize<List<TbEstacionamiento>>(tblestaJson, options);
            return DistritoDeserializados;
        }

        [HttpGet("verestacionamiento/{id}")]
        public async Task<ActionResult<TbEstacionamiento>> GetEstacionamientoByCodUbi(int id)
        {
            //var estacionamiento = await _context.TbEstacionamientos.Where(c => c.CodUbi == codUbi && c.Estacionamiento == vestacionam).ToListAsync();
            //if (estacionamiento == null)
            //{
            //    return NotFound();
            //}
            //return Ok(estacionamiento);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                MaxDepth = 64
            };


            var estacionamiento = await _context.TbEstacionamientos.Include(t => t.TbConfUbigeo).FirstOrDefaultAsync(m => m.Id == id);
            if (estacionamiento == null)
            {
                return NotFound();
            }
            return new JsonResult(estacionamiento, options);
        }

        [HttpPost]
        public async Task<ActionResult<TbEstacionamiento>> Create(TbEstacionamiento estacionamiento)
        {
            _context.TbEstacionamientos.Add(estacionamiento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllByCodUbi), new { codUbi = estacionamiento.CodUbi }, estacionamiento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TbEstacionamiento estacionamiento)
        {
            if (id != estacionamiento.Id)
            {
                return BadRequest();
            }
            _context.Entry(estacionamiento).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbEstacionamientoExists(id))
        {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(estacionamiento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estacionamiento = await _context.TbEstacionamientos.FindAsync(id);
            if (estacionamiento == null)
            {
                return NotFound();
            }
            _context.TbEstacionamientos.Remove(estacionamiento);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        private bool TbEstacionamientoExists(int id)
        {
            return _context.TbEstacionamientos.Any(e => e.Id == id);
        }
    }
}
