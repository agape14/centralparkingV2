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
        IServiciodetCmsService _serviciodetCmsService;
        ServicioCabeceraCmsService _servicioCabeceraCmsService;
        MenuCmsService _menuCmsService;
        public IServiciosdetCmsController(HelperUploadFiles helperUpload, IServiciodetCmsService serviciodetCmsService, MenuCmsService menuCmsService,
            ServicioCabeceraCmsService servicioCabeceraCmsService)
        {
            _helperUpload = helperUpload;
            _serviciodetCmsService=serviciodetCmsService;
            _menuCmsService = menuCmsService;
            _servicioCabeceraCmsService= servicioCabeceraCmsService;
        }
        
        // GET: IServiciosdet
        public async Task<IActionResult> Index(int codigo)
        {
            //var servicioDet = new IServiciodetCmsService(new HttpClient());
          

            var servicioDetLista = await _serviciodetCmsService.ListarServiciosdets();
            //var servicioDetCms = new IServiciodetCmsService(new HttpClient());
            var servicioDetCmsLista = await _serviciodetCmsService.filtrarPorCodigo(codigo);
            

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
            //var servicioDet = new IServiciodetCmsService(new HttpClient());
            var servicioDetLista = await _serviciodetCmsService.ListarServiciosdets();
            //var servicioDetCms = new IServiciodetCmsService(new HttpClient());


            if (id == 0 || servicioDetLista == null)
            {
                return NotFound();
            }

            var tbIndServiciodet = await _serviciodetCmsService.obtenerServicioDetDetalle(id,codigo);

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
            //var servicioCab = new ServicioCabeceraCmsService(new HttpClient());
            var servicioCabLista = await _servicioCabeceraCmsService.ListarServiciosCabs();
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();
            if (menuLista.Count == 0)
            {
                return NotFound();
            }
            ViewData["vMenu"] = new SelectList(menuLista.Where(m => m.Idtipomenu == 1).Select(m => new SelectListItem
            {
                Value = m.Ruta,
                Text = $"{m.Nombre} - {m.Ruta}"
            }), "Value", "Text");
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
            //var servicioCab = new ServicioCabeceraCmsService(new HttpClient());
            var servicioCabLista = await _servicioCabeceraCmsService.ListarServiciosCabs();
            //var servicioDet = new IServiciodetCmsService(new HttpClient());

         

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


                await _serviciodetCmsService.crearServicioDet(tbIndServiciodet);
                return RedirectToAction("Index", "IserviciosdetCms", new { codigo = tbIndServiciodet.IdCab });
         
            }
            ViewData["IdCab"] = new SelectList(servicioCabLista, "Id", "TituloGrande", tbIndServiciodet.IdCab);
            return View(tbIndServiciodet);
        }
        
        // GET: IServiciosdet/Edit/5
        public async Task<IActionResult> Edit(int id, int codigo)
        {
            //var servicioDet = new IServiciodetCmsService(new HttpClient());
            var servicioDetLista = await _serviciodetCmsService.ListarServiciosdets();
            //var servicioDetCms = new IServiciodetCmsService(new HttpClient());

            //var servicioCab = new ServicioCabeceraCmsService(new HttpClient());
            var servicioCabLista = await _servicioCabeceraCmsService.ListarServiciosCabs();

            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();

            if (id == 0 || servicioDetLista == null)
            {
                return NotFound();
            }

            var tbIndServiciodet = await _serviciodetCmsService.obtenerServicioDeEspecificoDetalle(id);
            if (tbIndServiciodet == null)
            {
                return NotFound();
            }
            if (menuLista.Count == 0)
            {
                return NotFound();
            }

            ViewData["vMenu"] = new SelectList(menuLista.Where(m => m.Idtipomenu == 1).Select(m => new SelectListItem
            {
                Value = m.Ruta,
                Text = $"{m.Nombre} - {m.Ruta}"
            }), "Value", "Text");


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
            //var servicioDetCms = new IServiciodetCmsService(new HttpClient());

            //var servicioCab = new ServicioCabeceraCmsService(new HttpClient());
            var servicioCabLista = await _servicioCabeceraCmsService.ListarServiciosCabs();
            ViewData["vServicioId"] = tbIndServiciodet.IdCab;
            ViewData["IdCab"] = new SelectList(servicioCabLista, "Id", "TituloGrande", tbIndServiciodet.IdCab);
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

                        if (file.Length > 1024 * 1024)
                        {
                            // El archivo excede el peso máximo permitido.
                            ModelState.AddModelError("Imagen", "La imagen no debe superar 1MB de tamaño.");
                            return View(tbIndServiciodet);
                        }
                        // Validar las dimensiones.
                        using (var image = System.Drawing.Image.FromStream(file.OpenReadStream()))
                        {
                            if (image.Width != 1800 || image.Height != 1200)
                            {
                                // Las dimensiones no son las recomendadas.
                                ModelState.AddModelError("Imagen", "La imagen debe tener un tamaño de 1800x1200 píxeles.");
                                return View(tbIndServiciodet);
                            }
                        }
                        if (nombreImagen != null && nombreImagen.Length > 240)
                        {
                            // Agregar un error al ModelState.
                            ModelState.AddModelError("Imagen", "La imagen no puede tener más de 240 caracteres.");
                            return View(tbIndServiciodet);
                        }


                        path = await _helperUpload.UploadFilesAsync(file, nombreImagen, Providers.Folders.Images);
                        //string path2 = await _helperUpload.UploadFilesWebAsync(file, nombreImagen, Providers.Folders.Images);
                        tbIndServiciodet.Imagen = "/images/" + nombreImagen;
                    }
                    
                    await _serviciodetCmsService.modificarServicioDet(id,tbIndServiciodet) ;
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        return NotFound();
                   
                }
                return RedirectToAction("Index", "IserviciosdetCms", new { codigo = tbIndServiciodet.IdCab });
              
            }
            
            return View(tbIndServiciodet);
        }

        // GET: IServiciosdet/Delete/5
        public async Task<IActionResult> Delete(int id, int codigo)
        {
            //var servicioDet = new IServiciodetCmsService(new HttpClient());
            var servicioDetLista = await _serviciodetCmsService.ListarServiciosdets();
            //var servicioDetCms = new IServiciodetCmsService(new HttpClient());

            if (id == 0 || servicioDetLista == null)
            {
                return NotFound();
            }

            var tbIndServiciodet = await _serviciodetCmsService.obtenerServicioDetDetalle(id, codigo);
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
            //var servicioDet = new IServiciodetCmsService(new HttpClient());
            var servicioDetLista = await _serviciodetCmsService.ListarServiciosdets();
            //var servicioDetCms = new IServiciodetCmsService(new HttpClient());

            if (servicioDetLista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbIndServiciodets'  is null.");
            }
            var tbIndServiciodet = await _serviciodetCmsService.obtenerServicioDeEspecificoDetalle(id);
            var servicioid = tbIndServiciodet.IdCab;
            if (tbIndServiciodet != null)
            {
                await _serviciodetCmsService.eliminarServicioDet(id);
            }

            
            return RedirectToAction("Index", "IserviciosdetCms", new { codigo = servicioid });
         
        }

       
    }
}
