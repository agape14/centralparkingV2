﻿using ApiBD.Models;
using CentralParkingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class ModaleCmsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var servicio = new ModaleCabeceraService(new HttpClient());
            var lista = await servicio.listarEntrada();
            if (lista.Count == 0)
            {
                return View();
            }
            return View(lista);
        }

        // GET: IServicios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var servicio = new ModaleCabeceraService(new HttpClient());
            var lista = await servicio.listarModalCabecera();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var modal = await servicio.obtenerModalCabeceraDetalle(id);
            if (modal == null)
            {
                return NotFound();
            }

            return View(modal);
        }

        // GET: IServicios/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: IServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbConfModalcab tbConfModalcab)
        {
            var servicio = new ModaleCabeceraService(new HttpClient());

            if (ModelState.IsValid)
            {
                await servicio.crearModalCabRegistro(tbConfModalcab);
                return RedirectToAction(nameof(Index));
            }
            return View(tbConfModalcab);
        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var servicio = new ModaleCabeceraService(new HttpClient());
            var lista = await servicio.listarModalCabecera();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var modal = await servicio.obtenerModalCabeceraDetalle(id);
            if (modal == null)
            {
                return NotFound();
            }
            return View(modal);
        }


        // POST: TbTraPuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TbConfModalcab tbConfModalcab)
        {
            var servicio = new ModaleCabeceraService(new HttpClient());
            var lista = await servicio.listarModalCabecera();


            if (id != tbConfModalcab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await servicio.modificarModalCab(id, tbConfModalcab);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbConfModalcab);
        }

        // GET: TbTraPuesto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var servicio = new ModaleCabeceraService(new HttpClient());
            var lista = await servicio.listarModalCabecera();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var modal = await servicio.obtenerModalCabeceraDetalle(id);
            if (modal == null)
            {
                return NotFound();
            }

            return View(modal);
        }

        // POST: TbTraPuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicio = new ModaleCabeceraService(new HttpClient());
            var lista = await servicio.listarModalCabecera();

            if (lista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
            }
            var modal = await servicio.obtenerModalCabeceraDetalle(id);
            if (modal != null)
            {
                await servicio.eliminarModalCab(id);
            }


            return RedirectToAction(nameof(Index));
        }

    }
}
