using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.Helpers;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class ModaleCmsController : Controller
    {
        private readonly HelperUploadFiles _helperUpload;
        ModaleCabeceraCmsService _modaleCabeceraCmsService;
        MenuCmsService _menuCmsService;
        public ModaleCmsController(HelperUploadFiles helperUpload, ModaleCabeceraCmsService modaleCabeceraCmsService, MenuCmsService menuCmsService)
        {
            _helperUpload = helperUpload;
            _modaleCabeceraCmsService = modaleCabeceraCmsService;
            _menuCmsService = menuCmsService;
        }

        public async Task<IActionResult> Index()
        {
            int idUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0;
            if (idUsuario == 0)
            {
                return RedirectToAction("Index", "DashbordCms");
            }
            //var servicio = new ModaleCabeceraCmsService(new HttpClient());
            var lista = await _modaleCabeceraCmsService.listarEntrada();
            if (lista.Count == 0)
            {
                TbConfPiepaginadet objPiePaginaDet = new TbConfPiepaginadet();
                lista.Add(objPiePaginaDet);
                return View(lista);
            }
            return View(lista);
        }

        // GET: IServicios/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var servicio = new ModaleCabeceraCmsService(new HttpClient());
            var lista = await _modaleCabeceraCmsService.listarModalCabecera();


            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var modal = await _modaleCabeceraCmsService.obtenerModalCabeceraDetalleFijo(id);
            if (modal == null)
            {
                return NotFound();
            }

            return View(modal);
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
        public async Task<IActionResult> Create(TbConfModalcab tbConfModalcab)
        {
            //var servicio = new ModaleCabeceraCmsService(new HttpClient());

            if (ModelState.IsValid)
            {
                await _modaleCabeceraCmsService.crearModalCabRegistro(tbConfModalcab);
                return RedirectToAction(nameof(Index));
            }
            return View(tbConfModalcab);
        }

        // GET: TbTraPuesto/Edit/5
        public async Task<IActionResult> Edit(int id, int tipoRuta)
        {

            //var servicio = new ModaleCabeceraCmsService(new HttpClient());
            var lista = await _modaleCabeceraCmsService.listarModalCabecera();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var modal = await _modaleCabeceraCmsService.obtenerModalCabeceraDetalleFijo(id);
            if (modal == null)
            {
                return NotFound();
            }


            //Listando Menu
            //var menu = new MenuCmsService(new HttpClient());
            var menuLista = await _menuCmsService.listarMenus();
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

            ViewData["TipoRuta"] = tipoRuta;

            return View(modal);
        }


        // POST: TbTraPuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TbConfModalcab tbConfModalcab)
        {
            //var servicio = new ModaleCabeceraCmsService(new HttpClient());
            var lista = await _modaleCabeceraCmsService.listarModalCabecera();
            var modal = await _modaleCabeceraCmsService.obtenerModalCabeceraDetalleFijo(id);

            tbConfModalcab.IdDetallePie = id;
            id = modal.Id;
            tbConfModalcab.Id = modal.Id;
            
            if ( id != tbConfModalcab.Id)
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
                        path = await _helperUpload.UploadFilesAsync(file, nombreImagen, Providers.Folders.Documents);
                        tbConfModalcab.BtnRuta = "/docs/" + nombreImagen;
                    }
                    await _modaleCabeceraCmsService.modificarModalCab(id, tbConfModalcab);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbConfModalcab);
        }

        // GET: TbTraPuesto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //var servicio = new ModaleCabeceraCmsService(new HttpClient());
            var lista = await _modaleCabeceraCmsService.listarModalCabecera();

            if (id == 0 || lista == null)
            {
                return NotFound();
            }

            var modal = await _modaleCabeceraCmsService.obtenerModalCabeceraDetalleFijo(id);
            if (modal == null)
            {
                return NotFound();
            }

            return View(modal);
        }

        // POST: TbTraPuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var servicio = new ModaleCabeceraCmsService(new HttpClient());
            var lista = await _modaleCabeceraCmsService.listarModalCabecera();

            if (lista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbTraPuestos'  is null.");
            }
            
            if (lista != null)
            {
                await _modaleCabeceraCmsService.eliminarModalCab(id);
            }


            return RedirectToAction(nameof(Index));
        }

    }
}
