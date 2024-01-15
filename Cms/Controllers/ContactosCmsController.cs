using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class ContactosCmsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var contactos = new ContactanoCmsService(new HttpClient());
            var lista = await contactos.ListarContactos();
            if (lista.Count == 0)
            {
                TbFormContactano objContactano = new TbFormContactano();
                lista.Add(objContactano);
                return View(lista);
            }
            return View(lista);
        }

        // GET: IServicios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var contactos = new ContactanoCmsService(new HttpClient());
            var lista = contactos.ListarContactos();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var tbIndServiciocab = await contactos.obtenerContactoDetalle(id);
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
        public async Task<IActionResult> Create(TbFormContactano tbFormContactano)
        {
            var contactos = new ContactanoCmsService(new HttpClient());
            if (ModelState.IsValid)
            {
                await contactos.crearContactoRegistro(tbFormContactano);
                return RedirectToAction(nameof(Index));
            }
            return View(tbFormContactano);
        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var contactos = new ContactanoCmsService(new HttpClient());
            var lista = contactos.ListarContactos();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var contacto = await contactos.obtenerContactoDetalle(id);
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
        public async Task<IActionResult> Edit(int id, TbFormContactano tbFormContactano)
        {
            var contactos = new ContactanoCmsService(new HttpClient());


            if (id != tbFormContactano.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await contactos.modificarContacto(id, tbFormContactano);
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
            var contactos = new ContactanoCmsService(new HttpClient());

            var lista = await contactos.ListarContactos();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var contacto = await contactos.obtenerContactoDetalle(id);
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
            var contactos = new ContactanoCmsService(new HttpClient());
            var lista = await contactos.ListarContactos();

            if (lista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
            }
            var contacto = await contactos.obtenerContactoDetalle(id);
            if (contacto != null)
            {
                await contactos.eliminarContacto(id);
            }


            return RedirectToAction(nameof(Index));
        }
    }
}