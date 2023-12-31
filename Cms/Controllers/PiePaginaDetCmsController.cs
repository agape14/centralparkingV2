﻿using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.Helpers;
using Cms.Providers;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;

namespace Cms.Controllers
{
    public class PiePaginaDetCmsController : Controller
    {
        private HelperUploadFiles _helperUpload;

        public PiePaginaDetCmsController(HelperUploadFiles helperUpload)
        {
            _helperUpload = helperUpload;
        }

        // GET: PiePaginaDet
        public async Task<IActionResult> Index(int codigo)
        {
            var piePaginaDet = new PiePaginaDetCmsService(new HttpClient());
            var piePaginaDetLista = await piePaginaDet.listarPiePaginaDet();
            var piePaginaDetPorId = await piePaginaDet.listarPiePaginaDetPorCodigoId(codigo);

            if (codigo == 0 || piePaginaDetLista == null)
            {
                return NotFound();
            }
            ViewData["vPiepaginaId"] = codigo;
            return piePaginaDetLista != null ?
                          View(piePaginaDetPorId) :
                          Problem("Entity set 'CentralparkingContext.TbConfPiepaginadets'  is null.");
        }

        // GET: PiePaginaDet/Details/5
        public async Task<IActionResult> Details(int id, int codigo)
        {
            var piePaginaDet = new PiePaginaDetCmsService(new HttpClient());
            var piePaginaDetLista = await piePaginaDet.listarPiePaginaDet();

            if (id == 0 || piePaginaDetLista == null)
            {
                return NotFound();
            }

            var tbConfPiepaginadet = await piePaginaDet.obtenerPiePaginaDetDetalle(id);
            if (tbConfPiepaginadet == null)
            {
                return NotFound();
            }
            ViewData["vPiepaginaId"] = codigo;
            return View(tbConfPiepaginadet);
        }
        
        // GET: PiePaginaDet/Create
        public async Task<IActionResult> Create(int codigo)
        {
            var piePaginaCabs = new PiePaginaCabsService(new HttpClient());
            var piePaginaCabsLista = await piePaginaCabs.ListarPiePaginasCabs();
            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();
            if (menuLista.Count == 0)
            {
                return NotFound();
            }

            var menuItems = menuLista.Where(m => m.Idtipomenu == 1).Select(m => new SelectListItem
            {
                Value = m.Ruta,
                Text = $"{m.Nombre} - {m.Ruta}"
            });

            ViewData["vMenu"] = new SelectList(
                Enumerable.Repeat(new SelectListItem { Value = "", Text = "Selecciona" }, 1)
                .Concat(menuItems),
                "Value",
                "Text"
            );

            ViewData["vPiepaginaId"] = codigo;
            ViewData["PiepaginaId"] = new SelectList(piePaginaCabsLista, "Id", "Titulo", codigo);
            return View();
        }
        
       // POST: PiePaginaDet/Create
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Create([Bind("Id,PiepaginaId,Icono,Titulo,Ruta,Imagen,TipoRuta")] TbConfPiepaginadet tbConfPiepaginadet)
        {
            var piePaginaDet = new PiePaginaDetCmsService(new HttpClient());

            
            if (ModelState.IsValid)
           {
               var file = Request.Form.Files.FirstOrDefault();

               if (file != null)
               {
                   string nombreImagen = file.FileName;
                   string path = "";
                
                   path = await _helperUpload.UploadFilesAsync(file, nombreImagen, Providers.Folders.Images);
                   tbConfPiepaginadet.Imagen = "/images/" + nombreImagen;
               }


                await piePaginaDet.crearPiePaginaDet(tbConfPiepaginadet);
               return RedirectToAction("Index", "PiePaginaDetCms", new { codigo = tbConfPiepaginadet.PiepaginaId });
              
           }
           return View(tbConfPiepaginadet);
       }

       // GET: PiePaginaDet/Edit/5
       public async Task<IActionResult> Edit(int id, int codigo)
       {
            var piePaginaDet = new PiePaginaDetCmsService(new HttpClient());
            var piePaginaDetLista = await piePaginaDet.listarPiePaginaDet();

            var piePaginaCabs = new PiePaginaCabsService(new HttpClient());
            var piePaginaCabsLista = await piePaginaCabs.ListarPiePaginasCabs();

            var menu = new MenuCmsService(new HttpClient());
            var menuLista = await menu.listarMenus();

            if (id == 0 || piePaginaDetLista == null)
            {
                return NotFound();
            }

            var tbConfPiepaginadet = await piePaginaDet.obtenerPiePaginaDetDetalle(id);
            if (tbConfPiepaginadet == null)
            {
                return NotFound();
            }
            var codigoTipo =  tbConfPiepaginadet.TipoRuta==2 ? tbConfPiepaginadet.TipoRuta:0;

            if (menuLista.Count == 0)
            {
                return NotFound();
            }

            var menuItems = menuLista.Where(m => m.Idtipomenu == 1).Select(m => new SelectListItem
            {
                Value = m.Ruta,
                Text = $"{m.Nombre} - {m.Ruta}"
            });

            ViewData["vMenu"] = new SelectList(
                Enumerable.Repeat(new SelectListItem { Value = "", Text = "Selecciona" }, 1)
                .Concat(menuItems),
                "Value",
                "Text"
            );
            ViewData["vPiepaginaId"] = codigo;
            ViewData["iCodigoTipo"] = codigoTipo;
            ViewData["PiepaginaId"] = new SelectList(piePaginaCabsLista, "Id", "Titulo", codigo);
           return View(tbConfPiepaginadet);
       }
        
       // POST: PiePaginaDet/Edit/5
       // To protect from overposting attacks, enable the specific properties you want to bind to.
       // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(int id, [Bind("Id,PiepaginaId,Icono,Titulo,Ruta,Imagen,TipoRuta")] TbConfPiepaginadet tbConfPiepaginadet)
       {
            var piePaginaDet = new PiePaginaDetCmsService(new HttpClient());

            if (id != tbConfPiepaginadet.Id)
           {
               return NotFound();
           }

           if (ModelState.IsValid)
           {
               try
               {
                   var file = Request.Form.Files.FirstOrDefault();

                   if (file != null)
                   {
                       string nombreImagen = file.FileName;
                       string path = "";
                       path = await _helperUpload.UploadFilesAsync(file, nombreImagen, Providers.Folders.Images);
                       tbConfPiepaginadet.Imagen = "/images/" + nombreImagen;
                   }


                    await piePaginaDet.modificarPiePaginaDet(id, tbConfPiepaginadet);
               }
               catch (DbUpdateConcurrencyException)
               {
                   
                       return NotFound();
                  
               }
               return RedirectToAction("Index", "PiePaginaDetCms", new { codigo = tbConfPiepaginadet.PiepaginaId });
           
           }
           return View(tbConfPiepaginadet);
       }
        
       // GET: PiePaginaDet/Delete/5
       public async Task<IActionResult> Delete(int id, int codigo)
       {

            var piePaginaDet = new PiePaginaDetCmsService(new HttpClient());
            var piePaginaDetLista = await piePaginaDet.listarPiePaginaDet();

            if (id == 0 || piePaginaDetLista == null)
           {
               return NotFound();
           }

            var tbConfPiepaginadet = await piePaginaDet.obtenerPiePaginaDetDetalle(id);
           if (tbConfPiepaginadet == null)
           {
               return NotFound();
           }
           ViewData["vPiepaginaId"] = codigo;
           return View(tbConfPiepaginadet);
       }

       // POST: PiePaginaDet/Delete/5
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> DeleteConfirmed(int id)
       {
            var piePaginaDet = new PiePaginaDetCmsService(new HttpClient());
            var piePaginaDetLista = await piePaginaDet.listarPiePaginaDet();

            if (piePaginaDetLista == null)
           {
               return Problem("Entity set 'CentralparkingContext.TbConfPiepaginadets'  is null.");
           }
           var tbConfPiepaginadet = await piePaginaDet.obtenerPiePaginaDetDetalle(id);
           var piepaginaid = tbConfPiepaginadet.PiepaginaId;
           if (tbConfPiepaginadet != null)
           {
                await piePaginaDet.eliminarPiePaginaDet(id);
           }

          
           return RedirectToAction("Index", "PiePaginaDetCms", new { codigo = piepaginaid });
        
       }
       
    }
}
