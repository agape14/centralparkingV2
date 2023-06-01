using ApiBD.Models;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class UsuarioCmsController : Controller
    {
        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            var usuario = new UsuarioCmsService(new HttpClient());
            var usuarioLista = await usuario.listarUsuarios();
            return View(usuarioLista);
        }
       
        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(ulong id)
        {
            var usuario = new UsuarioCmsService(new HttpClient());
            var usuarioLista = await usuario.listarUsuarios();

            if (id == 0 || usuarioLista == null)
            {
                return NotFound();
            }

            var tbConfUser = await usuario.obtenerUsuarioDetalle(id);
            if (tbConfUser == null)
            {
                return NotFound();
            }

            return View(tbConfUser);
        }
       
        // GET: Usuario/Create
        public async Task<IActionResult> Create()
        {

            var rol = new RolCmsService(new HttpClient());
            var rolLista = await rol.listarRoles(); 
            ViewData["RolId"] = new SelectList(rolLista, "Id", "Rol");
            return View();
        }
        
        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Username,Password,EmailVerifiedAt,TwoFactorSecret,TwoFactorRecoveryCodes,TwoFactorConfirmedAt,RememberToken,CurrentTeamId,ProfilePhotoPath,CreatedAt,UpdatedAt,Active,Apaterno,Amaterno,Dni,RolId")] TbConfUser tbConfUser)
        {
            var usuario = new UsuarioCmsService(new HttpClient());
            var rol = new RolCmsService(new HttpClient());
            var rolLista = await rol.listarRoles();

            if (ModelState.IsValid)
            {
                await usuario.crearUsuario(tbConfUser);
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolId"] = new SelectList(rolLista, "Id", "Id", tbConfUser.RolId);
            return View(tbConfUser);
        }
        
       // GET: Usuario/Edit/5
       public async Task<IActionResult> Edit(ulong id)
       {
           var usuario = new UsuarioCmsService(new HttpClient());
           var usuarioLista = await usuario.listarUsuarios();
           var rol = new RolCmsService(new HttpClient());
           var rolLista = await rol.listarRoles();

            if (id == 0 || usuarioLista == null)
           {
               return NotFound();
           }

           var tbConfUser = await usuario.obtenerUsuarioDetalle(id);
           if (tbConfUser == null)
           {
               return NotFound();
           }
           ViewData["RolId"] = new SelectList(rolLista, "Id", "Rol", tbConfUser.RolId);
           return View(tbConfUser);
       }
        
       // POST: Usuario/Edit/5
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(ulong id, [Bind("Id,Name,Email,Username,Password,EmailVerifiedAt,TwoFactorSecret,TwoFactorRecoveryCodes,TwoFactorConfirmedAt,RememberToken,CurrentTeamId,ProfilePhotoPath,CreatedAt,UpdatedAt,Active,Apaterno,Amaterno,Dni,RolId")] TbConfUser tbConfUser)
       {
            var usuario = new UsuarioCmsService(new HttpClient());
            var rol = new RolCmsService(new HttpClient());
            var rolLista = await rol.listarRoles();
            if (id != tbConfUser.Id)
           {
               return NotFound();
           }

           if (ModelState.IsValid)
           {
               try
               {

                    await usuario.modificarUsuario(id, tbConfUser);
               }
               catch (DbUpdateConcurrencyException)
               {
                  
                       return NotFound();
                  
               }
               return RedirectToAction(nameof(Index));
           }
           ViewData["RolId"] = new SelectList(rolLista, "Id", "Id", tbConfUser.RolId);
           return View(tbConfUser);
       }

       // GET: Usuario/Delete/5
       public async Task<IActionResult> Delete(ulong id)
        {
            var usuario = new UsuarioCmsService(new HttpClient());
            var usuarioLista = await usuario.listarUsuarios();

            if (id == 0 || usuarioLista == null)
           {
               return NotFound();
           }

            var tbConfUser = await usuario.obtenerUsuarioDetalle(id);
           if (tbConfUser == null)
           {
               return NotFound();
           }

           return View(tbConfUser);
       }

       // POST: Usuario/Delete/5
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> DeleteConfirmed(ulong id)
       {
            var usuario = new UsuarioCmsService(new HttpClient());
            var usuarioLista = await usuario.listarUsuarios();

            if (usuarioLista == null)
           {
               return Problem("Entity set 'CentralparkingContext.TbConfUsers'  is null.");
           }
           var tbConfUser = await usuario.obtenerUsuarioDetalle(id);
           if (tbConfUser != null)
           {
               await usuario.eliminarUsuario(id);
           }

         
           return RedirectToAction(nameof(Index));
       }
       
    }
}
