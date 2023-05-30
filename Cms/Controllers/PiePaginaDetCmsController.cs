using ApiBD.Models;
using Cms.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class PiePaginaDetCmsController : Controller
    {
        private HelperUploadFiles helperUpload;

        public PiePaginaDetCmsController(HelperUploadFiles helperUpload)
        {
          
            this.helperUpload = helperUpload;
        }
        /*
        // GET: PiePaginaDet
        public async Task<IActionResult> Index(int? codigo)
        {
            if (codigo == null || _context.TbConfPiepaginadets == null)
            {
                return NotFound();
            }
            ViewData["vPiepaginaId"] = codigo;
            return _context.TbConfPiepaginadets != null ?
                          View(await _context.TbConfPiepaginadets.Where(p => p.PiepaginaId == codigo).ToListAsync()) :
                          Problem("Entity set 'CentralparkingContext.TbConfPiepaginadets'  is null.");
        }

        // GET: PiePaginaDet/Details/5
        public async Task<IActionResult> Details(int? id, int? codigo)
        {
            if (id == null || _context.TbConfPiepaginadets == null)
            {
                return NotFound();
            }

            var tbConfPiepaginadet = await _context.TbConfPiepaginadets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbConfPiepaginadet == null)
            {
                return NotFound();
            }
            ViewData["vPiepaginaId"] = codigo;
            return View(tbConfPiepaginadet);
        }

        // GET: PiePaginaDet/Create
        public IActionResult Create(int? codigo)
        {
            ViewData["vPiepaginaId"] = codigo;
            ViewData["PiepaginaId"] = new SelectList(_context.TbConfPiepaginacabs, "Id", "Titulo", codigo);
            return View();
        }

        // POST: PiePaginaDet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PiepaginaId,Icono,Titulo,Ruta,Imagen,TipoRuta")] TbConfPiepaginadet tbConfPiepaginadet)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Form.Files.FirstOrDefault();

                if (file != null)
                {
                    string nombreImagen = file.FileName;
                    string path = "";
                    path = await this.helperUpload.UploadFilesAsync(file, nombreImagen, Providers.Folders.Images);
                    tbConfPiepaginadet.Imagen = "/images/" + nombreImagen;
                }

                _context.Add(tbConfPiepaginadet);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "PiePaginaDet", new { codigo = tbConfPiepaginadet.PiepaginaId });
                //return RedirectToAction(nameof("Index"), nameof("PiePaginaDet"), new { codigo = tbConfPiepaginadet.PiepaginaId });
                //return RedirectToAction(nameof(Index? tbConfPiepaginadet.PiepaginaId));
            }
            return View(tbConfPiepaginadet);
        }

        // GET: PiePaginaDet/Edit/5
        public async Task<IActionResult> Edit(int? id, int? codigo)
        {
            if (id == null || _context.TbConfPiepaginadets == null)
            {
                return NotFound();
            }

            var tbConfPiepaginadet = await _context.TbConfPiepaginadets.FindAsync(id);
            if (tbConfPiepaginadet == null)
            {
                return NotFound();
            }
            ViewData["vPiepaginaId"] = codigo;
            ViewData["PiepaginaId"] = new SelectList(_context.TbConfPiepaginacabs, "Id", "Titulo", codigo);
            return View(tbConfPiepaginadet);
        }

        // POST: PiePaginaDet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PiepaginaId,Icono,Titulo,Ruta,Imagen,TipoRuta")] TbConfPiepaginadet tbConfPiepaginadet)
        {
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
                        path = await this.helperUpload.UploadFilesAsync(file, nombreImagen, Providers.Folders.Images);
                        tbConfPiepaginadet.Imagen = "/images/" + nombreImagen;
                    }

                    _context.Update(tbConfPiepaginadet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbConfPiepaginadetExists(tbConfPiepaginadet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "PiePaginaDet", new { codigo = tbConfPiepaginadet.PiepaginaId });
                //return RedirectToAction(nameof(Index));
            }
            return View(tbConfPiepaginadet);
        }

        // GET: PiePaginaDet/Delete/5
        public async Task<IActionResult> Delete(int? id, int? codigo)
        {
            if (id == null || _context.TbConfPiepaginadets == null)
            {
                return NotFound();
            }

            var tbConfPiepaginadet = await _context.TbConfPiepaginadets
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.TbConfPiepaginadets == null)
            {
                return Problem("Entity set 'CentralparkingContext.TbConfPiepaginadets'  is null.");
            }
            var tbConfPiepaginadet = await _context.TbConfPiepaginadets.FindAsync(id);
            var piepaginaid = tbConfPiepaginadet.PiepaginaId;
            if (tbConfPiepaginadet != null)
            {
                _context.TbConfPiepaginadets.Remove(tbConfPiepaginadet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "PiePaginaDet", new { codigo = piepaginaid });
            //return RedirectToAction(nameof(Index));
        }
        */
    }
}
