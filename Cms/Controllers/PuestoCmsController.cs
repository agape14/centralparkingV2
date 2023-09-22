using ApiBD.Models;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class PuestoCmsController : Controller
    {
        // GET: TbTraPuesto
        public async Task<IActionResult> Index()
        {
            var puesto = new PuestoCmsService(new HttpClient());
            var puestoLista = await puesto.puestoListar();
            if(puestoLista.Count == 0)
            {
                TbTraPuesto objPuesto = new TbTraPuesto();
                puestoLista.Add(objPuesto);
                return View(puestoLista);
            }

            return puestoLista != null ?
                        View(puestoLista) :
                        Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
        }
        
        // GET: TbTraPuesto/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var puesto = new PuestoCmsService(new HttpClient());
            var puestoLista = await puesto.puestoListar();

            if (id == 0 || puestoLista == null)
            {
                return NotFound();
            }

            var tbTraPuesto = await puesto.obtenerPuestoDetalle(id);

            if (tbTraPuesto == null)
            {
                return NotFound();
            }

            return View(tbTraPuesto);
        }

        // GET: TbTraPuesto/Create
        public async Task<IActionResult> Create()
        {

            //Listando Menu
            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();
            var menuItems = menuLista.Where(m => m.Padre == 3).Select(m => new SelectListItem
            {
                Value = m.Ruta,
                Text = $"{m.Nombre} - {m.Ruta}"
            });

            ViewData["vMenu"] = new SelectList(
                Enumerable.Repeat(new SelectListItem { Value = "", Text = "Selecciona" }, 1)
                .Concat(menuItems),
                "Value",
                "Text"
            );

            return View();
        }
        
        // POST: TbTraPuesto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Subtitulo,Requisitos,Ruta,Ocupado")] TbTraPuesto tbTraPuesto)
        {
            var puesto = new PuestoCmsService(new HttpClient());
            if (ModelState.IsValid)
            {
                await puesto.crearPuesto(tbTraPuesto);  
                return RedirectToAction(nameof(Index));
            }

            return View(tbTraPuesto);
        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var puesto = new PuestoCmsService(new HttpClient());
            var puestoLista = await puesto.puestoListar();

            if (id == 0 || puestoLista == null)
            {
                return NotFound();
            }

            var tbTraPuesto = await puesto.obtenerPuestoDetalle(id);
            if (tbTraPuesto == null)
            {
                return NotFound();
            }

            //Listando Menu
            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();
            var menuItems = menuLista.Where(m => m.Padre == 3).Select(m => new SelectListItem
            {
                Value = m.Ruta,
                Text = $"{m.Nombre} - {m.Ruta}"
            });

            ViewData["vMenu"] = new SelectList(
                Enumerable.Repeat(new SelectListItem { Value = "", Text = "Selecciona" }, 1)
                .Concat(menuItems),
                "Value",
                "Text"
            );

            return View(tbTraPuesto);
        }

        
        // POST: TbTraPuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Subtitulo,Requisitos,Ruta,Ocupado")] TbTraPuesto tbTraPuesto)
        {
            var puesto = new PuestoCmsService(new HttpClient());
            
            if (id != tbTraPuesto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await puesto.modificarPuesto(id, tbTraPuesto);
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                        return NotFound();
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbTraPuesto);
        }

        // GET: TbTraPuesto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var puesto = new PuestoCmsService(new HttpClient());
            var puestoLista = await puesto.puestoListar();

            if (id == 0 || puestoLista == null)
            {
                return NotFound();
            }

            var tbTraPuesto = await puesto.obtenerPuestoDetalle(id);
            if (tbTraPuesto == null)
            {
                return NotFound();
            }

            return View(tbTraPuesto);
        }

        // POST: TbTraPuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puesto = new PuestoCmsService(new HttpClient());
            var puestoLista = await puesto.puestoListar();

            if (puestoLista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
            }
            var tbTraPuesto = await puesto.obtenerPuestoDetalle(id);
            if (tbTraPuesto != null)
            {
                await puesto.eliminarPuesto(id);
            }

           
            return RedirectToAction(nameof(Index));
        }

        
    }
}
