using ApiBD.Models;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class EntidadCmsController : Controller
    {
        EntidadCmsService _entidadCmsService;
        public EntidadCmsController(EntidadCmsService entidadCmsService)
        {

            _entidadCmsService = entidadCmsService;

        }
        public async Task<IActionResult> Index()
        {
            int idUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0;
            if (idUsuario == 0)
            {
                return RedirectToAction("Index", "DashbordCms");
            }
            //var entidad = new EntidadCmsService(new HttpClient());
            var entidadLista = await _entidadCmsService.listarEntidades();
            if (entidadLista.Count == 0)
            {
                TbConfEntidad objEntidad = new TbConfEntidad();
                entidadLista.Add(objEntidad);
                return View(entidadLista);
            }

            return entidadLista != null ?
                        View(entidadLista) :
                        Problem("Entity set 'CentralparkingContext.TbConfEntidads'  is null.");
        }

        public async Task<IActionResult> Indexcorreo()
        {
            //var entidad = new EntidadCmsService(new HttpClient());
            var entidadLista = await _entidadCmsService.listarEntidades();
            if (entidadLista.Count == 0)
            {
                TbConfEntidad objEntidad = new TbConfEntidad();
                entidadLista.Add(objEntidad);
                return View(entidadLista);
            }

            return entidadLista != null ?
                        View(entidadLista) :
                        Problem("Entity set 'CentralparkingContext.TbConfEntidads'  is null.");
        }

        // GET: Entidad/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var entidad = new EntidadCmsService(new HttpClient());
            var entidadLista = await _entidadCmsService.listarEntidades();

            if (id == 0 || entidadLista == null)
            {
                return NotFound();
            }

            var tbConfEntidad = await _entidadCmsService.obtenerEntidadDetalle(id);
            if (tbConfEntidad == null)
            {
                return NotFound();
            }

            return View(tbConfEntidad);
        }

        // GET: Entidad/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Entidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NameComercial,Ruc,Direccion,Horario,Telefono,Celular,Correo,Favicon,LogoBlanco,LogoOscuro,LogoMini,RutaPagWeb,RedesSociales")] TbConfEntidad tbConfEntidad)
        {
            //var entidad = new EntidadCmsService(new HttpClient());

            if (ModelState.IsValid)
            {
                await _entidadCmsService.crearEntidad(tbConfEntidad);
                return RedirectToAction(nameof(Index));
            }
            return View(tbConfEntidad);
        }

        // GET: Entidad/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //var entidad = new EntidadCmsService(new HttpClient());
            var entidadLista = await _entidadCmsService.listarEntidades();

            if (id == 0 || entidadLista == null)
            {
                return NotFound();
            }

            var tbConfEntidad = await _entidadCmsService.obtenerEntidadDetalle(id);
            if (tbConfEntidad == null)
            {
                return NotFound();
            }
            return View(tbConfEntidad);
        }

        public async Task<IActionResult> Correo(int id)
        {
            //var entidad = new EntidadCmsService(new HttpClient());
            var entidadLista = await _entidadCmsService.listarEntidades();

            if (id == 0 || entidadLista == null)
            {
                return NotFound();
            }

            var tbConfEntidad = await _entidadCmsService.obtenerEntidadDetalle(id);
            if (tbConfEntidad == null)
            {
                return NotFound();
            }
            return View(tbConfEntidad);
        }

        // POST: Entidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NameComercial,Ruc,Direccion,Horario,Telefono,Celular,Correo,Favicon,LogoBlanco,LogoOscuro,LogoMini,RutaPagWeb,RedesSociales")] TbConfEntidad tbConfEntidad)
        {
            //var entidad = new EntidadCmsService(new HttpClient());
            if (id != tbConfEntidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _entidadCmsService.modificarEntidad(id, tbConfEntidad);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                        return NotFound();
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbConfEntidad);
        }

        // GET: Entidad/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //var entidad = new EntidadCmsService(new HttpClient());
            var entidadLista = await _entidadCmsService.listarEntidades();

            if (id == 0 || entidadLista == null)
            {
                return NotFound();
            }

            var tbConfEntidad = await _entidadCmsService.obtenerEntidadDetalle(id);
            if (tbConfEntidad == null)
            {
                return NotFound();
            }

            return View(tbConfEntidad);
        }

        // POST: Entidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var entidad = new EntidadCmsService(new HttpClient());
            var entidadLista = await _entidadCmsService.listarEntidades();

            if (entidadLista == null)
            {
                return Problem("Entity set 'CentralparkingContext.TbConfEntidads'  is null.");
            }
            var tbConfEntidad = await _entidadCmsService.obtenerEntidadDetalle(id);
            if (tbConfEntidad != null)
            {
                await _entidadCmsService.eliminarEntidad(id);
            }

            
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCorreo(int id, [Bind("Id,Name,NameComercial,Ruc,Direccion,Horario,Telefono,Celular,Correo,Favicon,LogoBlanco,LogoOscuro,LogoMini,RutaPagWeb,RedesSociales,Servidor,Puerto,CorreoNotifica,ClaveNotifica,CorreoConCopia")] TbConfEntidad tbConfEntidad)
        {
            //var entidad = new EntidadCmsService(new HttpClient());
            if (id != tbConfEntidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _entidadCmsService.modificarEntidad(id, tbConfEntidad);
                }
                catch (DbUpdateConcurrencyException)
                {

                    return NotFound();

                }
                return RedirectToAction(nameof(Indexcorreo));
            }
            return View(tbConfEntidad);
        }

    }
}
