using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class ServicioDetalleCmsController : Controller
    {
        public async Task<IActionResult> Index(int codigo)
        {
            var serviciodetalle = new ServicioDetalleService(new HttpClient());
            var servicio = await serviciodetalle.obtenerServicioDetalle(codigo);

            if (servicio.Count == 0)
            {
                TbServDetalle objServicioDetalle = new TbServDetalle();
                servicio.Add(objServicioDetalle);
                return View(servicio);
            }

            return View(servicio);
        }

        // GET: IServicios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var serviciodetalle = new ServicioDetalleService(new HttpClient());

            if (id == 0)
            {
                return NotFound();
            }

            var tbIndServicioDet = await serviciodetalle.obtenerServicioEspecifico(id);
            if (tbIndServicioDet == null)
            {
                return NotFound();
            }

            return View(tbIndServicioDet);
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
        public async Task<IActionResult> Create(TbServDetalle tbServDetalle)
        {
            var serviciodetalle = new ServicioDetalleService(new HttpClient());
            if (ModelState.IsValid)
            {
                await serviciodetalle.crearServicioDetalle(tbServDetalle);
                return RedirectToAction(nameof(Index), "ServicioCabeceraCms");
            }
            return View(tbServDetalle);

        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var serviciodetalle = new ServicioDetalleService(new HttpClient());
           

            if (id == 0)
            {
                return NotFound();
            }

            var servicio = await serviciodetalle.obtenerServicioEspecifico(id);
            if (servicio == null)
            {
                return NotFound();
            }
            return View(servicio);
        }


        // POST: TbTraPuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TbServDetalle tbServDetalle)
        {
            var serviciodetalle = new ServicioDetalleService(new HttpClient());
          

            if (id != tbServDetalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await serviciodetalle.modificarServicioDetalle(id, tbServDetalle);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }
                return RedirectToAction(nameof(Index), "ServicioCabeceraCms");
            }
            return View(tbServDetalle);
        }

        // GET: TbTraPuesto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var serviciodetalle = new ServicioDetalleService(new HttpClient());
         
            if (id == 0)
            {
                return NotFound();
            }

            var servicio = await serviciodetalle.obtenerServicioEspecifico(id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // POST: TbTraPuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviciodetalle = new ServicioDetalleService(new HttpClient());
           
            if (id == 0)
            {
                return Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
            }
            var servicio = await serviciodetalle.obtenerServicioEspecifico(id);
            if (servicio != null)
            {
                await serviciodetalle.eliminarServicioDetalle(id);
            }


            return RedirectToAction(nameof(Index),"ServicioCabeceraCms");
        }
    }
}
