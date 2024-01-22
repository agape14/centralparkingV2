using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class HojaReclamacionCmsController : Controller
    {
        HojaReclamacioneCmsService _hojaReclamacioneCmsService;
        public HojaReclamacionCmsController(HojaReclamacioneCmsService hojaReclamacioneCmsService)
        {

            _hojaReclamacioneCmsService = hojaReclamacioneCmsService;

        }
        public async Task<IActionResult> Index()
        {
            //var servicio = new HojaReclamacioneCmsService(new HttpClient());
            var lista = await _hojaReclamacioneCmsService.ListarHojaReclamaciones();
            if (lista.Count == 0)
            {
                TbFormHojareclamacione objHojaReclamacione = new TbFormHojareclamacione();
                lista.Add(objHojaReclamacione);
                return View(lista);
            }
            return View(lista);
        }

        // GET: IServicios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var servicio = new HojaReclamacioneCmsService(new HttpClient());
            var lista = await _hojaReclamacioneCmsService.ListarHojaReclamaciones();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var hoja = await _hojaReclamacioneCmsService.obtenerHojaReclamacionesDetalle(id);
            if (hoja == null)
            {
                return NotFound();
            }

            return View(hoja);
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
        public async Task<IActionResult> Create(TbFormHojareclamacione tbFormHojareclamacione)
        {
            tbFormHojareclamacione.Fecha = DateTime.Now;
            tbFormHojareclamacione.Menordeedad = 0;

            //var servicio = new HojaReclamacioneCmsService(new HttpClient());

            if (ModelState.IsValid)
            {
                await _hojaReclamacioneCmsService.crearHojaReclamacioneRegistro(tbFormHojareclamacione);
                return RedirectToAction(nameof(Index));
            }
            return View(tbFormHojareclamacione);
        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            //var servicio = new HojaReclamacioneCmsService(new HttpClient());
            var lista = await _hojaReclamacioneCmsService.ListarHojaReclamaciones();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var hoja = await _hojaReclamacioneCmsService.obtenerHojaReclamacionesDetalle(id);
            if (hoja == null)
            {
                return NotFound();
            }
            return View(hoja);
        }


        // POST: TbTraPuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TbFormHojareclamacione tbFormHojareclamacione)
        {
            //var servicio = new HojaReclamacioneCmsService(new HttpClient());
            var lista = await _hojaReclamacioneCmsService.ListarHojaReclamaciones();


            if (id != tbFormHojareclamacione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _hojaReclamacioneCmsService.modificarHojaReclamacion(id, tbFormHojareclamacione);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbFormHojareclamacione);
        }

        // GET: TbTraPuesto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //var servicio = new HojaReclamacioneCmsService(new HttpClient());
            var lista = await _hojaReclamacioneCmsService.ListarHojaReclamaciones();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var hoja = await _hojaReclamacioneCmsService.obtenerHojaReclamacionesDetalle(id);
            if (hoja == null)
            {
                return NotFound();
            }

            return View(hoja);
        }

        // POST: TbTraPuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var servicio = new HojaReclamacioneCmsService(new HttpClient());
            var lista = await _hojaReclamacioneCmsService.ListarHojaReclamaciones();

            if (lista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
            }
            var hoja = await _hojaReclamacioneCmsService.obtenerHojaReclamacionesDetalle(id);
            if (hoja != null)
            {
                await _hojaReclamacioneCmsService.eliminarHojaReclamacion(id);
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
