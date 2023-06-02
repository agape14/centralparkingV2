using ApiBD.Models;
using CentralParkingSystem.DTOs;
using CentralParkingSystem.Services;
using Cms.Helpers;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class IServiciosdetCmsController : Controller
    {
        private readonly HelperUploadFiles _helperUpload;

        public IServiciosdetCmsController(HelperUploadFiles helperUpload)
        {
                _helperUpload = helperUpload;
        }
        
        // GET: IServiciosdet
        public async Task<IActionResult> Index(int codigo)
        {
            var servicioDet = new ServiciosdetsService(new HttpClient());
            var servicioDetLista = await servicioDet.ListarServiciosdets();
            var servicioDetCms = new IServiciodetCmsService(new HttpClient());
            var servicioDetCmsLista = await servicioDetCms.filtrarPorCodigo(codigo);

            if (codigo == 0 || servicioDetLista == null)
            {
                return NotFound();
            }
            ViewData["vServicioId"] = codigo;
            return servicioDetLista != null ?
                          View(servicioDetCmsLista) :
                          Problem("Entity set 'CentralparkingContext.TbIndServiciodets'  is null.");
        }
        
        // GET: IServiciosdet/Details/5
        public async Task<IActionResult> Details(int id, int codigo)
        {
            var servicioDet = new ServiciosdetsService(new HttpClient());
            var servicioDetLista = await servicioDet.ListarServiciosdets();
            var servicioDetCms = new IServiciodetCmsService(new HttpClient());


            if (id == 0 || servicioDetLista == null)
            {
                return NotFound();
            }

            var tbIndServiciodet = await servicioDetCms.obtenerServicioDetDetalle(id,codigo);

            if (tbIndServiciodet == null)
            {
                return NotFound();
            }
            ViewData["vServicioId"] = codigo;
            return View(tbIndServiciodet);
        }
        
        // GET: IServiciosdet/Create
        public async Task<IActionResult> Create(int? codigo)
        {
            var servicioCab = new ServiciosCabsService(new HttpClient());
            var servicioCabLista = await servicioCab.ListarServiciosCabs();
            ViewData["vServicioId"] = codigo;
            ViewData["IdCab"] = new SelectList(servicioCabLista, "Id", "TituloGrande");
            return View();
        }
        
        // POST: IServiciosdet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdCab,Icono,Titulo,Detalle,Ruta,Imagen")] TbIndServiciodet tbIndServiciodet)
        {
            var servicioCab = new ServiciosCabsService(new HttpClient());
            var servicioCabLista = await servicioCab.ListarServiciosCabs();
            var servicioDet = new IServiciodetCmsService(new HttpClient());

         

            if (ModelState.IsValid)
            {
                var file = Request.Form.Files.FirstOrDefault();

                if (file != null)
                {
                    string nombreImagen = file.FileName;
                    string path = "";
                    path = await _helperUpload.UploadFilesAsync(file, nombreImagen, Providers.Folders.Images);
                    tbIndServiciodet.Imagen = "/images/" + nombreImagen;
                }


                await servicioDet.crearServicioDet(tbIndServiciodet);
                return RedirectToAction("Index", "IserviciosdetCms", new { codigo = tbIndServiciodet.IdCab });
         
            }
            ViewData["IdCab"] = new SelectList(servicioCabLista, "Id", "TituloGrande", tbIndServiciodet.IdCab);
            return View(tbIndServiciodet);
        }
        
        // GET: IServiciosdet/Edit/5
        public async Task<IActionResult> Edit(int id, int codigo)
        {
            var servicioDet = new ServiciosdetsService(new HttpClient());
            var servicioDetLista = await servicioDet.ListarServiciosdets();
            var servicioDetCms = new IServiciodetCmsService(new HttpClient());

            var servicioCab = new ServiciosCabsService(new HttpClient());
            var servicioCabLista = await servicioCab.ListarServiciosCabs();


            if (id == 0 || servicioDetLista == null)
            {
                return NotFound();
            }

            var tbIndServiciodet = await servicioDetCms.obtenerServicioDeEspecificoDetalle(id);
            if (tbIndServiciodet == null)
            {
                return NotFound();
            }
            ViewData["vServicioId"] = codigo;
            ViewData["IdCab"] = new SelectList(servicioCabLista, "Id", "TituloGrande", tbIndServiciodet.IdCab);
            return View(tbIndServiciodet);
        }

        // POST: IServiciosdet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCab,Icono,Titulo,Detalle,Ruta,Imagen")] TbIndServiciodet tbIndServiciodet)
        {
            var servicioDetCms = new IServiciodetCmsService(new HttpClient());

            var servicioCab = new ServiciosCabsService(new HttpClient());
            var servicioCabLista = await servicioCab.ListarServiciosCabs();

            if (id != tbIndServiciodet.Id)
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
                        tbIndServiciodet.Imagen = "/images/" + nombreImagen;
                    }
                    
                    await servicioDetCms.modificarServicioDet(id,tbIndServiciodet) ;
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        return NotFound();
                   
                }
                return RedirectToAction("Index", "IserviciosdetCms", new { codigo = tbIndServiciodet.IdCab });
              
            }
            ViewData["IdCab"] = new SelectList(servicioCabLista, "Id", "TituloGrande", tbIndServiciodet.IdCab);
            return View(tbIndServiciodet);
        }

        // GET: IServiciosdet/Delete/5
        public async Task<IActionResult> Delete(int id, int codigo)
        {
            var servicioDet = new ServiciosdetsService(new HttpClient());
            var servicioDetLista = await servicioDet.ListarServiciosdets();
            var servicioDetCms = new IServiciodetCmsService(new HttpClient());

            if (id == 0 || servicioDetLista == null)
            {
                return NotFound();
            }

            var tbIndServiciodet = await servicioDetCms.obtenerServicioDetDetalle(id, codigo);
            if (tbIndServiciodet == null)
            {
                return NotFound();
            }
            ViewData["vServicioId"] = codigo;
            return View(tbIndServiciodet);
        }

        // POST: IServiciosdet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicioDet = new ServiciosdetsService(new HttpClient());
            var servicioDetLista = await servicioDet.ListarServiciosdets();
            var servicioDetCms = new IServiciodetCmsService(new HttpClient());

            if (servicioDetLista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbIndServiciodets'  is null.");
            }
            var tbIndServiciodet = await servicioDetCms.obtenerServicioDeEspecificoDetalle(id);
            var servicioid = tbIndServiciodet.IdCab;
            if (tbIndServiciodet != null)
            {
                await servicioDetCms.eliminarServicioDet(id);
            }

            
            return RedirectToAction("Index", "IserviciosdetCms", new { codigo = servicioid });
         
        }

       
    }
}
