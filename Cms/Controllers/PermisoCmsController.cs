using ApiBD.Models;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class PermisoCmsController : Controller
    {
        // GET: Permiso
        public async Task<IActionResult> Index()
        {
            var permiso = new PermisoCmsService(new HttpClient());
            var permisoLista = await permiso.listarPermisos();
            if (permisoLista.Count == 0)
            {
                TbConfPermiso objPermiso = new TbConfPermiso();
                permisoLista.Add(objPermiso);
                return View(permisoLista);
            }

             return View(permisoLista);
        }

        // GET: Permiso/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var permiso = new PermisoCmsService(new HttpClient());
            var permisoLista = await permiso.listarPermisos();

            if (id == 0 || permisoLista == null)
            {
                return NotFound();
            }

            var tbConfPermiso = await permiso.obtenerPermisoDetalle(id);
            if (tbConfPermiso == null)
            {
                return NotFound();
            }

            return View(tbConfPermiso);
        }
        
        // GET: Permiso/Create
        public async Task<IActionResult> Create()
        {
            var rol = new RolCmsService(new HttpClient());
            var rolLista = await rol.listarRoles();
            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();
            menuLista = menuLista.Where(menu => menu.TipoProyecto == "cms").ToList();

            ViewData["MenuId"] = new SelectList(menuLista, "Id", "Nombre");
            ViewData["RolId"] = new SelectList(rolLista, "Id", "Rol");
            return View();
        }

        // POST: Permiso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Permiso,Descripcion,MenuId,RolId,Estado,Creacion,Modificacion")] TbConfPermiso tbConfPermiso)
        {
            var permiso = new PermisoCmsService(new HttpClient());
            var rol = new RolCmsService(new HttpClient());
            var rolLista = await rol.listarRoles();
            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();

            if (ModelState.IsValid)
            {

                await permiso.crearPermiso(tbConfPermiso);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(menuLista, "Id", "Id", tbConfPermiso.MenuId);
            ViewData["RolId"] = new SelectList(rolLista, "Id", "Id", tbConfPermiso.RolId);
            return View(tbConfPermiso);
        }

        [HttpPost]
        [Route("Crearpermisos")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Createpermisos([FromBody] List<TbConfPermiso> selectedPermissions)
        {
            if (selectedPermissions == null || !selectedPermissions.Any())
            {
                return BadRequest("No se han proporcionado permisos seleccionados.");
            }

            try
            {
                // Procesar la lista de permisos y crear o actualizar registros según sea necesario
                foreach (var permission in selectedPermissions)
                {
                    // Verificar si el permiso ya existe en la base de datos
                    var permiso = new PermisoCmsService(new HttpClient());
                    var permisoLista = await permiso.listarPermisos();
                    permisoLista = permisoLista.Where(menu => menu.MenuId == permission.MenuId).ToList();
                    //var existingPermission = await _dbContext.TbConfPermiso.FirstOrDefaultAsync(p => p.MenuId == permission.MenuId && p.SubmenuId == permission.SubmenuId);

                    //if (existingPermission != null)
                    //{
                    //    // El permiso ya existe, realiza la actualización si es necesario
                    //    // Por ejemplo, actualiza la descripción o el estado si es diferente
                    //    existingPermission.Descripcion = permission.Descripcion;
                    //    existingPermission.Estado = permission.Estado;
                    //    existingPermission.Modificacion = DateTime.Now;
                    //}
                    //else
                    //{
                    //    // El permiso no existe, crea uno nuevo
                    //    var newPermission = new TbConfPermiso
                    //    {
                    //        MenuId = permission.MenuId,
                    //        SubmenuId = permission.SubmenuId,
                    //        Descripcion = permission.Descripcion,
                    //        Estado = permission.Estado,
                    //        Creacion = DateTime.Now,
                    //        Modificacion = DateTime.Now
                    //    };

                    //    _dbContext.TbConfPermiso.Add(newPermission);
                    //}
                }

                //await _dbContext.SaveChangesAsync();
                return Ok("Datos guardados correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al guardar los datos: " + ex.Message);
            }
        }

        // GET: Permiso/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var permiso = new PermisoCmsService(new HttpClient());
            var permisoLista = await permiso.listarPermisos();
            var rol = new RolCmsService(new HttpClient());
            var rolLista = await rol.listarRoles();
            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();
            var menuListaCms = menuLista.Where(menu => menu.TipoProyecto == "cms").ToList();
            if (id == 0 || permisoLista == null)
            {
                return NotFound();
            }

            var subMenu = new MenuCmsService(new HttpClient());
            var listSubMenuCms = await subMenu.ListarSubMenus();
            listSubMenuCms = menuLista.Where(menu => menu.TipoProyecto == "cms").ToList();
            if (listSubMenuCms.Count == 0)
            {
                return NotFound();
            }

            var tbConfPermiso = await permiso.obtenerPermisoDetalle(id);
            if (tbConfPermiso == null)
            {
                return NotFound();
            }
            ViewData["MenuList"] = menuListaCms;
            ViewData["SubMenuList"] = listSubMenuCms;
            ViewData["MenuId"] = new SelectList(menuListaCms, "Id", "Nombre", tbConfPermiso.MenuId);
            ViewData["RolId"] = new SelectList(rolLista, "Id", "Rol", tbConfPermiso.RolId);
            return View(tbConfPermiso);
        }

        // POST: Permiso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Permiso,Descripcion,MenuId,RolId,Estado,Creacion,Modificacion")] TbConfPermiso tbConfPermiso, [FromBody] List<TbConfPermiso> selectedPermissions)
        {
            var permiso = new PermisoCmsService(new HttpClient());
            var rol = new RolCmsService(new HttpClient());
            var rolLista = await rol.listarRoles();
            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();

            if (id != tbConfPermiso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await permiso.modificarPermiso(id, tbConfPermiso);
                }
                catch (DbUpdateConcurrencyException)
                {
                  
                        return NotFound();
                   
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(menuLista, "Id", "Id", tbConfPermiso.MenuId);
            ViewData["RolId"] = new SelectList(rolLista, "Id", "Id", tbConfPermiso.RolId);
            return View(tbConfPermiso);
        }
         
        // GET: Permiso/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var permiso = new PermisoCmsService(new HttpClient());
            var permisoLista = await permiso.listarPermisos();

            if (id == 0 || permisoLista == null)
            {
                return NotFound();
            }

            var tbConfPermiso = await permiso.obtenerPermisoDetalle(id);
            if (tbConfPermiso == null)
            {
                return NotFound();
            }

            return View(tbConfPermiso);
        }
       
        // POST: Permiso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permiso = new PermisoCmsService(new HttpClient());
            var permisoLista = await permiso.listarPermisos();

            if (permisoLista == null)
            {
                return Problem("Entity set 'CentralparkingContext.TbConfPermisos'  is null.");
            }
            var tbConfPermiso = await permiso.obtenerPermisoDetalle(id);
            if (tbConfPermiso != null)
            {
                await permiso.eliminarPermiso(id);
            }

       
            return RedirectToAction(nameof(Index));
        }
        
    }
}
