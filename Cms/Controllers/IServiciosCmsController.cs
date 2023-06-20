using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentralParkingSystem.Models;
using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;

namespace CentralParkingSystem.Controllers
{
    public class IServiciosCmsController : Controller
    {
     

        // GET: IServicios
        public async Task<IActionResult> Index()
        {
            var servicios = new ServiciosCabsService(new HttpClient());
            var lista = await servicios.ListarServiciosCabs();
            return lista != null ?
                        View(lista) :
                        Problem("Entity set 'CentralParkingContext.TbIndServiciocabs'  is null.");
        }

        // GET: IServicios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var serviciosCms = new IServicioCmsService(new HttpClient());
            var servicios = new ServiciosCabsService(new HttpClient());
            var lista = await servicios.ListarServiciosCabs();
            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var tbIndServiciocab = await serviciosCms.obtenerServicioDetalle(id);
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
            var serviciosCms = new IServicioCmsService(new HttpClient());
            if (ModelState.IsValid)
            {

                await serviciosCms.crearServicio(tbIndServiciocab);
                return RedirectToAction(nameof(Index));
            }
            return View(tbIndServiciocab);
        }

        // GET: IServicios/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var serviciosCms = new IServicioCmsService(new HttpClient());
            var servicios = new ServiciosCabsService(new HttpClient());
            var lista = await servicios.ListarServiciosCabs();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var tbIndServiciocab = await serviciosCms.obtenerServicioDetalle(id);
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
            var serviciosCms = new IServicioCmsService(new HttpClient());
        

            if (id != tbIndServiciocab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await serviciosCms.editarServicio(id, tbIndServiciocab);
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
            var serviciosCms = new IServicioCmsService(new HttpClient());
            var servicios = new ServiciosCabsService(new HttpClient());
            var lista = await servicios.ListarServiciosCabs();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var tbIndServiciocab = await serviciosCms.obtenerServicioDetalle(id);
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
            var serviciosCms = new IServicioCmsService(new HttpClient());
            var servicios = new ServiciosCabsService(new HttpClient());
            var lista = await servicios.ListarServiciosCabs();

            if (lista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbIndServiciocabs'  is null.");
            }
            var tbIndServiciocab = await serviciosCms.obtenerServicioDetalle(id);
            if (tbIndServiciocab != null)
            {
                await serviciosCms.eliminarServicio(id);
            }

            return RedirectToAction(nameof(Index));
        }

       
    }
}
