using ApiBD.Models;
using CentralParkingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class ProveedoresCmsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var proveedor = new ProveedorService(new HttpClient());
            var lista = await proveedor.ListarProveedores();
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
            var proveedor = new ProveedorService(new HttpClient());
            var lista = await proveedor.ListarProveedores();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var prov = await proveedor.obtenerProveedorDetalle(id);
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
            var proveedor = new ProveedorService(new HttpClient());
            
            if (ModelState.IsValid)
            {
                await proveedor.crearProveedorRegistro(tbFormProveedore);
                return RedirectToAction(nameof(Index));
            }
            return View(tbFormProveedore);
        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var proveedor = new ProveedorService(new HttpClient());
            var lista = await proveedor.ListarProveedores();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var prov = await proveedor.obtenerProveedorDetalle(id);
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
            var proveedor = new ProveedorService(new HttpClient());
            var lista = await proveedor.ListarProveedores();


            if (id != tbFormProveedore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await proveedor.modificarProveedor(id, tbFormProveedore);
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
            var proveedor = new ProveedorService(new HttpClient());
            var lista = await proveedor.ListarProveedores();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var prov = await proveedor.obtenerProveedorDetalle(id);
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
            var proveedor = new ProveedorService(new HttpClient());
            var lista = await proveedor.ListarProveedores();

            if (lista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
            }
            var prov = await proveedor.obtenerProveedorDetalle(id);
            if (prov != null)
            {
                await proveedor.eliminarProveedor(id);
            }


            return RedirectToAction(nameof(Index));
        }

    }
}
