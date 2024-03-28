using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiBD.Models;
using Cms.ServiceCms;
using System.Collections;

namespace Cms.Controllers
{
    public class EstacionamientoCmsController : Controller
    {
        private readonly CentralParkingContext _context;
        UbigeoServicioscmsService _ubigeoServicioscmsService;
        EstacionamientoCmsService _estacionamientoCmsService;
        public EstacionamientoCmsController(CentralParkingContext context, UbigeoServicioscmsService ubigeoServicioscmsService, EstacionamientoCmsService estacionamientoCmsService)
        {
            _context = context;
            _ubigeoServicioscmsService = ubigeoServicioscmsService;
            _estacionamientoCmsService = estacionamientoCmsService;
        }

        // GET: EstacionamientoCms
        public async Task<IActionResult> Index(string codUbi)
        {
            int idUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0;
            if (idUsuario == 0)
            {
                return RedirectToAction("Index", "DashbordCms");
            }
            var listDistritos = await _ubigeoServicioscmsService.obtenerDistritosPorProvincia("1501");
            ViewData["Distritos"] = new SelectList(listDistritos, "CodUbi", "Dist", codUbi);
            //var centralParkingContext = _context.TbEstacionamientos.Include(t => t.TbConfUbigeo);
            //return View(await centralParkingContext.ToListAsync());

            if (codUbi == "")
            {
                return NotFound();
            }

            var tbEstacionamiento = await _estacionamientoCmsService.listarEstacionamientos(codUbi);
            if (tbEstacionamiento == null)
            {
                return NotFound();
            }

            return View(tbEstacionamiento);
        }

        [HttpGet]
        public IActionResult GetEstacionamientos(string codUbi)
        {
            // Obtener los estacionamientos basados en el codUbi y devolverlos como un JSON
            var estacionamientos = _estacionamientoCmsService.obtenerTablaEstacionamiento(codUbi);
            // Verificar si la respuesta es null o una cadena vacía
            if (estacionamientos == null || string.IsNullOrEmpty(estacionamientos.ToString()))
            {
                List<TbEstacionamiento> objEstacionamiento = new List<TbEstacionamiento>();
                return Json(objEstacionamiento);
            }

            // Si no, devolver la respuesta original como JSON
            return Json(estacionamientos);
        }


        // GET: EstacionamientoCms/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TbEstacionamientos == null)
            {
                return NotFound();
            }

            var tbEstacionamiento = await _context.TbEstacionamientos
                .Include(t => t.TbConfUbigeo)
                .FirstOrDefaultAsync(m => m.CodUbi == id);
            if (tbEstacionamiento == null)
            {
                return NotFound();
            }

            return View(tbEstacionamiento);
        }

        // GET: EstacionamientoCms/Create
        public async Task<IActionResult> Create(string codUbi)
        {
            TbEstacionamiento tbEstacionamiento = new TbEstacionamiento
            {
                CodUbi = codUbi
            };
            var listDistritos = await _ubigeoServicioscmsService.obtenerDistritosPorProvincia("1501");
            ViewData["Distritos"] = new SelectList(listDistritos, "CodUbi", "Dist", codUbi);
            ViewData["CodUbi"] = codUbi;
            return View(tbEstacionamiento);
        }

        // POST: EstacionamientoCms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodUbi,Estacionamiento")] TbEstacionamiento tbEstacionamiento)
        {
            if (ModelState.IsValid)
            {
                await _estacionamientoCmsService.crearEstacionamiento(tbEstacionamiento);
                //return RedirectToAction(nameof(Index), new { codUbi = tbEstacionamiento.CodUbi });
            }
            return RedirectToAction(nameof(Index), new { codUbi = tbEstacionamiento.CodUbi });
        }

        // GET: EstacionamientoCms/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.TbEstacionamientos == null)
            {
                return NotFound();
            }
            var tbEstacionamiento = await _estacionamientoCmsService.verEstacionamientoPorDistrito(id);
            //var tbEstacionamiento = await _context.TbEstacionamientos.FindAsync(id);
            if (tbEstacionamiento == null)
            {
                return NotFound();
            }
            var listDistritos = await _ubigeoServicioscmsService.obtenerDistritosPorProvincia("1501");
            ViewData["Distritos"] = new SelectList(listDistritos, "CodUbi", "Dist", tbEstacionamiento.CodUbi);
            //ViewData["CodUbi"] = new SelectList(_context.TbConfUbigeos, "CodUbi", "CodUbi", tbEstacionamiento.CodUbi);
            return View(tbEstacionamiento);
        }

        // POST: EstacionamientoCms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodUbi,Estacionamiento")] TbEstacionamiento tbEstacionamiento)
        {
            if (id != tbEstacionamiento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _estacionamientoCmsService.modificarEstacionamiento(id, tbEstacionamiento);
                    //_context.Update(tbEstacionamiento);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbEstacionamientoExists(tbEstacionamiento.CodUbi))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { codUbi = tbEstacionamiento.CodUbi });
            }
            var listDistritos = await _ubigeoServicioscmsService.obtenerDistritosPorProvincia("1501");
            ViewData["Distritos"] = new SelectList(listDistritos, "CodUbi", "Dist", tbEstacionamiento.CodUbi);
            return View(tbEstacionamiento);
        }

        // GET: EstacionamientoCms/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0 || _context.TbEstacionamientos == null)
            {
                return NotFound();
            }

            var tbEstacionamiento = await _estacionamientoCmsService.verEstacionamientoPorDistrito(id);
            if (tbEstacionamiento == null)
            {
                return NotFound();
            }

            return View(tbEstacionamiento);
        }

        // POST: EstacionamientoCms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == 0 || _context.TbEstacionamientos == null)
            {
                return NotFound();
            }
            var tbEstacionamiento = await _estacionamientoCmsService.verEstacionamientoPorDistrito(id);
            if (tbEstacionamiento != null)
            {
                await _estacionamientoCmsService.eliminarEstacionamiento(id);
            }
            return RedirectToAction(nameof(Index), new { codUbi = tbEstacionamiento.CodUbi });

        }

        private bool TbEstacionamientoExists(string id)
        {
          return _context.TbEstacionamientos.Any(e => e.CodUbi == id);
        }
    }
}
