﻿using ApiBD.Models;
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
            permisoLista = permisoLista.Where(permiso => permiso.Menu.TipoProyecto == "cms").ToList();
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Createpermisos([FromBody] List<TbConfPermiso> selectedPermissions)
        {
            var permisogeneral = new PermisoCmsService(new HttpClient());
            var permisoListagral = await permisogeneral.listarPermisos();
            if (permisoListagral.Count == 0)
            {
                TbConfPermiso objPermiso = new TbConfPermiso();
                permisoListagral.Add(objPermiso);
                return View(permisoListagral);
            }

            if (selectedPermissions == null || !selectedPermissions.Any())
            {
                ModelState.AddModelError("Estado", "No ha seleccionado ningun registro.");
                return View(permisoListagral);
            }

            try
            {
                // Procesar la lista de permisos y crear o actualizar registros según sea necesario
                var existingPermission=0;
                foreach (var permission in selectedPermissions)
                {
                    // Verificar si el permiso ya existe en la base de datos
                    var permiso = new PermisoCmsService(new HttpClient());
                    var permisoLista = await permiso.listarPermisos();
                    permisoLista = permisoLista.Where(menu => menu.MenuId == permission.MenuId).ToList();
                    existingPermission = permisoLista.Where(p => p.MenuId == permission.MenuId && p.RolId == permission.RolId).Count();

                    if (existingPermission == 0)
                    {
                        
                        var newPermission = new TbConfPermiso
                        {
                            MenuId = permission.MenuId,
                            RolId = permission.RolId,
                            Descripcion = "Agregado multiple",
                            Estado = 1,
                            Creacion = DateTime.Now,
                        };
                        await permiso.crearPermiso(newPermission);
                        
                    }
                }
                return RedirectToAction(nameof(Index));
                //return Ok("Datos guardados correctamente.");
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
