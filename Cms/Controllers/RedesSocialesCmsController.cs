using ApiBD.Models;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class RedesSocialesCmsController : Controller
    {
        RedesSocialesCmsService _redesSocialesCmsService;
        public RedesSocialesCmsController(RedesSocialesCmsService redesSocialesCmsService)
        {

            _redesSocialesCmsService = redesSocialesCmsService;

        }
        // GET: RedesSociales
        public async Task<IActionResult> Index()
        {
            int idUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0;
            if (idUsuario == 0)
            {
                return RedirectToAction("Index", "DashbordCms");
            }
            //var redSocial = new RedesSocialesCmsService(new HttpClient());
            var redSocialLista = await _redesSocialesCmsService.listarRedesSociales();

            if (redSocialLista.Count == 0)
            {
                TbIndRedsocial objRedSocial = new  TbIndRedsocial();
                redSocialLista.Add(objRedSocial);
                return View(redSocialLista);
            }

            return redSocialLista != null ?
                        View(redSocialLista) :
                        Problem("Entity set 'CentralParkingContext.TbIndRedsocials'  is null.");
        }

        // GET: RedesSociales/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var redSocial = new RedesSocialesCmsService(new HttpClient());
            var redSocialLista = await _redesSocialesCmsService.listarRedesSociales();

            if (id == 0 || redSocialLista == null)
            {
                return NotFound();
            }

            var tbIndRedsocial = await _redesSocialesCmsService.obtenerRedSocialDetalle(id);
            if (tbIndRedsocial == null)
            {
                return NotFound();
            }

            return View(tbIndRedsocial);
        }

        // GET: RedesSociales/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: RedesSociales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Clasehead,Ruta,Clasefoot,Icono,Color,Estado")] TbIndRedsocial tbIndRedsocial)
        {
            //var redSocial = new RedesSocialesCmsService(new HttpClient());

            if (ModelState.IsValid)
            {
                await _redesSocialesCmsService.crearRedSocial(tbIndRedsocial);
                return RedirectToAction(nameof(Index));
            }
            return View(tbIndRedsocial);
        }

        // GET: RedesSociales/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //var redSocial = new RedesSocialesCmsService(new HttpClient());
            var redSocialLista = await _redesSocialesCmsService.listarRedesSociales();

            if (id == 0 || redSocialLista == null)
            {
                return NotFound();
            }

            var tbIndRedsocial = await _redesSocialesCmsService.obtenerRedSocialDetalle(id);
            if (tbIndRedsocial == null)
            {
                return NotFound();
            }
            return View(tbIndRedsocial);
        }

        // POST: RedesSociales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Clasehead,Ruta,Clasefoot,Icono,Color,Estado")] TbIndRedsocial tbIndRedsocial)
        {
            //var redSocial = new RedesSocialesCmsService(new HttpClient());
            
            if (id != tbIndRedsocial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _redesSocialesCmsService.modificarRedSocial(id, tbIndRedsocial);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        return NotFound();
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbIndRedsocial);
        }

        // GET: RedesSociales/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //var redSocial = new RedesSocialesCmsService(new HttpClient());
            var redSocialLista = await _redesSocialesCmsService.listarRedesSociales();

            if (id == 0 || redSocialLista == null)
            {
                return NotFound();
            }

            var tbIndRedsocial = await _redesSocialesCmsService.obtenerRedSocialDetalle(id);
            if (tbIndRedsocial == null)
            {
                return NotFound();
            }

            return View(tbIndRedsocial);
        }

        // POST: RedesSociales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var redSocial = new RedesSocialesCmsService(new HttpClient());
            var redSocialLista = await _redesSocialesCmsService.listarRedesSociales();

            if (redSocialLista == null)
            {
                return Problem("Entity set 'CentralParkingContext.TbIndRedsocials'  is null.");
            }
            var tbIndRedsocial = await _redesSocialesCmsService.obtenerRedSocialDetalle(id);
            if (tbIndRedsocial != null)
            {
                await _redesSocialesCmsService.eliminarRedSocial(id);
            }

           
            return RedirectToAction(nameof(Index));
        }

        
    }
}
