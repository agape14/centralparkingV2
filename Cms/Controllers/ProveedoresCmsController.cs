using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class ProveedoresCmsController : Controller
    {
        ProveedorCmsService _proveedorCmsService;
        public ProveedoresCmsController(ProveedorCmsService proveedorCmsService)
        {

            _proveedorCmsService = proveedorCmsService;

        }
        public async Task<IActionResult> Index()
        {
            //var proveedor = new ProveedorCmsService(new HttpClient());
            var lista = await _proveedorCmsService.ListarProveedores();
            if (lista.Count == 0)
            {
             
                TbFormProveedore objProveedor = new TbFormProveedore();
                lista.Add(objProveedor);
                return View(lista);
            }
            return View(lista);
        }

        // GET: IServicios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var proveedor = new ProveedorCmsService(new HttpClient());
            var lista = await _proveedorCmsService.ListarProveedores();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var prov = await _proveedorCmsService.obtenerProveedorDetalle(id);
            if (prov == null)
            {
                return NotFound();
            }

            return View(prov);
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
        public async Task<IActionResult> Create(TbFormProveedore tbFormProveedore)
        {
            //var proveedor = new ProveedorCmsService(new HttpClient());
            
            if (ModelState.IsValid)
            {
                await _proveedorCmsService.crearProveedorRegistro(tbFormProveedore);
                return RedirectToAction(nameof(Index));
            }
            return View(tbFormProveedore);
        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            //var proveedor = new ProveedorCmsService(new HttpClient());
            var lista = await _proveedorCmsService.ListarProveedores();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var prov = await _proveedorCmsService.obtenerProveedorDetalle(id);
            if (prov == null)
            {
                return NotFound();
            }
            return View(prov);
        }


        // POST: TbTraPuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TbFormProveedore tbFormProveedore)
        {
            //var proveedor = new ProveedorCmsService(new HttpClient());
            var lista = await _proveedorCmsService.ListarProveedores();


            if (id != tbFormProveedore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _proveedorCmsService.modificarProveedor(id, tbFormProveedore);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbFormProveedore);
        }

        // GET: TbTraPuesto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //var proveedor = new ProveedorCmsService(new HttpClient());
            var lista = await _proveedorCmsService.ListarProveedores();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var prov = await _proveedorCmsService.obtenerProveedorDetalle(id);
            if (prov == null)
            {
                return NotFound();
            }

            return View(prov);
        }

        // POST: TbTraPuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var proveedor = new ProveedorCmsService(new HttpClient());
            var lista = await _proveedorCmsService.ListarProveedores();

            if (lista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
            }
            var prov = await _proveedorCmsService.obtenerProveedorDetalle(id);
            if (prov != null)
            {
                await _proveedorCmsService.eliminarProveedor(id);
            }


            return RedirectToAction(nameof(Index));
        }

    }
}
