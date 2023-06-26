using ApiBD.Models;
using CentralParkingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class ParkingCardVipCmsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var servicio = new ParkingCardService(new HttpClient());
            var lista = await servicio.ListarParkingCard();
            if (lista.Count == 0)
            {
                return View();
            }
            return View(lista);
        }

        // GET: IServicios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var servicio = new ParkingCardService(new HttpClient());
            var lista = await servicio.ListarParkingCard();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var card = await servicio.obtenerParkingCardDetalle(id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
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
        public async Task<IActionResult> Create(TbFormParkingcard tbFormParkingcard)
        {
            var servicio = new ParkingCardService(new HttpClient());

            if (ModelState.IsValid)
            {
                await servicio.crearParkingCardRegistro(tbFormParkingcard);
                return RedirectToAction(nameof(Index));
            }
            return View(tbFormParkingcard);
        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var servicio = new ParkingCardService(new HttpClient());
            var lista = await servicio.ListarParkingCard();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var card = await servicio.obtenerParkingCardDetalle(id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);
        }


        // POST: TbTraPuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TbFormParkingcard tbFormParkingcard)
        {
            var servicio = new ParkingCardService(new HttpClient());
            var lista = await servicio.ListarParkingCard();


            if (id != tbFormParkingcard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await servicio.modificarParkingCard(id, tbFormParkingcard);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbFormParkingcard);
        }

        // GET: TbTraPuesto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var servicio = new ParkingCardService(new HttpClient());
            var lista = await servicio.ListarParkingCard();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var card = await servicio.obtenerParkingCardDetalle(id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: TbTraPuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicio = new ParkingCardService(new HttpClient());
            var lista = await servicio.ListarParkingCard();

            if (lista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
            }
            var prov = await servicio.obtenerParkingCardDetalle(id);
            if (prov != null)
            {
                await servicio.eliminarParkingCard(id);
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
