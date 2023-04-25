using Microsoft.AspNetCore.Mvc;
using TrabajadoresFinish.Data;
using TrabajadoresFinish.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrabajadoresFinish.Controllers
{
    public class ProvinciasController : Controller
    {
        private readonly DataContext _context;

        public ProvinciasController(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IActionResult> Index(int id)
        {
            var listado = _context.Provincia.Where(t=>t.IdDepartamento.Equals(id)).ToList();

            var Departamento = await _context.Departamento.FindAsync(id);

            ViewBag.Departamento = Departamento;
            return View(listado);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            return PartialView(new Provincia { IdDepartamento = id });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Provincia model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.Departamento.FindAsync(id);
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Provincia model)
        {
            var modelOld = await _context.Provincia.FindAsync(model.Id);
            modelOld!.NombreProvincia = model.NombreProvincia;
            _context.Update(modelOld);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Provincia.FindAsync(id);
            if (model != null)
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

