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
      
     

        public IServiciosdetCmsController()
        {
           
         
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
        /*
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
                    path = await this.helperUpload.UploadFilesAsync(file, nombreImagen, Providers.Folders.Images);
                    tbIndServiciodet.Imagen = "/images/" + nombreImagen;
                }


                await servicioDet.crearServicioDet(tbIndServiciodet);
                return RedirectToAction("Index", "IserviciosdetCms", new { codigo = tbIndServiciodet.IdCab });
                //return RedirectToAction(nameof(Index));
            }
            ViewData["IdCab"] = new SelectList(servicioCabLista, "Id", "TituloGrande", tbIndServiciodet.IdCab);
            return View(tbIndServiciodet);
        }
        /*
        // GET: IServiciosdet/Edit/5
        public async Task<IActionResult> Edit(int? id, int? codigo)
        {
            if (id == null || _context.TbIndServiciodets == null)
            {
                return NotFound();
            }

            var tbIndServiciodet = await _context.TbIndServiciodets.FindAsync(id);
            if (tbIndServiciodet == null)
            {
                return NotFound();
            }
            ViewData["vServicioId"] = codigo;
            ViewData["IdCab"] = new SelectList(_context.TbIndServiciocabs, "Id", "TituloGrande", tbIndServiciodet.IdCab);
            return View(tbIndServiciodet);
        }

        // POST: IServiciosdet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCab,Icono,Titulo,Detalle,Ruta,Imagen")] TbIndServiciodet tbIndServiciodet)
        {
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
                        path = await this.helperUpload.UploadFilesAsync(file, nombreImagen, Providers.Folders.Images);
                        tbIndServiciodet.Imagen = "/images/" + nombreImagen;
                    }
                    _context.Update(tbIndServiciodet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbIndServiciodetExists(tbIndServiciodet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Iserviciosdet", new { codigo = tbIndServiciodet.IdCab });
                //return RedirectToAction(nameof(Index));
            }
            ViewData["IdCab"] = new SelectList(_context.TbIndServiciocabs, "Id", "TituloGrande", tbIndServiciodet.IdCab);
            return View(tbIndServiciodet);
        }

        // GET: IServiciosdet/Delete/5
        public async Task<IActionResult> Delete(int? id, int? codigo)
        {
            if (id == null || _context.TbIndServiciodets == null)
            {
                return NotFound();
            }

            var tbIndServiciodet = await _context.TbIndServiciodets
                .Include(t => t.IdCabNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.TbIndServiciodets == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbIndServiciodets'  is null.");
            }
            var tbIndServiciodet = await _context.TbIndServiciodets.FindAsync(id);
            var servicioid = tbIndServiciodet.IdCab;
            if (tbIndServiciodet != null)
            {
                _context.TbIndServiciodets.Remove(tbIndServiciodet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Iserviciosdet", new { codigo = servicioid });
            //return RedirectToAction(nameof(Index));
        }

        private bool TbIndServiciodetExists(int id)
        {
            return (_context.TbIndServiciodets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        */
    }
}
