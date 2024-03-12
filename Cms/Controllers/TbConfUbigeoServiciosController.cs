using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiBD.Models;
using Cms.ServiceCms;

namespace Cms.Controllers
{
    public class TbConfUbigeoServiciosController : Controller
    {
        ServicioCabeceraCmsService _servicioCabeceraCmsService;
        UbigeoServicioscmsService _ubigeoServicioscmsService;
        public TbConfUbigeoServiciosController(ServicioCabeceraCmsService servicioCabeceraCmsService,  UbigeoServicioscmsService ubigeoServicioscmsService)
        {
            _servicioCabeceraCmsService = servicioCabeceraCmsService;
            _ubigeoServicioscmsService = ubigeoServicioscmsService;
        }

        // GET: TbConfUbigeoServicios
        public async Task<IActionResult> Index(int tipoServicio)
        {
            var listServicios = await _servicioCabeceraCmsService.listarServiciosCabecera();
            ViewData["serviciosLista"] = listServicios;

            TbConfUbigeoServicio ubigeoServicio;
            ubigeoServicio = await _ubigeoServicioscmsService.listarUbigeoPorServicio(tipoServicio);

            //var permisoLista = await _ubigeoServicioscmsService.listarUbigeoPorServicio(tipoServicio);
            //if (permisoLista.Count == 0)
            //{
            //    TbConfUbigeoServicio objPermiso = new TbConfUbigeoServicio();
            //    permisoLista.Add(objPermiso);
            //    return View(permisoLista);
            //}

            //TbConfUbigeoServicio ubigeoServicio;
            //var listaUbigeoServicio = new List<TbConfUbigeoServicio>();
            //if (tipoServicio != 0)
            //{
            //    ubigeoServicio = await _ubigeoServicioscmsService.listarUbigeoPorServicio(tipoServicio);
                
            //    if (ubigeoServicio != null)
            //    {
            //        listaUbigeoServicio.Add(ubigeoServicio);
            //    }
            //}

            return View(ubigeoServicio);
        }


        // public async Task<IActionResult> Index(int tipoRol)
        //{
        //    //var permiso = new PermisoCmsService(new HttpClient());
        //    var permisoLista = await _permisoCmsService.listarPermisos();

        //    //var rol = new RolCmsService(new HttpClient());
        //    var rolLista = await _rolCmsService.listarRoles();
        //    ViewData["rolLista"] = rolLista;
        //    if (tipoRol != 0)
        //    {
        //        permisoLista = permisoLista.Where(permiso => permiso.Menu.TipoProyecto == "cms" && permiso.RolId == tipoRol).ToList();
        //    }
        //    else
        //    {
        //        permisoLista = permisoLista.Where(permiso => permiso.Menu.TipoProyecto == "cms").ToList();
        //    }

        //    if (permisoLista.Count == 0)
        //    {
        //        TbConfPermiso objPermiso = new TbConfPermiso();
        //        permisoLista.Add(objPermiso);
        //        return View(permisoLista);
        //    }

        //    return View(permisoLista);
        //}

        public async Task<IActionResult> Edit(int id)
        {
            TbConfUbigeoServicio ubigeoServicio;
            ubigeoServicio = await _ubigeoServicioscmsService.listarUbigeoPorServicio(id);
            //var tbUbSer = new TbConfUbigeoServicio();
            //var permisoLista = await _permisoCmsService.listarPermisos();
            var listServicios = await _servicioCabeceraCmsService.listarServiciosCabecera();
            var listDpto = await _ubigeoServicioscmsService.obtenerDepartamento();
            var listDistritos = await _ubigeoServicioscmsService.obtenerDistritosPorProvincia("1501");
            //var menuLista = await _menuCmsService.listarMenus();
            //var menuListaCms = menuLista.Where(menu => menu.TipoProyecto == "cms").ToList();
            //if (id == 0 || permisoLista == null)
            //{
            //    return NotFound();
            //}

            //var listSubMenuCms = await _menuCmsService.ListarSubMenus();
            //listSubMenuCms = menuLista.Where(menu => menu.TipoProyecto == "cms").ToList();
            //if (listSubMenuCms.Count == 0)
            //{
            //    return NotFound();
            //}

            //var tbConfPermiso = await _permisoCmsService.listarPermisos();
            //var permisosss = tbConfPermiso.Where(per => per.RolId == id).ToList();
            //var permisouno = tbConfPermiso.Where(per => per.RolId == id).Take(1).SingleOrDefault();
            //if (tbConfPermiso == null)
            //{
            //    return NotFound();
            //}
            //foreach (var subMenues in listSubMenuCms)
            //{
            //    var selecc = 0;
            //    bool tienePermiso = permisosss.Any(per => per.MenuId == subMenues.Id);
            //    if (tienePermiso) { selecc = 1; }
            //    subMenues.Acceso = selecc;
            //}
            //foreach (var Menues in menuListaCms)
            //{
            //    var selecc2 = 0;
            //    bool tienePermiso = permisosss.Any(per => per.MenuId == Menues.Id);
            //    if (tienePermiso) { selecc2 = 1; }
            //    Menues.Acceso = selecc2;
            //}

            //ViewData["MenuList"] = menuListaCms;
            //ViewData["SubMenuList"] = listSubMenuCms;
            ViewData["DistritosList"] = listDistritos;
            ViewData["ServicioList"] = new SelectList(listServicios, "Id", "Titulo", id);
            ViewData["DptoId"] = new SelectList(listDpto, "CodUbi", "Dpto");

            return View(ubigeoServicio);
        }

        public async Task<JsonResult> GetProvincias(string departamentoId)
        {
            var provincias = await _ubigeoServicioscmsService.obtenerProvinciasPorDepartamento(departamentoId);
            return Json(provincias);
        }

        public async Task<JsonResult> GetDistritos(string provinciaId)
        {
            var distritos = await _ubigeoServicioscmsService.obtenerDistritosPorProvincia(provinciaId);
            return Json(distritos);
        }

    }
}
