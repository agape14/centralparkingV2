using ApiBD.Models;
using Cms.Helpers;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class ServicioCabeceraCmsController : Controller
    {
        private readonly HelperUploadFiles _helperUpload;
        ServicioCabeceraCmsService _servicioCabeceraCmsService;
        ConfBotonesCmsService _confBotonesCmsService;
        public ServicioCabeceraCmsController(HelperUploadFiles helperUpload, ServicioCabeceraCmsService servicioCabeceraCmsService, ConfBotonesCmsService confBotonesCmsService)
        {
            _helperUpload = helperUpload;
            _servicioCabeceraCmsService = servicioCabeceraCmsService;
            _confBotonesCmsService = confBotonesCmsService;
        }


        public async Task<IActionResult> Index()
        {
            //var servicioCabecera = new ServicioCabeceraCmsService(new HttpClient());
            var lista = await _servicioCabeceraCmsService.listarServiciosCabecera();
            if (lista.Count == 0)
            {
                TbServCabecera objServicioCabecera = new TbServCabecera();
                lista.Add(objServicioCabecera);
                return View(lista);
            }

            return View(lista);
        }

        // GET: IServicios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var servicioCabecera = new ServicioCabeceraCmsService(new HttpClient());
            var lista = _servicioCabeceraCmsService.listarServiciosCabecera();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var tbIndServiciocab = await _servicioCabeceraCmsService.obtenerServicioCabecera(id);
            if (tbIndServiciocab == null)
            {
                return NotFound();
            }

            return View(tbIndServiciocab);
        }

        // GET: IServicios/Create
        public async Task<IActionResult> Create()
        {

            //var boton = new ConfBotonesCmsService(new HttpClient());
            var listBotones = await _confBotonesCmsService.listarBotones();
            listBotones.Insert(0, new TbConfBotone { Id = 0, BtnTitulo = "Seleccionar" });


            ViewData["IdBtn1"] = new SelectList(listBotones, "Id", "BtnTitulo");

            return View();
        }

        
        // POST: IServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbServCabecera tbServCabecera)
        {
            //var servicioCms = new ServicioCabeceraCmsService(new HttpClient());
            if (ModelState.IsValid)
            {
                var file = Request.Form.Files.FirstOrDefault();

                if (file != null)
                {
                    string nombreImagen = file.FileName;
                    string path = "";
                    path = await _helperUpload.UploadFilesAsync(file, nombreImagen, Providers.Folders.Images);
                    tbServCabecera.Imagen = "/images/" + nombreImagen;
                }


                await _servicioCabeceraCmsService.crearServicioCabecera(tbServCabecera);
                return RedirectToAction(nameof(Index));
            }
            return View(tbServCabecera);
        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            //var servicioCabecera = new ServicioCabeceraCmsService(new HttpClient());
            var lista = _servicioCabeceraCmsService.listarServiciosCabecera();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }


            var servicio = await _servicioCabeceraCmsService.obtenerServicioCabecera(id);
            if (servicio == null)
            {
                return NotFound();
            }


            //var boton = new ConfBotonesCmsService(new HttpClient());
            var listBotones = await _confBotonesCmsService.listarBotones();
            listBotones.Insert(0, new TbConfBotone { Id = 0, BtnTitulo = "Seleccionar" });
            ViewData["IdBtn1"] = new SelectList(listBotones, "Id", "BtnTitulo");

            return View(servicio);
        }


        // POST: TbTraPuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TbServCabecera tbServCabecera)
        {
            //var servicioCabecera = new ServicioCabeceraCmsService(new HttpClient());
            var lista = _servicioCabeceraCmsService.listarServiciosCabecera();

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
                        tbServCabecera.Imagen = "/images/" + nombreImagen;


                    }

                    await _servicioCabeceraCmsService.modificarServicioCabecera(id, tbServCabecera);
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
            //var servicioCabecera = new ServicioCabeceraCmsService(new HttpClient());
            var lista = await _servicioCabeceraCmsService.listarServiciosCabecera();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var servicio = await _servicioCabeceraCmsService.obtenerServicioCabecera(id);
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
            //var servicioCabecera = new ServicioCabeceraCmsService(new HttpClient());
            var lista = await _servicioCabeceraCmsService.listarServiciosCabecera();

            if (lista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
            }
            var servicio = await _servicioCabeceraCmsService.obtenerServicioCabecera(id);
            if (servicio != null)
            {
                await _servicioCabeceraCmsService.eliminarServicioCabecera(id);
            }


            return RedirectToAction(nameof(Index));
        }

    }
}
