using ApiBD.Models;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class RolCmsController : Controller
    {
        // GET: Rol
        public async Task<IActionResult> Index()
        {
            var rol = new RolCmsService(new HttpClient());
            var rolLista = await rol.listarRoles();

            return rolLista != null ?
                        View(rolLista) :
                        Problem("Entity set 'CentralparkingContext.TbConfRoles'  is null.");
        }
       
        // GET: Rol/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var rol = new RolCmsService(new HttpClient());
            var rolLista = await rol.listarRoles();

            if (id == 0 || rolLista == null)
            {
                return NotFound();
            }

            var tbConfRole = await rol.obtenerRolDetalle(id);
            if (tbConfRole == null)
            {
                return NotFound();
            }

            return View(tbConfRole);
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
        public async Task<IActionResult> Create([Bind("Id,Rol,Descripcion,PermisoId,Estado,Creacion,Modificacion")] TbConfRole tbConfRole)
        {
            var rol = new RolCmsService(new HttpClient());
            if (ModelState.IsValid)
            {

                await rol.crearRol(tbConfRole);
                return RedirectToAction(nameof(Index));
            }
            return View(tbConfRole);
        }
        
       // GET: Rol/Edit/5
       public async Task<IActionResult> Edit(int id)
       {
            var rol = new RolCmsService(new HttpClient());
            var rolLista = await rol.listarRoles();
            if (id == 0 || rolLista == null)
           {
               return NotFound();
           }

           var tbConfRole = await rol.obtenerRolDetalle(id);
           if (tbConfRole == null)
           {
               return NotFound();
           }
           return View(tbConfRole);
       }

       // POST: Rol/Edit/5
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(int id, [Bind("Id,Rol,Descripcion,PermisoId,Estado,Creacion,Modificacion")] TbConfRole tbConfRole)
       {
           var rol = new RolCmsService(new HttpClient());
           if (id != tbConfRole.Id)
           {
               return NotFound();
           }

           if (ModelState.IsValid)
           {
               try
               {

                    await rol.modificarRol(id, tbConfRole);
               }
               catch (DbUpdateConcurrencyException)
               {
                  
                       return NotFound();
                   
               }
               return RedirectToAction(nameof(Index));
           }
           return View(tbConfRole);
       }

       // GET: Rol/Delete/5
       public async Task<IActionResult> Delete(int id)
       {
           var rol = new RolCmsService(new HttpClient());
           var rolLista = await rol.listarRoles();

           if (id == 0 || rolLista == null)
           {
               return NotFound();
           }

           var tbConfRole = await rol.obtenerRolDetalle(id);
           if (tbConfRole == null)
           {
               return NotFound();
           }

           return View(tbConfRole);
       }

       // POST: Rol/Delete/5
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> DeleteConfirmed(int id)
       {
           var rol = new RolCmsService(new HttpClient());
           var rolListado = rol.listarRoles();

           if (rolListado == null)
           {
               return Problem("Entity set 'CentralparkingContext.TbConfRoles'  is null.");
           }
           var tbConfRole = await rol.obtenerRolDetalle(id);
           if (tbConfRole != null)
           {
               await rol.eliminarRol(id);
           }

           return RedirectToAction(nameof(Index));
       }
      
    }
}
