using ApiBD.Models;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class BotonCmsController : Controller
    {
        // GET: Boton
        public async Task<IActionResult> Index()
        {
            var boton = new ConfBotonesCmsService(new HttpClient());
            var botonLista = await boton.listarBotones();

            if (botonLista.Count == 0 )
            {
                TbConfBotone objBotone = new TbConfBotone();
                botonLista.Add(objBotone);
                return View(botonLista);
            }

            return botonLista != null ?
                        View(botonLista) :
                        Problem("Entity set 'CentralparkingContext.TbConfBotones'  is null.");
        }
       
        // GET: Boton/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var boton = new ConfBotonesCmsService(new HttpClient());
            var botonLista = await boton.listarBotones();
            if (id == 0 || botonLista == null)
            {
                return NotFound();
            }

            var tbConfBotone = await boton.obtenerBotonDetalle(id);
            if (tbConfBotone == null)
            {
                return NotFound();
            }

            return View(tbConfBotone);
        }

        // GET: Boton/Create
        public IActionResult Create()
        {
            return View();
        }

        
       // POST: Boton/Create
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Create([Bind("Id,MenuId,PaginadetId,BtnTitulo,BtnRuta,BtnClase,Icono,Orden")] TbConfBotone tbConfBotone)
       {    
           var boton = new ConfBotonesCmsService(new HttpClient());
           if (ModelState.IsValid)
           {
               await boton.crearBoton(tbConfBotone);
               return RedirectToAction(nameof(Index));
           }
           return View(tbConfBotone);
       }
        


       // GET: Boton/Edit/5
       public async Task<IActionResult> Edit(int id)
       {
            var boton = new ConfBotonesCmsService(new HttpClient());
            var botonLista = await boton.listarBotones();
           if (id == 0 || botonLista == null)
           {
               return NotFound();
           }

           var tbConfBotone = await boton.obtenerBotonDetalle(id);
           if (tbConfBotone == null)
           {
               return NotFound();
           }
           return View(tbConfBotone);
       }
        
       // POST: Boton/Edit/5
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(int id, [Bind("Id,MenuId,PaginadetId,BtnTitulo,BtnRuta,BtnClase,Icono,Orden")] TbConfBotone tbConfBotone)
       {
            var boton = new ConfBotonesCmsService(new HttpClient());
           if (id != tbConfBotone.Id)
           {
               return NotFound();
           }

           if (ModelState.IsValid)
           {
               try
               {
                    await boton.modificarBoton(id,tbConfBotone);
               }
               catch (DbUpdateConcurrencyException)
               {
                  
                       return NotFound();
                 
               }
               return RedirectToAction(nameof(Index));
           }
           return View(tbConfBotone);
       }
        
       // GET: Boton/Delete/5
       public async Task<IActionResult> Delete(int id)
       {
            var boton = new ConfBotonesCmsService(new HttpClient());
            var botonLista = await boton.listarBotones();
           if (id == 0 || botonLista == null)
           {
               return NotFound();
           }

           var tbConfBotone = await boton.obtenerBotonDetalle(id);
              
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
            var boton = new ConfBotonesCmsService(new HttpClient());
            var botonLista = await boton.listarBotones();

            if (botonLista == null)
           {
               return Problem("Entity set 'CentralparkingContext.TbConfBotones'  is null.");
           }
           var tbConfBotone = await boton.obtenerBotonDetalle(id);
           if (tbConfBotone != null)
           {
               await boton.eliminarBoton(id);
           }

         
           return RedirectToAction(nameof(Index));
       }
        

    }
}
