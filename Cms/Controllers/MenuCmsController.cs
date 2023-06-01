using ApiBD.Models;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class MenuCmsController : Controller
    {
        ApiBD.Models.CentralParkingContext contexto = new CentralParkingContext();
        // GET: Menu
        public async Task<IActionResult> Index()
        {
            
            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();

            return View(menuLista);
        }

        
        // GET: Menu/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();

            if (id == 0 || menuLista == null)
            {
                return NotFound();
            }

            var tbConfMenu = await menu.obtenerMenuDetalle(id);

            if (tbConfMenu == null)
            {
                return NotFound();
            }

            return View(tbConfMenu);
        }

        
        // GET: Menu/Create
        public async Task<IActionResult> Create()
        {
            var menu = new MenuCmsService(new HttpClient());
            var tipoMenuLista = await menu.listarTipoMenu();

            ViewData["Idtipomenu"] = new SelectList(tipoMenuLista, "Id", "Opcion");

            var items = contexto.TbConfMenus.Where(item => item.Padre == 0 && item.Estado == 1).Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Nombre }).ToList();
            items.Insert(0, new SelectListItem { Text = "Seleccione un elemento", Value = "0" });
            ViewData["Padre"] = new SelectList(items, "Value", "Text");

            return View();
        }
        /*
        // POST: Menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Ruta,Idtipomenu,Acceso,Padre,Estado")] TbConfMenu tbConfMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbConfMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idtipomenu"] = new SelectList(_context.TbConfTipomenus, "Id", "Opcion", tbConfMenu.Idtipomenu);
            return View(tbConfMenu);
        }
         */
        // GET: Menu/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();
            var tipoMenuLista = await menu.listarTipoMenu();

            if (id == 0 || menuLista == null)
            {
                return NotFound();
            }

            var tbConfMenu = await menu.obtenerMenuDetalle(id);
            if (tbConfMenu == null)
            {
                return NotFound();
            }
            ViewData["Idtipomenu"] = new SelectList(tipoMenuLista, "Id", "Opcion", tbConfMenu.Idtipomenu);

            var items = contexto.TbConfMenus.Where(item => item.Padre == 0 && item.Estado == 1).Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Nombre }).ToList();
            items.Insert(0, new SelectListItem { Text = "Seleccione un elemento", Value = "0" });
            ViewData["Padre"] = new SelectList(items, "Value", "Text");

            return View(tbConfMenu);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Ruta,Idtipomenu,Acceso,Padre,Estado")] TbConfMenu tbConfMenu)
        {
            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();
            var tipoMenuLista = await menu.listarTipoMenu();

            if (id != tbConfMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  
                    await menu.modificarMenu(id,tbConfMenu);
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                        return NotFound();
                   
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idtipomenu"] = new SelectList(tipoMenuLista, "Id", "Id", tbConfMenu.Idtipomenu);
            return View(tbConfMenu);
        }
        
        // GET: Menu/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();

            if (id == 0 || menuLista == null)
            {
                return NotFound();
            }

            var tbConfMenu = await menu.obtenerMenuDetalle(id);
            if (tbConfMenu == null)
            {
                return NotFound();
            }

            return View(tbConfMenu);
        }
       
        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();

            if (menuLista == null)
            {
                return Problem("Entity set 'CentralparkingContext.TbConfMenus'  is null.");
            }
            var tbConfMenu = await menu.obtenerMenuDetalle(id);
            if (tbConfMenu != null)
            {
               await menu.eliminarMenu(id);
            }

           
            return RedirectToAction(nameof(Index));
        }
     
    }
}
