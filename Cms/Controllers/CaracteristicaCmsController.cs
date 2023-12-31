﻿using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class CaracteristicaCmsController : Controller
    {
        // GET: Caracteristica
        public async Task<IActionResult> Index()
        {
            var caracteristica = new CaracteristicasService(new HttpClient());
            var caracteristicaLista = await caracteristica.ListarCaracteristicas();

            if (caracteristicaLista.Count == 0)
            {
                TbIndCaracteristica objCaracteristica = new TbIndCaracteristica();
                caracteristicaLista.Add(objCaracteristica);
                return View(caracteristicaLista);
            }

            return caracteristicaLista != null ?
                        View(caracteristicaLista) :
                        Problem("Entity set 'CentralparkingContext.TbIndCaracteristicas'  is null.");
        }

        // GET: Caracteristica/Details/5
        public async Task<IActionResult> Details(uint id)
        {
            var caracteristica = new CaracteristicasService(new HttpClient());
            var caracteristicaLista = await caracteristica.ListarCaracteristicas();
            var caracteristicaCms = new CaracteristicaCmsService(new HttpClient());
            if (id == 0 || caracteristicaLista == null)
            {
                return NotFound();
            }

            var tbIndCaracteristica = await caracteristicaCms.obtenerCaracteristicaDetalle(id);
            if (tbIndCaracteristica == null)
            {
                return NotFound();
            }

            return View(tbIndCaracteristica);
        }

        // GET: Caracteristica/Create
        public IActionResult Create()
        {
            //Listando Iconos
            var menuLista = getIcons();
            var menuItems = menuLista.Select(m => new SelectListItem
            {
                Value = m.Class,
                Text = m.Class + " " + m.Descripcion
            });
            ViewData["vMenu"] = new SelectList(
                Enumerable.Repeat(new SelectListItem { Value = "", Text = "Selecciona" }, 1)
                .Concat(menuItems),
                "Value",
                "Text"
            );
            return View();
        }

        // POST: Caracteristica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Icono,Detalle")] TbIndCaracteristica tbIndCaracteristica)
        {
            var caracteristicaCms = new CaracteristicaCmsService(new HttpClient());
            if (ModelState.IsValid)
            {
                await caracteristicaCms.crearCaracteristica(tbIndCaracteristica);
                return RedirectToAction(nameof(Index));
            }
            return View(tbIndCaracteristica);
        }

        // GET: Caracteristica/Edit/5
        public async Task<IActionResult> Edit(uint id)
        {
            //Listando Iconos
            var menuLista = getIcons();
            var menuItems = menuLista.Select(m => new SelectListItem
            {
                Value = m.Class,
                Text = m.Class + " " + m.Descripcion
            });
            ViewData["vMenu"] = new SelectList(
                Enumerable.Repeat(new SelectListItem { Value = "", Text = "Selecciona" }, 1)
                .Concat(menuItems),
                "Value",
                "Text"
            );

            var caracteristica = new CaracteristicasService(new HttpClient());
            var caracteristicaLista = await caracteristica.ListarCaracteristicas();
            var caracteristicaCms = new CaracteristicaCmsService(new HttpClient());

            if (id == 0 || caracteristicaLista == null)
            {
                return NotFound();
            }

            var tbIndCaracteristica = await caracteristicaCms.obtenerCaracteristicaDetalle(id);
            if (tbIndCaracteristica == null)
            {
                return NotFound();
            }
            return View(tbIndCaracteristica);
        }

        // POST: Caracteristica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Titulo,Icono,Detalle")] TbIndCaracteristica tbIndCaracteristica)
        {
            var caracteristicaCms = new CaracteristicaCmsService(new HttpClient());
            if (id != tbIndCaracteristica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await caracteristicaCms.modificarCaracteristica(id, tbIndCaracteristica);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbIndCaracteristica);
        }

        // GET: Caracteristica/Delete/5
        public async Task<IActionResult> Delete(uint id)
        {
            var caracteristica = new CaracteristicasService(new HttpClient());
            var caracteristicaLista = await caracteristica.ListarCaracteristicas();
            var caracteristicaCms = new CaracteristicaCmsService(new HttpClient());


            if (id == 0 || caracteristicaLista == null)
            {
                return NotFound();
            }

            var tbIndCaracteristica = await caracteristicaCms.obtenerCaracteristicaDetalle(id);

            if (tbIndCaracteristica == null)
            {
                return NotFound();
            }

            return View(tbIndCaracteristica);
        }

        // POST: Caracteristica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var caracteristica = new CaracteristicasService(new HttpClient());
            var caracteristicaLista = await caracteristica.ListarCaracteristicas();
            var caracteristicaCms = new CaracteristicaCmsService(new HttpClient());

            if (caracteristicaLista == null)
            {
                return Problem("Entity set 'CentralparkingContext.TbIndCaracteristicas'  is null.");
            }
            var tbIndCaracteristica = await caracteristicaCms.obtenerCaracteristicaDetalle(id);
            if (tbIndCaracteristica != null)
            {
                await caracteristicaCms.eliminarCaracteristica(id);
            }


            return RedirectToAction(nameof(Index));
        }


        private List<Icono> getIcons()
        {
            var icons = new List<Icono>();

            icons.Add(new Icono { Class = "fa fa-puzzle-piece", Descripcion = "Icono de una pieza de rompecabezas" });
            icons.Add(new Icono { Class = "fa fa-magic", Descripcion = "Icono de una varita mágica" });
            icons.Add(new Icono { Class = "fa fa-trophy", Descripcion = "Icono de un trofeo" });
            icons.Add(new Icono { Class = "fa fa-arrow-circle-right", Descripcion = "Icono de flecha con direccion a la derecha" });
            return icons;
        }

        private class Icono
        {
            public string Class { get; set; }
            public string Descripcion { get; set; }

        }
    }
}
