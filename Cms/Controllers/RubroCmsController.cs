using ApiBD.Models;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class RubroCmsController : Controller
    {
        RubroCmsService _rubroCmsService;
        public RubroCmsController(RubroCmsService rubroCmsService)
        {

            _rubroCmsService = rubroCmsService;

        }
        // GET: Rubro
        public async Task<IActionResult> Index()
        {
            //var rubro = new RubroCmsService(new HttpClient());
            var rubroLista = await _rubroCmsService.listarRubros();
            if (rubroLista.Count == 0)
            {
                TbConfRubro objRole = new TbConfRubro();
                rubroLista.Add(objRole);
                return View(rubroLista);

            }

            return rubroLista != null ?
                        View(rubroLista) :
                        Problem("Entity set 'CentralparkingContext.TbConfRubros'  is null.");
        }
       
        // GET: Rol/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var rubro = new RubroCmsService(new HttpClient());
            var rubroLista = await _rubroCmsService.listarRubros();

            if (id == 0 || rubroLista == null)
            {
                return NotFound();
            }

            var tbConfRubro = await _rubroCmsService.obtenerRubroDetalle(id);
            if (tbConfRubro == null)
            {
                return NotFound();
            }

            return View(tbConfRubro);
        }

        // GET: Rol/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rol/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rubro")] TbConfRubro tbConfRubro)
        {
            //var rol = new RubroCmsService(new HttpClient());
            if (ModelState.IsValid)
            {

                await _rubroCmsService.crearRubro(tbConfRubro);
                return RedirectToAction(nameof(Index));
            }
            return View(tbConfRubro);
        }
        
       // GET: Rol/Edit/5
       public async Task<IActionResult> Edit(int id)
       {
            //var rubro = new RubroCmsService(new HttpClient());
            var rubroLista = await _rubroCmsService.listarRubros();
            if (id == 0 || rubroLista == null)
           {
               return NotFound();
           }

           var tbConfRubro = await _rubroCmsService.obtenerRubroDetalle(id);
           if (tbConfRubro == null)
           {
               return NotFound();
           }
           return View(tbConfRubro);
       }

       // POST: Rol/Edit/5
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(int id, [Bind("Id,Rubro")] TbConfRubro tbConfRubro)
       {
           //var rubro = new RubroCmsService(new HttpClient());
           if (id != tbConfRubro.Id)
           {
               return NotFound();
           }

           if (ModelState.IsValid)
           {
               try
               {

                    await _rubroCmsService.modificarRubro(id, tbConfRubro);
               }
               catch (DbUpdateConcurrencyException)
               {
                  
                       return NotFound();
                   
               }
               return RedirectToAction(nameof(Index));
           }
           return View(tbConfRubro);
       }

       // GET: Rol/Delete/5
       public async Task<IActionResult> Delete(int id)
       {
           //var rubro = new RubroCmsService(new HttpClient());
           var rubroLista = await _rubroCmsService.listarRubros();

           if (id == 0 || rubroLista == null)
           {
               return NotFound();
           }

           var tbConfRubro = await _rubroCmsService.obtenerRubroDetalle(id);
           if (tbConfRubro == null)
           {
               return NotFound();
           }

           return View(tbConfRubro);
       }

       // POST: Rol/Delete/5
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> DeleteConfirmed(int id)
       {
           //var rubro = new RubroCmsService(new HttpClient());
           var rubroListado = _rubroCmsService.listarRubros();

           if (rubroListado == null)
           {
               return Problem("Entity set 'CentralparkingContext.TbConfRubros'  is null.");
           }
           var tbConfRole = await _rubroCmsService.obtenerRubroDetalle(id);
           if (tbConfRole != null)
           {
               await _rubroCmsService.eliminarRubro(id);
           }

           return RedirectToAction(nameof(Index));
       }
      
    }
}
