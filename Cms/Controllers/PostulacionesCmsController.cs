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
    public class PostulacionesCmsController : Controller
    {
        PostulacionCmsService _postulacionCmsService;
        private readonly IWebHostEnvironment _env;
        public PostulacionesCmsController(PostulacionCmsService postulacionCmsService, IWebHostEnvironment env)
        {
            _postulacionCmsService = postulacionCmsService;
            _env = env;
        }

        // GET: PostulacionesCms
        public async Task<IActionResult> Index()
        {
            var postulacionLista = await _postulacionCmsService.listarPostulaciones();
            if (postulacionLista.Count == 0)
            {
                TbFormTbcnosotro objPostulacion = new TbFormTbcnosotro();
                postulacionLista.Add(objPostulacion);
                return View(postulacionLista);

            }

            return postulacionLista != null ?
                        View(postulacionLista) :
                        Problem("Entity set 'CentralparkingContext.TbConfRubros'  is null.");
        }

        public IActionResult DownloadArchivo(int id)
        {
            var archivo = _postulacionCmsService.obtenerPostulacionByid(id);

            if (archivo == null)
            {
                return NotFound(); // Retorna 404 si no se encuentra el archivo
            }

            // Construye la ruta del archivo dentro de la carpeta wwwroot/docs
            var filePath = Path.Combine(_env.WebRootPath, "docs", archivo.Result.InformacionAdicional);
            // Obtener la extensión del archivo
            var extension = Path.GetExtension(archivo.Result.InformacionAdicional).ToLowerInvariant();

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); // Retorna 404 si el archivo no existe en la carpeta
            }
            string contentType;
            switch (extension)
            {
                case ".pdf":
                    contentType = "application/pdf";
                    break;
                case ".txt":
                    contentType = "text/plain";
                    break;
                // Añade más casos según las extensiones y tipos de contenido que necesites manejar
                default:
                    contentType = "application/octet-stream"; // Tipo de contenido por defecto si la extensión es desconocida
                    break;
            }
            // Retorna el archivo para su descarga
            return PhysicalFile(filePath, contentType, archivo.Result.InformacionAdicional);
        }
        //// GET: PostulacionesCms/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.TbFormTbcnosotros == null)
        //    {
        //        return NotFound();
        //    }

        //    var tbFormTbcnosotro = await _context.TbFormTbcnosotros
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (tbFormTbcnosotro == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tbFormTbcnosotro);
        //}

        //// GET: PostulacionesCms/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PostulacionesCms/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,TipoDocumento,Nombre,Apellido,FechaNacimiento,CorreoElectronico,Departamento,Provincia,Distrito,Puesto,InformacionAdicional,NumeroDocumento,Celular,Medio")] TbFormTbcnosotro tbFormTbcnosotro)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(tbFormTbcnosotro);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tbFormTbcnosotro);
        //}

        //// GET: PostulacionesCms/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.TbFormTbcnosotros == null)
        //    {
        //        return NotFound();
        //    }

        //    var tbFormTbcnosotro = await _context.TbFormTbcnosotros.FindAsync(id);
        //    if (tbFormTbcnosotro == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(tbFormTbcnosotro);
        //}

        //// POST: PostulacionesCms/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,TipoDocumento,Nombre,Apellido,FechaNacimiento,CorreoElectronico,Departamento,Provincia,Distrito,Puesto,InformacionAdicional,NumeroDocumento,Celular,Medio")] TbFormTbcnosotro tbFormTbcnosotro)
        //{
        //    if (id != tbFormTbcnosotro.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tbFormTbcnosotro);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TbFormTbcnosotroExists(tbFormTbcnosotro.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tbFormTbcnosotro);
        //}

        //// GET: PostulacionesCms/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.TbFormTbcnosotros == null)
        //    {
        //        return NotFound();
        //    }

        //    var tbFormTbcnosotro = await _context.TbFormTbcnosotros
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (tbFormTbcnosotro == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tbFormTbcnosotro);
        //}

        //// POST: PostulacionesCms/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.TbFormTbcnosotros == null)
        //    {
        //        return Problem("Entity set 'CentralParkingContext.TbFormTbcnosotros'  is null.");
        //    }
        //    var tbFormTbcnosotro = await _context.TbFormTbcnosotros.FindAsync(id);
        //    if (tbFormTbcnosotro != null)
        //    {
        //        _context.TbFormTbcnosotros.Remove(tbFormTbcnosotro);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TbFormTbcnosotroExists(int id)
        //{
        //  return _context.TbFormTbcnosotros.Any(e => e.Id == id);
        //}
    }
}
