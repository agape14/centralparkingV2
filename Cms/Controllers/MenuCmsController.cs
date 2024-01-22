using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class MenuCmsController : Controller
    {

        MenuCmsService _menuCmsService;
        public MenuCmsController(MenuCmsService menuCmsService)
        {

            _menuCmsService = menuCmsService;

        }
        public async Task<IActionResult> Index(string tipoProyecto)
        {
            
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();
            // Filtrar menús según el tipo de proyecto
            if (!string.IsNullOrEmpty(tipoProyecto))
            {
                menuLista = menuLista.Where(menu => menu.TipoProyecto == tipoProyecto).ToList();
            }
            if (menuLista.Count == 0)
            {
                TbConfMenu objMenu = new TbConfMenu();
                menuLista.Add(objMenu);
                return View(menuLista);
            }
            return View(menuLista);
        }

        
        // GET: Menu/Details/5 ok
        public async Task<IActionResult> Details(int id)
        {
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();

            if (id == 0 || menuLista == null)
            {
                return NotFound();
            }

            var tbConfMenu = await _menuCmsService.obtenerMenuDetalle(id);

            if (tbConfMenu == null)
            {
                return NotFound();
            }

            return View(tbConfMenu);
        }

        
        // GET: Menu/Create ok
        public async Task<IActionResult> Create()
        {
            //var menuCentralParking = new MenuCmsService(new HttpClient());
            //var menu = new MenuCmsService(new HttpClient());
            var tipoMenuLista = await _menuCmsService.listarTipoMenu();

            ViewData["Idtipomenu"] = new SelectList(tipoMenuLista, "Id", "Opcion");

            var items = await _menuCmsService.ListarMenusv2();
            var selectListItems = items.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Nombre
            }).ToList();

            selectListItems.Insert(0, new SelectListItem { Text = "Seleccione un elemento", Value = "0" });
            ViewData["Padre"] = new SelectList(selectListItems, "Value", "Text");

            return View();
        }
        
        // POST: Menu/Create ok
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Ruta,Idtipomenu,Acceso,Padre,Estado,TipoProyecto,Icono")] TbConfMenu tbConfMenu)
        {
            //var menu = new MenuCmsService(new HttpClient());
            var tipoMenuLista = await _menuCmsService.listarTipoMenu();

            if (ModelState.IsValid)
            {

                await _menuCmsService.crearMenu(tbConfMenu);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idtipomenu"] = new SelectList(tipoMenuLista, "Id", "Opcion", tbConfMenu.Idtipomenu);
            return RedirectToAction(nameof(Index), new { tipoProyecto = tbConfMenu.TipoProyecto });
            //return View(tbConfMenu);
        }
      
        // GET: Menu/Edit/5 ok
        public async Task<IActionResult> Edit(int id)
        {
            //var menuCentralParking = new MenuCmsService(new HttpClient());
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();
            var tipoMenuLista = await _menuCmsService.listarTipoMenu();

            if (id == 0 || menuLista == null)
            {
                return NotFound();
            }

            var tbConfMenu = await _menuCmsService.obtenerMenuDetalle(id);
            if (tbConfMenu == null)
            {
                return NotFound();
            }
            ViewData["Idtipomenu"] = new SelectList(tipoMenuLista, "Id", "Opcion", tbConfMenu.Idtipomenu);

            var items = await _menuCmsService.ListarMenusv2();
            var selectListItems = items.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Nombre
            }).ToList();

            selectListItems.Insert(0, new SelectListItem { Text = "Seleccione un elemento", Value = "0" });
            ViewData["Padre"] = new SelectList(selectListItems, "Value", "Text");

            return View(tbConfMenu);
        }

        // POST: Menu/Edit/5 ok
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Ruta,Idtipomenu,Acceso,Padre,Estado,TipoProyecto,Icono")] TbConfMenu tbConfMenu)
        {
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();
            var tipoMenuLista = await _menuCmsService.listarTipoMenu();

            if (id != tbConfMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  
                    await _menuCmsService.modificarMenu(id,tbConfMenu);
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                        return NotFound();
                   
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idtipomenu"] = new SelectList(tipoMenuLista, "Id", "Id", tbConfMenu.Idtipomenu);
            //return View(tbConfMenu);
            return RedirectToAction(nameof(Index), new { tipoProyecto = tbConfMenu.TipoProyecto });
        }
         
        // GET: Menu/Delete/5 ok
        public async Task<IActionResult> Delete(int id)
        {
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();

            if (id == 0 || menuLista == null)
            {
                return NotFound();
            }

            var tbConfMenu = await _menuCmsService.obtenerMenuDetalle(id);
            if (tbConfMenu == null)
            {
                return NotFound();
            }

            return View(tbConfMenu);
        }
       
        // POST: Menu/Delete/5 ok
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();

            if (menuLista == null)
            {
                return Problem("Entity set 'CentralparkingContext.TbConfMenus'  is null.");
            }
            var tbConfMenu = await _menuCmsService.obtenerMenuDetalle(id);
            if (tbConfMenu != null)
            {
               await _menuCmsService.eliminarMenu(id);
            }

           
            return RedirectToAction(nameof(Index));
        }
          

    }
}
