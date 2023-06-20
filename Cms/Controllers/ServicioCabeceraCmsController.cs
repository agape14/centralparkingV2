using ApiBD.Models;
using Cms.Helpers;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class ServicioCabeceraCmsController : Controller
    {
        private readonly HelperUploadFiles _helperUpload;

        public ServicioCabeceraCmsController(HelperUploadFiles helperUpload)
        {
            _helperUpload = helperUpload;
        }


        public async Task<IActionResult> Index()
        {
            var servicioCabecera = new ServicioCabeceraCmsService(new HttpClient());
            var lista = await servicioCabecera.listarServiciosCabecera();
            if (lista.Count == 0)
            {
                return View();
            }
            return View(lista);
        }

        // GET: IServicios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var servicioCabecera = new ServicioCabeceraCmsService(new HttpClient());
            var lista = servicioCabecera.listarServiciosCabecera();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var tbIndServiciocab = await servicioCabecera.obtenerServicioCabecera(id);
            if (tbIndServiciocab == null)
            {
                return NotFound();
            }

            return View(tbIndServiciocab);
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
        public async Task<IActionResult> Create(TbServCabecera tbServCabecera)
        {
            var servicioCms = new ServicioCabeceraCmsService(new HttpClient());
            if (ModelState.IsValid)
            {
                var file = Request.Form.Files.FirstOrDefault();

                if (file != null)
                {
                    string nombreImagen = file.FileName;
                    string path = "";
                    path = await _helperUpload.UploadFilesAsync(file, nombreImagen, Providers.Folders.Images);
                    tbServCabecera.Imagen = "images/" + nombreImagen;
                }


                await servicioCms.crearServicioCabecera(tbServCabecera);
                return RedirectToAction(nameof(Index));
            }
            return View(tbServCabecera);
        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var servicioCabecera = new ServicioCabeceraCmsService(new HttpClient());
            var lista = servicioCabecera.listarServiciosCabecera();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }


            var servicio = await servicioCabecera.obtenerServicioCabecera(id);
            if (servicio == null)
            {
                return NotFound();
            }
            return View(servicio);
        }


        // POST: TbTraPuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TbServCabecera tbServCabecera)
        {
            var servicioCabecera = new ServicioCabeceraCmsService(new HttpClient());
            var lista = servicioCabecera.listarServiciosCabecera();

            if (id != tbServCabecera.Id)
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
                        tbServCabecera.Imagen = "images/" + nombreImagen;


                    }

                    await servicioCabecera.modificarServicioCabecera(id, tbServCabecera);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbServCabecera);
        }

        // GET: TbTraPuesto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var servicioCabecera = new ServicioCabeceraCmsService(new HttpClient());
            var lista = await servicioCabecera.listarServiciosCabecera();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var servicio = await servicioCabecera.obtenerServicioCabecera(id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // POST: TbTraPuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicioCabecera = new ServicioCabeceraCmsService(new HttpClient());
            var lista = await servicioCabecera.listarServiciosCabecera();

            if (lista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
            }
            var servicio = await servicioCabecera.obtenerServicioCabecera(id);
            if (servicio != null)
            {
                await servicioCabecera.eliminarServicioCabecera(id);
            }


            return RedirectToAction(nameof(Index));
        }

    }
}
