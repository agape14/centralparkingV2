using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class PaginasCmsController : Controller
    {
        // GET: Paginas
        public async Task<IActionResult> Index()
        {
            var paginaCabs = new PaginasCmsService(new HttpClient());
            var paginaCabsLista = await paginaCabs.paginasListar();

            if(paginaCabsLista.Count == 0)
            {
                TbConfPaginascab objPaginasCab = new TbConfPaginascab();
                paginaCabsLista.Add(objPaginasCab);
                return View(paginaCabsLista);
            }

            return paginaCabsLista != null ?
                        View(paginaCabsLista) :
                        Problem("Entity set 'CentralParkingContext.TbConfPaginascabs'  is null.");
        }
      
        // GET: Paginas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var paginaCabs = new PaginasCmsService(new HttpClient());
            var paginaCabsLista = await paginaCabs.paginasListar();
            if (id == 0 || paginaCabsLista == null)
            {
                return NotFound();
            }

            var tbConfPaginascab = await paginaCabs.obtenerPaginaDetalle(id);

            if (tbConfPaginascab == null)
            {
                return NotFound();
            }

            return View(tbConfPaginascab);
        }

        // GET: Paginas/Create
        public IActionResult Create()
        {
            return View();
        }
        
      // POST: Paginas/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("Id,Titulo,Subtitulo,ReseniaTitulo,ReseniaDetalle,MisionTitulo,MisionDetalle,VisionTitulo,VisionDetalle,ValoresTitulo,ValoresDetalle,ReconocTitulo,ReconocDetalle,ImagenMision,ImagenValores")] TbConfPaginascab tbConfPaginascab)
      {
            var paginaCabs = new PaginasCmsService(new HttpClient());
            if (ModelState.IsValid)
          {
              await paginaCabs.crearPagina(tbConfPaginascab);
              return RedirectToAction(nameof(Index));
          }
          return View(tbConfPaginascab);
      }
    
      // GET: Paginas/Edit/5
      public async Task<IActionResult> Edit(int id)
      {
            var paginaCabs = new PaginasCmsService(new HttpClient());
            var paginaCabsLista = await paginaCabs.paginasListar();

            if (id == 0 || paginaCabsLista == null)
          {
              return NotFound();
          }

          var tbConfPaginascab = await paginaCabs.obtenerPaginaDetalle(id);
          if (tbConfPaginascab == null)
          {
              return NotFound();
          }
          return View(tbConfPaginascab);
      }

      // POST: Paginas/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Subtitulo,ReseniaTitulo,ReseniaDetalle,MisionTitulo,MisionDetalle,VisionTitulo,VisionDetalle,ValoresTitulo,ValoresDetalle,ReconocTitulo,ReconocDetalle,ImagenMision,ImagenValores")] TbConfPaginascab tbConfPaginascab)
      {
          var paginaCabs = new PaginasCmsService(new HttpClient());
          if (id != tbConfPaginascab.Id)
          {
              return NotFound();
          }

          if (ModelState.IsValid)
          {
              try
              {

                    await paginaCabs.modificarPagina(id, tbConfPaginascab);
              }
              catch (DbUpdateConcurrencyException)
              {
                  
                      return NotFound();
                  
              }
              return RedirectToAction(nameof(Index));
          }
          return View(tbConfPaginascab);
      }
      
      // GET: Paginas/Delete/5
      public async Task<IActionResult> Delete(int id)
      {
            var paginaCabs = new PaginasCmsService(new HttpClient());
            var paginaCabsLista = await paginaCabs.paginasListar();

            if (id == 0 || paginaCabsLista == null)
          {
              return NotFound();
          }

          var tbConfPaginascab = await paginaCabs.obtenerPaginaDetalle(id);
          if (tbConfPaginascab == null)
          {
              return NotFound();
          }

          return View(tbConfPaginascab);
      }

      // POST: Paginas/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
            var paginaCabs = new PaginasCmsService(new HttpClient());
            var paginaCabsLista = await paginaCabs.paginasListar();

            if (paginaCabsLista == null)
          {
              return Problem("Entity set 'CentralParkingContext.TbConfPaginascabs'  is null.");
          }
          var tbConfPaginascab = await paginaCabs.obtenerPaginaDetalle(id);
          if (tbConfPaginascab != null)
          {
                await paginaCabs.eliminarPagina(id);
          }

       
          return RedirectToAction(nameof(Index));
      }
    
    }
}