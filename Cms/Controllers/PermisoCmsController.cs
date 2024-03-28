using ApiBD.Models;
using CentralParkingSystem.DTOs;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class PermisoCmsController : Controller
    {
        PermisoCmsService _permisoCmsService;
        RolCmsService _rolCmsService;
        MenuCmsService _menuCmsService;
        public PermisoCmsController(PermisoCmsService permisoCmsService, RolCmsService rolCmsService, MenuCmsService menuCmsService)
        {

            _permisoCmsService = permisoCmsService;
            _rolCmsService = rolCmsService;
            _menuCmsService = menuCmsService;

        }

        // GET: Permiso
        public async Task<IActionResult> Index(int tipoRol)
        {
            int idUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0;
            if (idUsuario == 0)
            {
                return RedirectToAction("Index", "DashbordCms");
            }
            //var permiso = new PermisoCmsService(new HttpClient());
            var permisoLista = await _permisoCmsService.listarPermisos();

            //var rol = new RolCmsService(new HttpClient());
            var rolLista = await _rolCmsService.listarRoles();
            ViewData["rolLista"] = rolLista;
            if (tipoRol != 0)
            {
                permisoLista = permisoLista.Where(permiso => permiso.Menu.TipoProyecto == "cms" && permiso.RolId == tipoRol).ToList();
            }
            else
            {
                permisoLista = permisoLista.Where(permiso => permiso.Menu.TipoProyecto == "cms").ToList();
            }
            
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
            //var permiso = new PermisoCmsService(new HttpClient());
            var permisoLista = await _permisoCmsService.listarPermisos();
            
            if (id == 0 || permisoLista == null)
            {
                return NotFound();
            }

            var tbConfPermiso = await _permisoCmsService.obtenerPermisoDetalle(id);
            if (tbConfPermiso == null)
            {
                return NotFound();
            }

            return View(tbConfPermiso);
        }
        
        // GET: Permiso/Create
        public async Task<IActionResult> Create()
        {
            //var rol = new RolCmsService(new HttpClient());
            var rolLista = await _rolCmsService.listarRoles();
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();
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
            //var permiso = new PermisoCmsService(new HttpClient());
            //var rol = new RolCmsService(new HttpClient());
            var rolLista = await _rolCmsService.listarRoles();
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();

            if (ModelState.IsValid)
            {

                await _permisoCmsService.crearPermiso(tbConfPermiso);
                return RedirectToAction(nameof(Index), new { tipoRol = tbConfPermiso.RolId });
            }
            ViewData["MenuId"] = new SelectList(menuLista, "Id", "Id", tbConfPermiso.MenuId);
            ViewData["RolId"] = new SelectList(rolLista, "Id", "Id", tbConfPermiso.RolId);
            return View(tbConfPermiso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Createpermisos([FromBody] List<TbConfPermiso> selectedPermissions)
        {
            var jsonResponse = new JsonResponse();
            //var permisogeneral = new PermisoCmsService(new HttpClient());
            var permisoListagral = await _permisoCmsService.listarPermisos();
            var rolId = 0;
            if (permisoListagral.Count == 0)
            {
                TbConfPermiso objPermiso = new TbConfPermiso();
                permisoListagral.Add(objPermiso);
                //return View(permisoListagral);
                jsonResponse.Status = false;
                jsonResponse.Message = "No existe ningun permiso para asignar.";
            }

            if (selectedPermissions == null || !selectedPermissions.Any())
            {
                //ModelState.AddModelError("Estado", "No ha seleccionado ningun registro.");
                //return View(permisoListagral);
                jsonResponse.Status = true;
                jsonResponse.Message = "No ha seleccionado ningun permiso.";
            }

            try
            {
                // Procesar la lista de permisos y crear o actualizar registros según sea necesario
                //var existingPermission=0;
                //var permiso = new PermisoCmsService(new HttpClient());
                var permisoLista = await _permisoCmsService.listarPermisos();
                var primerRolId = selectedPermissions[0].RolId;
                var permisoListaDel = await _permisoCmsService.listarPermisos();
                var permisosDelete = permisoListaDel.Where(menu => menu.RolId == primerRolId).ToList();

                foreach (var permisoEliminar in permisosDelete)
                {
                    await _permisoCmsService.eliminarPermiso(permisoEliminar.Id);
                }

                foreach (var permission in selectedPermissions)
                {
                    //var existingPermission = false;// permisoLista.Any(p => p.MenuId == permission.MenuId && p.RolId == permission.RolId);
                    //rolId = (int)permission.RolId;

                    ////existingPermission = permisoLista.Where(p => p.MenuId == permission.MenuId && p.RolId == permission.RolId).Count();
                    ////rolId = (int) permission.RolId;
                    //if (!existingPermission)
                    //{
                        
                        var newPermission = new TbConfPermiso
                        {
                            MenuId = permission.MenuId,
                            RolId = permission.RolId,
                            Descripcion = "Agregado multiple",
                            Estado = 1,
                            Creacion = DateTime.Now,
                        };
                        await _permisoCmsService.crearPermiso(newPermission);
                        
                    //}
                }
                //return RedirectToAction(nameof(Index), new { tipoRol = rolId });
                //return Ok("Datos guardados correctamente.");
                jsonResponse.Status = true;
                jsonResponse.Message = "Datos guardados correctamente.";
            }
            catch (Exception ex)
            {
                //return BadRequest("Error al guardar los datos: " + ex.Message);
                jsonResponse.Status = false;
                jsonResponse.Message = "Error al guardar los datos: " + ex.Message;
            }
            return Json(new { respuesta = jsonResponse });
        }

        public class JsonResponse
        {
            public bool Status { get; set; }
            public string Message { get; set; }
        }

        // GET: Permiso/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //var permiso = new PermisoCmsService(new HttpClient());
            var permisoLista = await _permisoCmsService.listarPermisos();
            //var rol = new RolCmsService(new HttpClient());
            var rolLista = await _rolCmsService.listarRoles();
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();
            var menuListaCms = menuLista.Where(menu => menu.TipoProyecto == "cms").ToList();
            if (id == 0 || permisoLista == null)
            {
                return NotFound();
            }

            //var subMenu = new MenuCmsService(new HttpClient());
            var listSubMenuCms = await _menuCmsService.ListarSubMenus();
            listSubMenuCms = menuLista.Where(menu => menu.TipoProyecto == "cms").ToList();
            if (listSubMenuCms.Count == 0)
            {
                return NotFound();
            }

            var tbConfPermiso = await _permisoCmsService.obtenerPermisoDetalle(id);
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

        // GET: Permiso/Edit/5
        public async Task<IActionResult> GetEditar(int id)
        {
            //var permiso = new PermisoCmsService(new HttpClient());
            var permisoLista = await _permisoCmsService.listarPermisos();
            //var rol = new RolCmsService(new HttpClient());
            var rolLista = await _rolCmsService.listarRoles();
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();
            var menuListaCms = menuLista.Where(menu => menu.TipoProyecto == "cms").ToList();
            if (id == 0 || permisoLista == null)
            {
                return NotFound();
            }

            //var subMenu = new MenuCmsService(new HttpClient());
            var listSubMenuCms = await _menuCmsService.ListarSubMenus();
            listSubMenuCms = menuLista.Where(menu => menu.TipoProyecto == "cms").ToList();
            if (listSubMenuCms.Count == 0)
            {
                return NotFound();
            }

            var tbConfPermiso = await _permisoCmsService.listarPermisos();
            var permisosss = tbConfPermiso.Where(per=>  per.RolId == id).ToList();
            var permisouno = tbConfPermiso.Where(per => per.RolId == id).Take(1).SingleOrDefault();
            if (tbConfPermiso == null)
            {
                return NotFound();
            }
            foreach (var subMenues in listSubMenuCms)
            {
                var selecc = 0;
                bool tienePermiso = permisosss.Any(per => per.MenuId == subMenues.Id);
                if (tienePermiso) {selecc = 1;}
                subMenues.Acceso = selecc;
            }
            foreach (var Menues in menuListaCms)
            {
                var selecc2 = 0;
                bool tienePermiso = permisosss.Any(per => per.MenuId == Menues.Id);
                if (tienePermiso) { selecc2 = 1; }
                Menues.Acceso = selecc2;
            }

            ViewData["MenuList"] = menuListaCms;
            ViewData["SubMenuList"] = listSubMenuCms;
            //ViewData["MenuId"] = new SelectList(menuListaCms, "Id", "Nombre", tbConfPermiso.MenuId);
            ViewData["RolId"] = new SelectList(rolLista, "Id", "Rol", id);
            return View(permisouno);
        }
        // POST: Permiso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Permiso,Descripcion,MenuId,RolId,Estado,Creacion,Modificacion")] TbConfPermiso tbConfPermiso, [FromBody] List<TbConfPermiso> selectedPermissions)
        {
            //var permiso = new PermisoCmsService(new HttpClient());
            //var rol = new RolCmsService(new HttpClient());
            var rolLista = await _rolCmsService.listarRoles();
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();

            if (id != tbConfPermiso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _permisoCmsService.modificarPermiso(id, tbConfPermiso);
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
            //var permiso = new PermisoCmsService(new HttpClient());
            var permisoLista = await _permisoCmsService.listarPermisos();

            if (id == 0 || permisoLista == null)
            {
                return NotFound();
            }

            var tbConfPermiso = await _permisoCmsService.obtenerPermisoDetalle(id);
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
            //var permiso = new PermisoCmsService(new HttpClient());
            var permisoLista = await _permisoCmsService.listarPermisos();

            if (permisoLista == null)
            {
                return Problem("Entity set 'CentralparkingContext.TbConfPermisos'  is null.");
            }
            var tbConfPermiso = await _permisoCmsService.obtenerPermisoDetalle(id);
            if (tbConfPermiso != null)
            {
                await _permisoCmsService.eliminarPermiso(id);
            }

       
            return RedirectToAction(nameof(Index));
        }
        
    }
}
