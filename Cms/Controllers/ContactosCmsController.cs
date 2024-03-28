using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class ContactosCmsController : Controller
    {
        ContactanoCmsService _contactanoCmsService;
        public ContactosCmsController(ContactanoCmsService contactanoCmsService)
        {

            _contactanoCmsService = contactanoCmsService;

        }
        public async Task<IActionResult> Index()
        {
            int idUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0;
            if (idUsuario == 0)
            {
                return RedirectToAction("Index", "DashbordCms");
            }
            //var contactos = new ContactanoCmsService(new HttpClient());
            var lista = await _contactanoCmsService.ListarContactos();
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
            //var contactos = new ContactanoCmsService(new HttpClient());
            var lista = _contactanoCmsService.ListarContactos();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var tbIndServiciocab = await _contactanoCmsService.obtenerContactoDetalle(id);
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
            //var contactos = new ContactanoCmsService(new HttpClient());
            if (ModelState.IsValid)
            {
                await _contactanoCmsService.crearContactoRegistro(tbFormContactano);
                return RedirectToAction(nameof(Index));
            }
            return View(tbFormContactano);
        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            //var contactos = new ContactanoCmsService(new HttpClient());
            var lista = _contactanoCmsService.ListarContactos();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var contacto = await _contactanoCmsService.obtenerContactoDetalle(id);
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
            //var contactos = new ContactanoCmsService(new HttpClient());


            if (id != tbFormContactano.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _contactanoCmsService.modificarContacto(id, tbFormContactano);
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
            //var contactos = new ContactanoCmsService(new HttpClient());

            var lista = await _contactanoCmsService.ListarContactos();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var contacto = await _contactanoCmsService.obtenerContactoDetalle(id);
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
            //var contactos = new ContactanoCmsService(new HttpClient());
            var lista = await _contactanoCmsService.ListarContactos();

            if (lista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
            }
            var contacto = await _contactanoCmsService.obtenerContactoDetalle(id);
            if (contacto != null)
            {
                await _contactanoCmsService.eliminarContacto(id);
            }


            return RedirectToAction(nameof(Index));
        }
    }
}