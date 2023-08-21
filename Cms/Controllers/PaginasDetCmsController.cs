using ApiBD.Models;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class PaginasDetCmsController : Controller
    {
        // GET: PaginasDet
        public async Task<IActionResult> Index()
        {
            var paginaDet = new PaginasDetCmsService(new HttpClient());
            var paginaDetLista = await paginaDet.paginasDetListar();

            if(paginaDetLista.Count == 0)
            {
                TbConfPaginasdet objPaginasdet = new TbConfPaginasdet();
                paginaDetLista.Add(objPaginasdet);
                return View(paginaDetLista);
            }

            return paginaDetLista != null ?
                        View(paginaDetLista) :
                        Problem("Entity set 'CentralParkingContext.TbConfPaginasdets'  is null.");
        }
        
        // GET: PaginasDet/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var paginaDet = new PaginasDetCmsService(new HttpClient());
            var paginaDetLista = await paginaDet.paginasDetListar();

            if (id == 0 || paginaDetLista == null)
            {
                return NotFound();
            }

            var tbConfPaginasdet = await paginaDet.obtenerPaginaDetDetalle(id);
            if (tbConfPaginasdet == null)
            {
                return NotFound();
            }

            return View(tbConfPaginasdet);
        }

        // GET: PaginasDet/Create
        public IActionResult Create()
        {
            return View();
        }
        
       // POST: PaginasDet/Create
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Create([Bind("Id,PaginaId,Titulo,Detalle,Imagen")] TbConfPaginasdet tbConfPaginasdet)
       {
           var paginaDet = new PaginasDetCmsService(new HttpClient());

           if (ModelState.IsValid)
           {
               await paginaDet.crearPaginaDet(tbConfPaginasdet);
               return RedirectToAction(nameof(Index));
           }
           return View(tbConfPaginasdet);
       }

       // GET: PaginasDet/Edit/5
       public async Task<IActionResult> Edit(int id)
       {
           var paginaDet = new PaginasDetCmsService(new HttpClient());
           var paginaDetLista = await paginaDet.paginasDetListar();
           if (id == 0 || paginaDetLista == null)
           {
               return NotFound();
           }

           var tbConfPaginasdet = await paginaDet.obtenerPaginaDetDetalle(id);
           if (tbConfPaginasdet == null)
           {
               return NotFound();
           }
           return View(tbConfPaginasdet);
       }
    
       // POST: PaginasDet/Edit/5
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(int id, [Bind("Id,PaginaId,Titulo,Detalle,Imagen")] TbConfPaginasdet tbConfPaginasdet)
       {
           var paginaDet = new PaginasDetCmsService(new HttpClient());
           if (id != tbConfPaginasdet.Id)
           {
               return NotFound();
           }

           if (ModelState.IsValid)
           {
               try
               {

                    await paginaDet.modificarPaginaDet(id,tbConfPaginasdet);
               }
               catch (DbUpdateConcurrencyException)
               {
                   
                       return NotFound();
                   
               }
               return RedirectToAction(nameof(Index));
           }
           return View(tbConfPaginasdet);
       }

       // GET: PaginasDet/Delete/5
       public async Task<IActionResult> Delete(int id)
       {
           var paginaDet = new PaginasDetCmsService(new HttpClient());
           var paginaDetLista = await paginaDet.paginasDetListar();
           if (id == 0 || paginaDetLista == null)
           {
               return NotFound();
           }

           var tbConfPaginasdet = await paginaDet.obtenerPaginaDetDetalle(id);
           if (tbConfPaginasdet == null)
           {
               return NotFound();
           }

           return View(tbConfPaginasdet);
       }

       // POST: PaginasDet/Delete/5
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> DeleteConfirmed(int id)
       {
           var paginaDet = new PaginasDetCmsService(new HttpClient());
           var paginaDetLista = await paginaDet.paginasDetListar();
           if (paginaDetLista == null)
           {
               return Problem("Entity set 'CentralParkingContext.TbConfPaginasdets'  is null.");
           }
           var tbConfPaginasdet = await paginaDet.obtenerPaginaDetDetalle(id);
           if (tbConfPaginasdet != null)
           {
                await paginaDet.eliminarPaginaDet(id);
           }

          
           return RedirectToAction(nameof(Index));
       }

       
    }
}
