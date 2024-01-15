using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class CotizanosCmsController : Controller
    {
        public async Task<IActionResult> Index(int codigo)
        {
            ViewData["TipoServicio"] = codigo;
            var contactos = new CotizanoCmsService(new HttpClient());
            var lista = await contactos.ListarCotizanos(codigo);
            if (lista.Count == 0)
            {
                TbFormCotizano objContactano = new TbFormCotizano();
                lista.Add(objContactano);
                return View(lista);
            }
            return View(lista);
        }

        // GET: IServicios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var contactos = new CotizanoCmsService(new HttpClient());
            var tbIndServiciocab = await contactos.obtenerCotizanoDetalle(id);
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
        public async Task<IActionResult> Create(TbFormCotizano tbFormContactano)
        {
            var contactos = new CotizanoCmsService(new HttpClient());
            if (ModelState.IsValid)
            {
                await contactos.crearCotizanoRegistro(tbFormContactano);
                return RedirectToAction(nameof(Index));
            }
            return View(tbFormContactano);
        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var contactos = new CotizanosService(new HttpClient());
            var contacto = await contactos.obtenerCotizanoDetalle(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }


        // POST: TbTraPuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TbFormCotizano tbFormContactano)
        {
            var contactos = new CotizanoCmsService(new HttpClient());


            if (id != tbFormContactano.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await contactos.modificarCotizano(id, tbFormContactano);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbFormContactano);
        }

        // GET: TbTraPuesto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var contactos = new CotizanoCmsService(new HttpClient());
            var contacto = await contactos.obtenerCotizanoDetalle(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        // POST: TbTraPuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactos = new CotizanoCmsService(new HttpClient());
            var contacto = await contactos.obtenerCotizanoDetalle(id);
            if (contacto != null)
            {
                await contactos.eliminarCotizano(id);
            }


            return RedirectToAction(nameof(Index));
        }
    }
}