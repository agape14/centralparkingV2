using ApiBD.Models;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class PiePaginaCmsController : Controller
    {
        PiePaginaCmsService _piePaginaCmsService;
        public PiePaginaCmsController(PiePaginaCmsService piePaginaCmsService)
        {

            _piePaginaCmsService = piePaginaCmsService;

        }
        // GET: PiePagina
        public async Task<IActionResult> Index()
        {
            //var piePagina = new PiePaginaCmsService(new HttpClient());
            var piePaginaListaCabs = await _piePaginaCmsService.listarPiePaginasCab();

            if(piePaginaListaCabs.Count == 0)
            {
                TbConfPiepaginacab objPiePagina = new TbConfPiepaginacab();
                piePaginaListaCabs.Add(objPiePagina);
                return View(piePaginaListaCabs);
            }

            return piePaginaListaCabs != null ?
                        View(piePaginaListaCabs) :
                        Problem("Entity set 'CentralparkingContext.TbConfPiepaginacabs'  is null.");
        }

        // GET: PiePagina/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var piePagina = new PiePaginaCmsService(new HttpClient());
            var piePaginaListaCabs = await _piePaginaCmsService.listarPiePaginasCab();

            if (id == 0 || piePaginaListaCabs == null)
            {
                return NotFound();
            }

            var tbConfPiepaginacab = await _piePaginaCmsService.obtenerPiePaginaCabsDetalle(id);
            if (tbConfPiepaginacab == null)
            {
                return NotFound();
            }

            return View(tbConfPiepaginacab);
        }

        // GET: PiePagina/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PiePagina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Imagen,Orden,Estado")] TbConfPiepaginacab tbConfPiepaginacab)
        {
            //var piePagina = new PiePaginaCmsService(new HttpClient());

            if (ModelState.IsValid)
            {

                await _piePaginaCmsService.crearPiePaginaCab(tbConfPiepaginacab); 
                return RedirectToAction(nameof(Index));
            }
            return View(tbConfPiepaginacab);
        }
        
        // GET: PiePagina/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //var piePagina = new PiePaginaCmsService(new HttpClient());
            var piePaginaListaCabs = await _piePaginaCmsService.listarPiePaginasCab();

            if (id == 0 || piePaginaListaCabs == null)
            {
                return NotFound();
            }

            var tbConfPiepaginacab = await _piePaginaCmsService.obtenerPiePaginaCabsDetalle(id);
            if (tbConfPiepaginacab == null)
            {
                return NotFound();
            }
            return View(tbConfPiepaginacab);
        }

        // POST: PiePagina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Imagen,Orden,Estado")] TbConfPiepaginacab tbConfPiepaginacab)
        {
            //var piePagina = new PiePaginaCmsService(new HttpClient());

            if (id != tbConfPiepaginacab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _piePaginaCmsService.modificarPiePaginaCab(id, tbConfPiepaginacab);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        return NotFound();
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbConfPiepaginacab);
        }

        // GET: PiePagina/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //var piePagina = new PiePaginaCmsService(new HttpClient());
            var piePaginaListaCabs = await _piePaginaCmsService.listarPiePaginasCab();

            if (id == 0 || piePaginaListaCabs == null)
            {
                return NotFound();
            }

            var tbConfPiepaginacab = await _piePaginaCmsService.obtenerPiePaginaCabsDetalle(id);

            if (tbConfPiepaginacab == null)
            {
                return NotFound();
            }

            return View(tbConfPiepaginacab);
        }

        // POST: PiePagina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var piePagina = new PiePaginaCmsService(new HttpClient());
            var piePaginaListaCabs = await _piePaginaCmsService.listarPiePaginasCab();

            if (piePaginaListaCabs == null)
            {
                return Problem("Entity set 'CentralparkingContext.TbConfPiepaginacabs'  is null.");
            }
            var tbConfPiepaginacab = await _piePaginaCmsService.obtenerPiePaginaCabsDetalle(id);

            if (tbConfPiepaginacab != null)
            {
                await _piePaginaCmsService.eliminarPiePaginaCab(id);
            }

            
            return RedirectToAction(nameof(Index));
        }
        
    }
}
