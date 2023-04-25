using Microsoft.AspNetCore.Mvc;
using TrabajadoresFinish.Data;
using TrabajadoresFinish.Models;

namespace TrabajadoresFinish.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly DataContext _context;

        public DepartamentosController(DataContext dataContext)
        {
            _context = dataContext;
        }


        public IActionResult Index()
        {
            var departamentos = _context.Departamento.ToList();
            return View(departamentos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new Departamento();
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento model)
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
        public async Task<IActionResult> Edit(Departamento model)
        {
            var departamentoOld = await _context.Departamento.FindAsync(model.Id);
            departamentoOld!.NombreDepartamento = model.NombreDepartamento;
            _context.Update(departamentoOld);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Departamento.FindAsync(id);
            if (model != null)
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

