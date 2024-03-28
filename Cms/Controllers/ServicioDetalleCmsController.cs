using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class ServicioDetalleCmsController : Controller
    {
        ServicioDetalleCmsService _servicioDetalleCmsService;
        ConfBotonesCmsService _confBotonesCmsService;
        public ServicioDetalleCmsController(ServicioDetalleCmsService servicioDetalleCmsService, ConfBotonesCmsService confBotonesCmsService)
        {

            _servicioDetalleCmsService = servicioDetalleCmsService;
            _confBotonesCmsService= confBotonesCmsService;
        }
        public async Task<IActionResult> Index(int codigo)
        {
            int idUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0;
            if (idUsuario == 0)
            {
                return RedirectToAction("Index", "DashbordCms");
            }
            //var serviciodetalle = new ServicioDetalleCmsService(new HttpClient());
            var servicio = await _servicioDetalleCmsService.obtenerServicioDetalle(codigo);

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
            //var serviciodetalle = new ServicioDetalleCmsService(new HttpClient());

            if (id == 0)
            {
                return NotFound();
            }

            var tbIndServicioDet = await _servicioDetalleCmsService.obtenerServicioEspecifico(id);
            if (tbIndServicioDet == null)
            {
                return NotFound();
            }

            return View(tbIndServicioDet);
        }

        // GET: IServicios/Create
        public async Task<IActionResult> Create()
        {

            //var boton = new ConfBotonesCmsService(new HttpClient());
            var listBotones = await _confBotonesCmsService.listarBotones();

            listBotones.Insert(0, new TbConfBotone { Id = 0, BtnTitulo = "Seleccionar" });

            ViewData["IdBtn1"] = new SelectList(listBotones, "Id", "BtnTitulo");
            return View();
        }


        // POST: IServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbServDetalle tbServDetalle)
        {
            //var serviciodetalle = new ServicioDetalleCmsService(new HttpClient());
            if (tbServDetalle.IdBtnSolicitalo == 0)
            {
                tbServDetalle.IdBtnSolicitalo = null;
            }

            if (ModelState.IsValid)
            {
                await _servicioDetalleCmsService.crearServicioDetalle(tbServDetalle);
                return RedirectToAction(nameof(Index), "ServicioCabeceraCms");
            }
            return View(tbServDetalle);

        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            //var serviciodetalle = new ServicioDetalleCmsService(new HttpClient());
         

            if (id == 0)
            {
                return NotFound();
            }

            var servicio = await _servicioDetalleCmsService.obtenerServicioEspecifico(id);
            if (servicio == null)
            {
                return NotFound();
            }

            //var boton = new ConfBotonesCmsService(new HttpClient());
            var listBotones = await _confBotonesCmsService.listarBotones();
            listBotones.Insert(0, new TbConfBotone { Id = 0, BtnTitulo = "Seleccionar" });
            ViewData["IdBtn1"] = new SelectList(listBotones, "Id", "BtnTitulo");

            return View(servicio);
        }


        // POST: TbTraPuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TbServDetalle tbServDetalle)
        {
            //var serviciodetalle = new ServicioDetalleCmsService(new HttpClient());
            if (tbServDetalle.IdBtnSolicitalo == 0) {
                tbServDetalle.IdBtnSolicitalo = null;
            }

            if (id != tbServDetalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _servicioDetalleCmsService.modificarServicioDetalle(id, tbServDetalle);
                }
                catch (DbUpdateConcurrencyException ex)
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
            //var serviciodetalle = new ServicioDetalleCmsService(new HttpClient());
         
            if (id == 0)
            {
                return NotFound();
            }

            var servicio = await _servicioDetalleCmsService.obtenerServicioEspecifico(id);
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
            //var serviciodetalle = new ServicioDetalleCmsService(new HttpClient());
           
            if (id == 0)
            {
                return Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
            }
            var servicio = await _servicioDetalleCmsService.obtenerServicioEspecifico(id);
            if (servicio != null)
            {
                await _servicioDetalleCmsService.eliminarServicioDetalle(id);
            }


            return RedirectToAction(nameof(Index),"ServicioCabeceraCms");
        }
    }
}
