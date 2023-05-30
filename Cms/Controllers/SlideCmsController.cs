using ApiBD.Models;
using CentralParkingSystem.Services;
using Cms.ServiceCms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cms.Controllers
{
    public class SlideCmsController : Controller
    {


        // GET: Slide
        public async Task<IActionResult> Index()
        {
            var slideService = new SlideService(new HttpClient());
            return await slideService.ListarSlide() != null ?
                        View(await slideService.ListarSlide()) :
                        Problem("Entity set 'CentralparkingContext.TbIndSlidecabs'  is null.");

        }


        // GET: Slide/Details/5
        public async Task<IActionResult> Details(uint id)
        {
            var slideService = new SlideCmsService(new HttpClient());
            
            if (id == null)
            {
                return NotFound();
            }
            

            var tbIndSlidecab = await slideService.GetDetails(id);
            if(tbIndSlidecab == null)
            {
                return NotFound();
            }
            

            return View(tbIndSlidecab);
        }
        
       // GET: Slide/Create
        public async Task<IActionResult> Create()
        {
            var boton =  new ConfBotonesCmsService(new HttpClient());
            var listBotones = await boton.listarBotones();
            ViewData["IdBtn1"] = new SelectList(listBotones, "Id", "BtnTitulo");
            return View();
        }
        
        // POST: Slide/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Imagen,IdBtn1")] TbIndSlidecab tbIndSlidecab)
        {
            var boton = new ConfBotonesCmsService(new HttpClient());
            var listBotones = await boton.listarBotones();
            var slide = new SlideCmsService(new HttpClient());
            if (ModelState.IsValid)
            {
                await slide.CreateSlide(tbIndSlidecab);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBtn1"] = new SelectList(listBotones, "Id", "BtnTitulo", tbIndSlidecab.IdBtn1);

            return View(tbIndSlidecab);
   
        }
    
        
        // GET: Slide/Edit/5
        public async Task<IActionResult> Edit(uint id)
        {   
            var slide = new SlideService(new HttpClient());
            var slideList = await slide.ListarSlide();
            var slideCms = new SlideCmsService(new HttpClient());
            var boton = new ConfBotonesCmsService(new HttpClient());
            var listBotones = await boton.listarBotones();
            if (id == 0 || slideList == null)
            {
                return NotFound();
            }

            var tbIndSlidecab = await slideCms.GetDetails(id);
            if (tbIndSlidecab == null)
            {
                return NotFound();
            }

            ViewData["IdBtn1"] = new SelectList(listBotones, "Id", "BtnTitulo", tbIndSlidecab.IdBtn1);

            return View(tbIndSlidecab);
        }


        
        // POST: Slide/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Titulo,Imagen,IdBtn1")] TbIndSlidecab tbIndSlidecab)
        {
            
            var boton = new ConfBotonesCmsService(new HttpClient());
            var listBotones = await boton.listarBotones();
            var slide = new SlideCmsService(new HttpClient());

            if (id != tbIndSlidecab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await slide.UpdateSlide(id,tbIndSlidecab);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdBtn1"] = new SelectList(listBotones, "Id", "BtnTitulo", tbIndSlidecab.IdBtn1);
            
            return View(tbIndSlidecab);
        }
        
        // GET: Slide/Delete/5
        public async Task<IActionResult> Delete(uint id)
        {
            var slide = new SlideService(new HttpClient());
            var slideList = await slide.ListarSlide();
            var slideCms = new SlideCmsService(new HttpClient());
            if (id == 0 || slideList  == null)
            {
                return NotFound();
            }

            var tbIndSlidecab = await slideCms.GetDetails(id);
            if (tbIndSlidecab == null)
            {
                return NotFound();
            }

            return View(tbIndSlidecab);
        }

        // POST: Slide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var slide = new SlideService(new HttpClient());
            var slideList = await slide.ListarSlide();
            var slideCms = new SlideCmsService(new HttpClient());
            if (slideList == null)
            {
                return Problem("Entity set 'CentralparkingContext.TbIndSlidecabs'  is null.");
            }
           
            if (id != 0)
            {
                await slideCms.DeleteSlide(id);
            }

         
            return RedirectToAction(nameof(Index));
        }
        /*
        private bool TbIndSlidecabExists(uint id)
        {
            return (_context.TbIndSlidecabs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
         */
    }
}
