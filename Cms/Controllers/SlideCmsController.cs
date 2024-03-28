﻿using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.Helpers;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class SlideCmsController : Controller
    {
        private readonly HelperUploadFiles _helperUpload;
        private readonly CopiarImagenes _helperCopia;
        SlideCmsService _slideCmsService;
        ConfBotonesCmsService _confBotonesCmsService;
        public SlideCmsController(HelperUploadFiles helperUpload, CopiarImagenes helperCopia, SlideCmsService slideCmsService, ConfBotonesCmsService confBotonesCmsService)
        {
            _helperUpload = helperUpload;
            _helperCopia = helperCopia;
            _slideCmsService = slideCmsService;
            _confBotonesCmsService = confBotonesCmsService;
        }

        // GET: Slide
        public async Task<IActionResult> Index()
        {
            int idUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0;
            if (idUsuario == 0)
            {
                return RedirectToAction("Index", "DashbordCms");
            }
            //var slideService = new SlideCmsService(new HttpClient());
            return await _slideCmsService.ListarSlide() != null ?
                        View(await _slideCmsService.ListarSlide()) :
                        Problem("Entity set 'CentralparkingContext.TbIndSlidecabs'  is null.");

        }


        // GET: Slide/Details/5
        public async Task<IActionResult> Details(uint id)
        {
            //var slideService = new SlideCmsService(new HttpClient());
            
            if (id == null)
            {
                return NotFound();
            }
            

            var tbIndSlidecab = await _slideCmsService.GetDetails(id);
            if(tbIndSlidecab == null)
            {
                return NotFound();
            }
            

            return View(tbIndSlidecab);
        }
        
       // GET: Slide/Create
        public async Task<IActionResult> Create()
        {
            //var boton =  new ConfBotonesCmsService(new HttpClient());
            var listBotones = await _confBotonesCmsService.listarBotones();
            ViewData["IdBtn1"] = new SelectList(listBotones, "Id", "BtnTitulo");
            return View();
        }
        
        // POST: Slide/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbIndSlidecab tbIndSlidecab)
        {
            //var boton = new ConfBotonesCmsService(new HttpClient());
            var listBotones = await _confBotonesCmsService.listarBotones();
            //var slide = new SlideCmsService(new HttpClient());
            ViewData["IdBtn1"] = new SelectList(listBotones, "Id", "BtnTitulo", tbIndSlidecab.IdBtn1);
            if (ModelState.IsValid)
            {
                var file = Request.Form.Files.FirstOrDefault();

                if (file != null)
                {
                    string nombreImagen = file.FileName;
                    string path = "";
                   
                    if (file.Length > 1024 * 1024)
                    {
                        // El archivo excede el peso máximo permitido.
                        ModelState.AddModelError("Imagen", "La imagen no debe superar 1MB de tamaño.");
                        return View(tbIndSlidecab);
                    }
                    // Validar las dimensiones.
                    using (var image = System.Drawing.Image.FromStream(file.OpenReadStream()))
                    {
                        if (image.Width != 626 || image.Height != 267)
                        {
                            // Las dimensiones no son las recomendadas.
                            ModelState.AddModelError("Imagen", "La imagen debe tener un tamaño de 626x267 píxeles.");
                            return View(tbIndSlidecab);
                        }
                    }
                    if (nombreImagen != null && nombreImagen.Length > 170)
                    {
                        // Agregar un error al ModelState.
                        ModelState.AddModelError("Imagen", "La imagen no puede tener más de 170 caracteres.");
                        return View(tbIndSlidecab);
                    }
                    path = await _helperUpload.UploadFilesAsync(file, nombreImagen, Providers.Folders.Images);
                    //string path2 = await _helperUpload.UploadFilesWebAsync(file, nombreImagen, Providers.Folders.Images);
                    tbIndSlidecab.Imagen = "/images/" + nombreImagen;
                }
                await _slideCmsService.CreateSlide(tbIndSlidecab);
                _helperCopia.enviaimagen();
                return RedirectToAction(nameof(Index));
            }
            
            return View(tbIndSlidecab);
   
        }
    
        
        // GET: Slide/Edit/5
        public async Task<IActionResult> Edit(uint id)
        {   
            //var slide = new SlideCmsService(new HttpClient());
            var slideList = await _slideCmsService.ListarSlide();
            //var slideCms = new SlideCmsService(new HttpClient());
            //var boton = new ConfBotonesCmsService(new HttpClient());
            var listBotones = await _confBotonesCmsService.listarBotones();
            if (id == 0 || slideList == null)
            {
                return NotFound();
            }

            var tbIndSlidecab = await _slideCmsService.GetDetails(id);
            if (tbIndSlidecab == null)
            {
                return NotFound();
            }

            ViewData["IdBtn1"] = new SelectList(listBotones, "Id", "BtnTitulo", tbIndSlidecab.IdBtn1);

            return View(tbIndSlidecab);
        }


        
        // POST: Slide/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Titulo,Imagen,IdBtn1")] TbIndSlidecab tbIndSlidecab)
        {
            
            //var boton = new ConfBotonesCmsService(new HttpClient());
            var listBotones = await _confBotonesCmsService.listarBotones();
            //var slide = new SlideCmsService(new HttpClient());
            ViewData["IdBtn1"] = new SelectList(listBotones, "Id", "BtnTitulo", tbIndSlidecab.IdBtn1);
            if (id != tbIndSlidecab.Id)
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
                        
                        if (file.Length > 1024 * 1024)
                        {
                            // El archivo excede el peso máximo permitido.
                            ModelState.AddModelError("Imagen", "La imagen no debe superar 1MB de tamaño.");
                            return View(tbIndSlidecab);
                        }
                        // Validar las dimensiones.
                        using (var image = System.Drawing.Image.FromStream(file.OpenReadStream()))
                        {
                            if (image.Width != 626 || image.Height != 267)
                            {
                                // Las dimensiones no son las recomendadas.
                                ModelState.AddModelError("Imagen", "La imagen debe tener un tamaño de 626x267 píxeles.");
                                return View(tbIndSlidecab);
                            }
                        }
                        if (nombreImagen != null && nombreImagen.Length > 170)
                        {
                            // Agregar un error al ModelState.
                            ModelState.AddModelError("Imagen", "La imagen no puede tener más de 170 caracteres.");
                            return View(tbIndSlidecab);
                        }
                        path = await _helperUpload.UploadFilesAsync(file, nombreImagen, Providers.Folders.Images);
                        //string path2 = await _helperUpload.UploadFilesWebAsync(file, nombreImagen, Providers.Folders.Images);
                        tbIndSlidecab.Imagen = "/images/" + nombreImagen;
                    }

                   
                    await _slideCmsService.UpdateSlide(id,tbIndSlidecab);
                    _helperCopia.enviaimagen();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            
            
            return View(tbIndSlidecab);
        }
        
        // GET: Slide/Delete/5
        public async Task<IActionResult> Delete(uint id)
        {
            //var slide = new SlideCmsService(new HttpClient());
            var slideList = await _slideCmsService.ListarSlide();
            //var slideCms = new SlideCmsService(new HttpClient());
            if (id == 0 || slideList  == null)
            {
                return NotFound();
            }

            var tbIndSlidecab = await _slideCmsService.GetDetails(id);
            if (tbIndSlidecab == null)
            {
                return NotFound();
            }

            return View(tbIndSlidecab);
        }

        // POST: Slide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            //var slide = new SlideCmsService(new HttpClient());
            var slideList = await _slideCmsService.ListarSlide();
            //var slideCms = new SlideCmsService(new HttpClient());
            if (slideList == null)
            {
                return Problem("Entity set 'CentralparkingContext.TbIndSlidecabs'  is null.");
            }
           
            if (id != 0)
            {
                await _slideCmsService.DeleteSlide(id);
            }

         
            return RedirectToAction(nameof(Index));
        }
        
    }
}
