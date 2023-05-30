using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class IServiciosCmsController : Controller
    {
        // GET: IServicios
        public async Task<IActionResult> Index()
        {
            var servicio = new ServiciosCabsService(new HttpClient());
            var servicioLista = await servicio.ListarServiciosCabs();
            return servicioLista != null ?
                        View(servicioLista) :
                        Problem("Entity set 'CentralParkingContext.TbIndServiciocabs'  is null.");
        }

        // GET: IServicios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var servicio = new ServiciosCabsService(new HttpClient());
            var servicioLista = await servicio.ListarServiciosCabs();
            var servicioCms = new IServicioCmsService(new HttpClient());

            if (id == 0 || servicioLista == null)
            {
                return NotFound();
            }

            var tbIndServiciocab = await servicioCms.obtenerServicioDetalle(id);
            if (tbIndServiciocab == null)
            {
                return NotFound();
            }

            return View(tbIndServiciocab);
        }

        // GET: IServicios/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: IServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TituloGrande,TituloPeque,Descripcion,ImagenGrande,ImagenPeque,Ruta")] TbIndServiciocab tbIndServiciocab)
        {
            var servicioCms = new IServicioCmsService(new HttpClient());
            if (ModelState.IsValid)
            {
                await servicioCms.crearServicio(tbIndServiciocab);
                return RedirectToAction(nameof(Index));
            }
            return View(tbIndServiciocab);
        }
        
        // GET: IServicios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var servicio = new ServiciosCabsService(new HttpClient());
            var servicioLista = await servicio.ListarServiciosCabs();
            var servicioCms = new IServicioCmsService(new HttpClient());

            if (id == 0 || servicioLista == null)
            {
                return NotFound();
            }

            var tbIndServiciocab = await servicioCms.obtenerServicioDetalle(id);
            if (tbIndServiciocab == null)
            {
                return NotFound();
            }
            return View(tbIndServiciocab);
        }

        // POST: IServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TituloGrande,TituloPeque,Descripcion,ImagenGrande,ImagenPeque,Ruta")] TbIndServiciocab tbIndServiciocab)
        {
            var servicioCms = new IServicioCmsService(new HttpClient());
            if (id != tbIndServiciocab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await servicioCms.editarServicio(id, tbIndServiciocab);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        return NotFound();
                  
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbIndServiciocab);
        }
        
        // GET: IServicios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var servicio = new ServiciosCabsService(new HttpClient());
            var servicioLista = await servicio.ListarServiciosCabs();
            var servicioCms = new IServicioCmsService(new HttpClient());

            if (id == 0 || servicioLista == null)
            {
                return NotFound();
            }

            var tbIndServiciocab = await servicioCms.obtenerServicioDetalle(id);
            if (tbIndServiciocab == null)
            {
                return NotFound();
            }

            return View(tbIndServiciocab);
        }

        // POST: IServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicio = new ServiciosCabsService(new HttpClient());
            var servicioLista = await servicio.ListarServiciosCabs();
            var servicioCms = new IServicioCmsService(new HttpClient());

            if (servicioLista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbIndServiciocabs'  is null.");
            }
            var tbIndServiciocab = await servicioCms.obtenerServicioDetalle(id);
            if (tbIndServiciocab != null)
            {
                await servicioCms.eliminarServicio(id);
            }

            
            return RedirectToAction(nameof(Index));
        }
        /*
        private bool TbIndServiciocabExists(int id)
        {
            return (_context.TbIndServiciocabs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        */
    }
}
