using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabajadoresFinish.Data;
using TrabajadoresFinish.Models;

namespace TrabajadoresFinish.Controllers
{
    public class DistritosController : Controller
    {
        // GET: /<controller>/
        private readonly DataContext _context;

        public DistritosController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpGet]
        public async Task<JsonResult> CargarDistritos(int id)
        {
            var listado = await _context.Distrito.Where(t => t.IdProvincia.Equals(id)).ToListAsync();
            return Json(listado);
        }


        public async Task<IActionResult> Index(int id)
        {
            var listado = _context.Distrito.Where(t => t.IdProvincia.Equals(id)).ToList();
            var Provincia = await _context.Provincia.FindAsync(id);
            ViewBag.Provincia = Provincia;
            return View(listado);
        }

        [HttpGet]
        public IActionResult Create(int IdProvincia)
        {
            return PartialView(new Distrito { IdProvincia = IdProvincia });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Distrito model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = model.IdProvincia });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.Distrito.FindAsync(id);
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Distrito model)
        {
            var modelOld = await _context.Distrito.FindAsync(model.Id);
            modelOld!.NombreDistrito = model.NombreDistrito;
            _context.Update(modelOld);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id = model.IdProvincia });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            int idProvincia = 0;
            var model = await _context.Distrito.FindAsync(id);
            if (model != null)
            {
                idProvincia = model.IdProvincia;
                _context.Remove(model);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { id = idProvincia });
        }
    }
}

