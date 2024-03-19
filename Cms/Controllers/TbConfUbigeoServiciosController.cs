using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiBD.Models;
using Cms.ServiceCms;
using static Cms.Controllers.PermisoCmsController;
using Newtonsoft.Json.Linq;
using System.Collections;

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
            var ubigeoServicio = await _ubigeoServicioscmsService.listarDistritosPorServicio();
            ubigeoServicio = ubigeoServicio.Where(ubiser => ubiser.IdServicio == tipoServicio).ToList();
            if (ubigeoServicio.Count == 0)
            {
                TbConfUbigeoServicio objPermiso = new TbConfUbigeoServicio();
                ubigeoServicio.Add(objPermiso);
            }

            return View(ubigeoServicio);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ubigeoServicio = await _ubigeoServicioscmsService.listarUbigeoPorServicio(id);
            if (ubigeoServicio.Count == 0)
            {
                TbConfUbigeoServicio objUbigeoServicio = new TbConfUbigeoServicio
                {
                    IdServicio = id
                };
                ubigeoServicio.Add(objUbigeoServicio);
            }
            var listServicios = await _servicioCabeceraCmsService.listarServiciosCabecera();
            var listDpto = await _ubigeoServicioscmsService.obtenerDepartamento();
            var listDistritos = await _ubigeoServicioscmsService.obtenerDistritosPorProvincia("1501");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Creadistritosservice(int idServicio, List<string> distritosSeleccionados)
        {
            var jsonResponse = new JsonResponse();

            if (distritosSeleccionados == null || !distritosSeleccionados.Any())
            {
                jsonResponse.Status = true;
                jsonResponse.Message = "No ha seleccionado ningún distrito.";
            }

            try
            {
                var primerIdServicio = idServicio;
                var ubiservListaDel = await _ubigeoServicioscmsService.listarDistritosPorServicio();
                var ubiservDelete = ubiservListaDel.Where(ubiserv => ubiserv.IdServicio == primerIdServicio).ToList();

                foreach (var ubiserEliminar in ubiservDelete)
                {
                    await _ubigeoServicioscmsService.eliminarUbigeoServicio((int)ubiserEliminar.IdServicio, ubiserEliminar.CodUbi);
                }

                foreach (var distrito in distritosSeleccionados)
                {
                    var newUbigeoServicio = new TbConfUbigeoServicio
                    {
                        IdServicio = primerIdServicio,
                        CodUbi = distrito,
                    };
                    await _ubigeoServicioscmsService.crearUbigeoServicio(newUbigeoServicio);
                }
                TempData["SuccessMessage"] = "Datos guardados correctamente.";
                return RedirectToAction(nameof(Index), new { tipoServicio = idServicio });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al guardar los datos: " + ex.Message;
                return View("Edit");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodUbi,IdServicio")] TbConfUbigeoServicio tbConfUbigeoServicios, [FromBody] List<TbConfUbigeoServicio> selectedTbConfUbigeoServicios)
        {
            if (id != tbConfUbigeoServicios.IdServicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _ubigeoServicioscmsService.obtenerDistritos("1501");
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }
                return RedirectToAction(nameof(Index), new { tipoServicio = id });
            }
            return View(tbConfUbigeoServicios);
        }

        public async Task<IActionResult> Delete(int idservicio, string codubi)
        {
            var tbConfUbigeoServicios = await _ubigeoServicioscmsService.getEliminarUbigeoPorServicio(idservicio, codubi);
            if (tbConfUbigeoServicios == null)
            {
                return NotFound();
            }

            return View(tbConfUbigeoServicios);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int IdServicio, string CodUbi)
        {
            var tbConfUbigeoServicios = await _ubigeoServicioscmsService.getEliminarUbigeoPorServicio(IdServicio, CodUbi);
            if (tbConfUbigeoServicios != null)
            {
                await _ubigeoServicioscmsService.eliminarUbigeoServicio(IdServicio, CodUbi);
            }
            return RedirectToAction(nameof(Index), new { tipoServicio = IdServicio });
        }
    }
}
