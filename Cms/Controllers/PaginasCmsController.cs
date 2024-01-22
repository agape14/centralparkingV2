using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.Helpers;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class PaginasCmsController : Controller
    {
        private readonly HelperUploadFiles _helperUpload;
        PaginasCmsService _paginasCmsService;
        public PaginasCmsController(HelperUploadFiles helperUpload, PaginasCmsService paginasCmsService)
        {
            _helperUpload = helperUpload;
            _paginasCmsService = paginasCmsService;
        }
        // GET: Paginas
        public async Task<IActionResult> Index()
        {
            //var paginaCabs = new PaginasCmsService(new HttpClient());
            var paginaCabsLista = await _paginasCmsService.paginasListar();

            if(paginaCabsLista.Count == 0)
            {
                TbConfPaginascab objPaginasCab = new TbConfPaginascab();
                paginaCabsLista.Add(objPaginasCab);
                return View(paginaCabsLista);
            }

            return paginaCabsLista != null ?
                        View(paginaCabsLista) :
                        Problem("Entity set 'CentralParkingContext.TbConfPaginascabs'  is null.");
        }
      
        // GET: Paginas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var paginaCabs = new PaginasCmsService(new HttpClient());
            var paginaCabsLista = await _paginasCmsService.paginasListar();
            if (id == 0 || paginaCabsLista == null)
            {
                return NotFound();
            }

            var tbConfPaginascab = await _paginasCmsService.obtenerPaginaDetalle(id);

            if (tbConfPaginascab == null)
            {
                return NotFound();
            }

            return View(tbConfPaginascab);
        }

        // GET: Paginas/Create
        public IActionResult Create()
        {
            return View();
        }
        
      // POST: Paginas/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("Id,Titulo,Subtitulo,ReseniaTitulo,ReseniaDetalle,MisionTitulo,MisionDetalle,VisionTitulo,VisionDetalle,ValoresTitulo,ValoresDetalle,ReconocTitulo,ReconocDetalle,ImagenMision,ImagenValores")] TbConfPaginascab tbConfPaginascab)
      {
            //var paginaCabs = new PaginasCmsService(new HttpClient());
            if (ModelState.IsValid)
          {
                var file1 = Request.Form.Files?[0];

                if (file1 != null)
                {
                    string nombreImagen = file1.FileName;
                    string path = "";
                    path = await _helperUpload.UploadFilesAsync(file1, nombreImagen, Providers.Folders.Images);
                    tbConfPaginascab.ImagenMision = "/images/" + nombreImagen;
                }

                var file2 = Request.Form.Files?[1];

                if (file2 != null)
                {
                    string nombreImagen = file2.FileName;
                    string path = "";
                    path = await _helperUpload.UploadFilesAsync(file2, nombreImagen, Providers.Folders.Images);
                    tbConfPaginascab.ImagenValores = "/images/" + nombreImagen;
                }

                await _paginasCmsService.crearPagina(tbConfPaginascab);
              return RedirectToAction(nameof(Index));
          }
          return View(tbConfPaginascab);
      }
    
      // GET: Paginas/Edit/5
      public async Task<IActionResult> Edit(int id)
      {
            //var paginaCabs = new PaginasCmsService(new HttpClient());
            var paginaCabsLista = await _paginasCmsService.paginasListar();

            if (id == 0 || paginaCabsLista == null)
          {
              return NotFound();
          }

          var tbConfPaginascab = await _paginasCmsService.obtenerPaginaDetalle(id);
          if (tbConfPaginascab == null)
          {
              return NotFound();
          }
          return View(tbConfPaginascab);
      }

      // POST: Paginas/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Subtitulo,ReseniaTitulo,ReseniaDetalle,MisionTitulo,MisionDetalle,VisionTitulo,VisionDetalle,ValoresTitulo,ValoresDetalle,ReconocTitulo,ReconocDetalle,ImagenMision,ImagenValores")] TbConfPaginascab tbConfPaginascab)
      {
          //var paginaCabs = new PaginasCmsService(new HttpClient());
          if (id != tbConfPaginascab.Id)
          {
              return NotFound();
          }

          if (ModelState.IsValid)
          {
              try
              {
                    if (Request.Form.Files != null && Request.Form.Files.Count > 0)
                    {
                        if (Request.Form.Files.Count == 1)
                        {
                            var file1 = Request.Form.Files?[0];
                            if (file1.Name== "ImagenMisionNueva")
                            {
                                string nombreImagen1 = file1.FileName;
                                if (file1.Length > 1024 * 1024)
                                {
                                    // El archivo excede el peso máximo permitido.
                                    ModelState.AddModelError("ImagenMision", "La imagen no debe superar 1MB de tamaño.");
                                    return View(tbConfPaginascab);
                                }
                                // Validar las dimensiones.
                                using (var image1 = System.Drawing.Image.FromStream(file1.OpenReadStream()))
                                {
                                    if (image1.Width != 1140 || image1.Height != 712)
                                    {
                                        // Las dimensiones no son las recomendadas.
                                        ModelState.AddModelError("ImagenMision", "La imagen debe tener un tamaño de 1140x712 píxeles.");
                                        return View(tbConfPaginascab);
                                    }
                                }
                                if (nombreImagen1 != null && nombreImagen1.Length > 240)
                                {
                                    // Agregar un error al ModelState.
                                    ModelState.AddModelError("ImagenMision", "La imagen no puede tener más de 240 caracteres.");
                                    return View(tbConfPaginascab);
                                }
                                string path1 = await _helperUpload.UploadFilesAsync(file1, nombreImagen1, Providers.Folders.Images);
                                //string path11 = await _helperUpload.UploadFilesWebAsync(file1, nombreImagen1, Providers.Folders.Images);
                                tbConfPaginascab.ImagenMision = "/images/" + nombreImagen1;
                            }
                            else if (file1.Name == "ImagenValoresNueva")
                            {
                                string nombreImagen2 = file1.FileName;
                                if (file1.Length > 1024 * 1024)
                                {
                                    // El archivo excede el peso máximo permitido.
                                    ModelState.AddModelError("ImagenValores", "La imagen no debe superar 1MB de tamaño.");
                                    return View(tbConfPaginascab);
                                }
                                // Validar las dimensiones. 
                                using (var image2 = System.Drawing.Image.FromStream(file1.OpenReadStream()))
                                {
                                    if (image2.Width != 1140 || image2.Height != 712)
                                    {
                                        // Las dimensiones no son las recomendadas.
                                        ModelState.AddModelError("ImagenValores", "La imagen debe tener un tamaño de 1140x712 píxeles.");
                                        return View(tbConfPaginascab);
                                    }
                                }
                                if (nombreImagen2 != null && nombreImagen2.Length > 240)
                                {
                                    // Agregar un error al ModelState.
                                    ModelState.AddModelError("ImagenValores", "La imagen no puede tener más de 240 caracteres.");
                                    return View(tbConfPaginascab);
                                }
                                string path2 = await _helperUpload.UploadFilesAsync(file1, nombreImagen2, Providers.Folders.Images);
                                //string path22 = await _helperUpload.UploadFilesWebAsync(file1, nombreImagen2, Providers.Folders.Images);
                                tbConfPaginascab.ImagenValores = "/images/" + nombreImagen2;
                            }
                        }else if (Request.Form.Files.Count == 2)
                        {
                            var file1 = Request.Form.Files?[0];

                            if (file1 != null)
                            {
                                string nombreImagen1 = file1.FileName;
                                if (file1.Length > 1024 * 1024)
                                {
                                    // El archivo excede el peso máximo permitido.
                                    ModelState.AddModelError("ImagenMision", "La imagen no debe superar 1MB de tamaño.");
                                    return View(tbConfPaginascab);
                                }
                                // Validar las dimensiones.
                                using (var image1 = System.Drawing.Image.FromStream(file1.OpenReadStream()))
                                {
                                    if (image1.Width != 1140 || image1.Height != 712)
                                    {
                                        // Las dimensiones no son las recomendadas.
                                        ModelState.AddModelError("ImagenMision", "La imagen debe tener un tamaño de 1140x712 píxeles.");
                                        return View(tbConfPaginascab);
                                    }
                                }
                                if (nombreImagen1 != null && nombreImagen1.Length > 240)
                                {
                                    // Agregar un error al ModelState.
                                    ModelState.AddModelError("ImagenMision", "La imagen no puede tener más de 240 caracteres.");
                                    return View(tbConfPaginascab);
                                }
                                string path1 = await _helperUpload.UploadFilesAsync(file1, nombreImagen1, Providers.Folders.Images);
                                //string path11 = await _helperUpload.UploadFilesWebAsync(file1, nombreImagen1, Providers.Folders.Images);
                                tbConfPaginascab.ImagenMision = "/images/" + nombreImagen1;
                            }

                            var file2 = Request.Form.Files?[1];

                            if (file2 != null)
                            {
                                string nombreImagen2 = file2.FileName;
                                if (file2.Length > 1024 * 1024)
                                {
                                    // El archivo excede el peso máximo permitido.
                                    ModelState.AddModelError("ImagenValores", "La imagen no debe superar 1MB de tamaño.");
                                    return View(tbConfPaginascab);
                                }
                                // Validar las dimensiones. 
                                using (var image2 = System.Drawing.Image.FromStream(file2.OpenReadStream()))
                                {
                                    if (image2.Width != 1140 || image2.Height != 712)
                                    {
                                        // Las dimensiones no son las recomendadas.
                                        ModelState.AddModelError("ImagenValores", "La imagen debe tener un tamaño de 1140x712 píxeles.");
                                        return View(tbConfPaginascab);
                                    }
                                }
                                if (nombreImagen2 != null && nombreImagen2.Length > 240)
                                {
                                    // Agregar un error al ModelState.
                                    ModelState.AddModelError("ImagenValores", "La imagen no puede tener más de 240 caracteres.");
                                    return View(tbConfPaginascab);
                                }
                                string path2 = await _helperUpload.UploadFilesAsync(file2, nombreImagen2, Providers.Folders.Images);
                                //string path22 = await _helperUpload.UploadFilesWebAsync(file1, nombreImagen2, Providers.Folders.Images);
                                tbConfPaginascab.ImagenValores = "/images/" + nombreImagen2;
                            }

                        }



                    }

                    await _paginasCmsService.modificarPagina(id, tbConfPaginascab);
                }
              catch (DbUpdateConcurrencyException)
              {
                  
                      return NotFound();
                  
              }
                
                return RedirectToAction(nameof(Index));
          }
          return View(tbConfPaginascab);
      }
      
      // GET: Paginas/Delete/5
      public async Task<IActionResult> Delete(int id)
      {
            //var paginaCabs = new PaginasCmsService(new HttpClient());
            var paginaCabsLista = await _paginasCmsService.paginasListar();

            if (id == 0 || paginaCabsLista == null)
          {
              return NotFound();
          }

          var tbConfPaginascab = await _paginasCmsService.obtenerPaginaDetalle(id);
          if (tbConfPaginascab == null)
          {
              return NotFound();
          }

          return View(tbConfPaginascab);
      }

      // POST: Paginas/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
            //var paginaCabs = new PaginasCmsService(new HttpClient());
            var paginaCabsLista = await _paginasCmsService.paginasListar();

            if (paginaCabsLista == null)
          {
              return Problem("Entity set 'CentralParkingContext.TbConfPaginascabs'  is null.");
          }
          var tbConfPaginascab = await _paginasCmsService.obtenerPaginaDetalle(id);
          if (tbConfPaginascab != null)
          {
                await _paginasCmsService.eliminarPagina(id);
          }

       
          return RedirectToAction(nameof(Index));
      }
    
    }
}