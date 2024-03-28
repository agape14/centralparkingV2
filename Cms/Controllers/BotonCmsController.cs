using ApiBD.Models;
using CentralParkingSystem.DTOs;
using Cms.Service;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class BotonCmsController : Controller
    {
        private readonly ConfBotonesCmsService _confBotonesCmsService;
        private readonly MenuCmsService _menuCmsService;

        public BotonCmsController(ConfBotonesCmsService confBotonesCmsService, MenuCmsService menuCmsService)
        {
            _confBotonesCmsService = confBotonesCmsService;
            _menuCmsService = menuCmsService;
        }
        // GET: Boton
        public async Task<IActionResult> Index(uint codigo)
        {
            int idUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0;
            if (idUsuario == 0)
            {
                return RedirectToAction("Index", "DashbordCms");
            }
            //var boton = new ConfBotonesCmsService(new HttpClient());
            var botonLista = await _confBotonesCmsService.listarBotonesBanner(codigo);

            if (botonLista.Count == 0 )
            {
                TbConfBotone objBotone = new TbConfBotone();
                botonLista.Add(objBotone);
                return View(botonLista);
            }
            ViewData["SlideCodigo"] = codigo;
            return botonLista != null ?
                        View(botonLista) :
                        Problem("Entity set 'CentralparkingContext.TbConfBotones'  is null.");
        }
       
        // GET: Boton/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var boton = new ConfBotonesCmsService(new HttpClient());
            if (id == 0)
            {
                return NotFound();
            }

            var tbConfBotone = await _confBotonesCmsService.obtenerBotonDetalle(id);
            if (tbConfBotone == null)
            {
                return NotFound();
            }

            return View(tbConfBotone);
        }

        // GET: Boton/Create
        public async Task<IActionResult> Create(uint codigo)
        {
            //Guardando ID Codigo Slide Padre
            ViewData["SlideCodigo"] = codigo;
            //Listando Menu
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();
            var menuItems = menuLista.Where(m => m.Idtipomenu == 1).Select(m => new SelectListItem
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

        
       // POST: Boton/Create
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Create([Bind("Id,MenuId,PaginadetId,BtnTitulo,BtnRuta,BtnClase,Icono,Orden")] TbConfBotone tbConfBotone)
       {    
           //var boton = new ConfBotonesCmsService(new HttpClient());
           if (ModelState.IsValid)
           {
               await _confBotonesCmsService.crearBoton(tbConfBotone);
               return RedirectToAction(nameof(Index), new { codigo = tbConfBotone.MenuId });
            }
            return View(tbConfBotone);
       }
        


       // GET: Boton/Edit/5
       public async Task<IActionResult> Edit(int id, uint codigo)
       {
            //var boton = new ConfBotonesCmsService(new HttpClient());
           if (id == 0)
           {
               return NotFound();
           }

           var tbConfBotone = await _confBotonesCmsService.obtenerBotonDetalle(id);
           if (tbConfBotone == null)
           {
               return NotFound();
           }
            //Guardando ID Codigo Slide Padre
            ViewData["SlideCodigo"] = codigo;
            //Listando Menu
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();
            var menuItems = menuLista.Where(m => m.Idtipomenu == 1).Select(m => new SelectListItem
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

            return View(tbConfBotone);
       }
        
       // POST: Boton/Edit/5
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(int id, [Bind("Id,MenuId,PaginadetId,BtnTitulo,BtnRuta,BtnClase,Icono,Orden")] TbConfBotone tbConfBotone)
       {
            //var boton = new ConfBotonesCmsService(new HttpClient());
           if (id != tbConfBotone.Id)
           {
               return NotFound();
           }

           if (ModelState.IsValid)
           {
               try
               {
                    await _confBotonesCmsService.modificarBoton(id,tbConfBotone);
               }
               catch (DbUpdateConcurrencyException)
               {
                  
                       return NotFound();
                 
               }
               return RedirectToAction(nameof(Index), new { codigo = tbConfBotone.MenuId });
            }
           return View(tbConfBotone);
       }
        
       // GET: Boton/Delete/5
       public async Task<IActionResult> Delete(int id, uint codigo)
        {
            //Guardando ID Codigo Slide Padre
            ViewData["SlideCodigo"] = codigo;
            //var boton = new ConfBotonesCmsService(new HttpClient());
           if (id == 0)
           {
               return NotFound();
           }

           var tbConfBotone = await _confBotonesCmsService.obtenerBotonDetalle(id);
              
           if (tbConfBotone == null)
           {
               return NotFound();
           }

           return View(tbConfBotone);
       }

       // POST: Boton/Delete/5
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> DeleteConfirmed(int id)
       {
           //var boton = new ConfBotonesCmsService(new HttpClient());
           var tbConfBotone = await _confBotonesCmsService.obtenerBotonDetalle(id);
           if (tbConfBotone != null)
           {
               await _confBotonesCmsService.eliminarBoton(id);
           }


            return RedirectToAction(nameof(Index), new { codigo = tbConfBotone.MenuId });
        }
        

    }
}
