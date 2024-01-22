using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class ModaleDetCmsController : Controller
    {
        ModaleDetalleCmsService _modaleDetalleCmsService;
        public ModaleDetCmsController(ModaleDetalleCmsService modaleDetalleCmsService)
        {

            _modaleDetalleCmsService = modaleDetalleCmsService;

        }
        public async Task<IActionResult> Index(int codigo)
        {
            //var servicio = new ModaleDetalleCmsService(new HttpClient());
            var lista = await _modaleDetalleCmsService.listarModalDetalle(codigo);
            if (lista.Count == 0)
            {
                TbConfModaldet objModaleDet = new TbConfModaldet();
                lista.Add(objModaleDet);
                return View(lista);
            }
            else {
                ViewData["Codigo"] = lista[0].ModalcabId;
            }
            ViewData["ModaleCabId"] = codigo;
            return View(lista);
        }

        // GET: IServicios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var servicio = new ModaleDetalleCmsService(new HttpClient());
            var lista = await _modaleDetalleCmsService.listarModalDetalle(id);

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var modal = await _modaleDetalleCmsService.obtenerModalDetalle(id);
            if (modal == null)
            {
                return NotFound();
            }

            return View(modal);
        }

        // GET: IServicios/Create
        public IActionResult Create(int codigo, int ModaleCabId)
        {
            ViewData["ModaleCabId"] = codigo;
            ViewData["Codigo"] = ModaleCabId;
            return View();
        }


        // POST: IServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int codigo, TbConfModaldet tbConfModaldet)
        {
            //var servicio = new ModaleDetalleCmsService(new HttpClient());

            if (ModelState.IsValid)
            {
                await _modaleDetalleCmsService.crearModalDetRegistro(tbConfModaldet);
                return RedirectToAction(nameof(Index), new { codigo = codigo });


            }
            return View(tbConfModaldet);
        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id, int codigo)
        {
            ViewData["ModaleCabId"] = codigo;
            //var servicio = new ModaleDetalleCmsService(new HttpClient());
            var lista = await _modaleDetalleCmsService.listarModalDetalle(id);

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var modal = await _modaleDetalleCmsService.obtenerModalDetalle(id);
            if (modal == null)
            {
                return NotFound();
            }
            return View(modal);
        }


        // POST: TbTraPuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int codigo, TbConfModaldet tbConfModaldet)
        {
            //var servicio = new ModaleDetalleCmsService(new HttpClient());
           


            if (id != tbConfModaldet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _modaleDetalleCmsService.modificarModalDet(id, tbConfModaldet);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }
                return RedirectToAction(nameof(Index), new { codigo = codigo });


            }
            return View(tbConfModaldet);
        }

        // GET: TbTraPuesto/Delete/5
        public async Task<IActionResult> Delete(int id, int codigo)
        {
            ViewData["ModaleCabId"] = codigo;
            //var servicio = new ModaleDetalleCmsService(new HttpClient());
         

            if (id == 0)
            {
                return NotFound();
            }

            var modal = await _modaleDetalleCmsService.obtenerModalDetalle(id);
            if (modal == null)
            {
                return NotFound();
            }

            return View(modal);
        }

        // POST: TbTraPuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int codigo)
        {
            //var servicio = new ModaleDetalleCmsService(new HttpClient());
           
            var modal = await _modaleDetalleCmsService.obtenerModalDetalle(id);
            if (modal != null)
            {
                await _modaleDetalleCmsService.eliminarModalDet(id);
            }


            return RedirectToAction(nameof(Index), new { codigo = codigo });


        }
    }
}
