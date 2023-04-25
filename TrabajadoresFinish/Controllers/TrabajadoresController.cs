using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabajadoresFinish.Data;
using TrabajadoresFinish.Models;

namespace TrabajadoresFinish.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly DataContext _context;

        public TrabajadoresController(DataContext dataContext)
        {
            _context = dataContext;
        }

        public IActionResult Index()
        {
            var listado = _context.Trabajadores.ToList();
            return View(listado);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var TiposDocumentos = new List<TiposDocumentos>();
            TiposDocumentos.Add(new Models.TiposDocumentos { TipoDocumento = "DNI", NombreDocumento = "DNI" });
            TiposDocumentos.Add(new Models.TiposDocumentos { TipoDocumento = "CXE", NombreDocumento = "Carnet Extranjeria" });
            TiposDocumentos.Add(new Models.TiposDocumentos { TipoDocumento = "PAS", NombreDocumento = "Pasaporte" });
            ViewData["TipoDocumento"] = new SelectList(TiposDocumentos, "TipoDocumento", "NombreDocumento");

            var Departamentos = await _context.Departamento.ToListAsync();
            ViewData["IdDepartamento"] = new SelectList(Departamentos, "Id", "NombreDepartamento");
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Trabajadores model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.Trabajadores.FindAsync(id);

            var TiposDocumentos = new List<TiposDocumentos>();
            TiposDocumentos.Add(new Models.TiposDocumentos { TipoDocumento = "DNI", NombreDocumento = "DNI" });
            TiposDocumentos.Add(new Models.TiposDocumentos { TipoDocumento = "CXE", NombreDocumento = "Carnet Extranjeria" });
            TiposDocumentos.Add(new Models.TiposDocumentos { TipoDocumento = "PAS", NombreDocumento = "Pasaporte" });
            ViewData["TipoDocumento"] = new SelectList(TiposDocumentos, "TipoDocumento", "NombreDocumento", model.TipoDocumento);

            var Departamentos = await _context.Departamento.ToListAsync();
            ViewData["IdDepartamento"] = new SelectList(Departamentos, "Id", "NombreDepartamento", model.IdDepartamento);

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Trabajadores model)
        {
            var modelOld = await _context.Trabajadores.FindAsync(model.Id);
            modelOld!.Nombres = model.Nombres;
            modelOld!.TipoDocumento = model.TipoDocumento;
            modelOld!.NumeroDocumento = model.NumeroDocumento;
            modelOld!.IdDepartamento = model.IdDepartamento;
            modelOld!.IdProvincia = model.IdProvincia;
            modelOld!.IdDistrito = model.IdDistrito;
            _context.Update(modelOld);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Trabajadores.FindAsync(id);
            if (model != null)
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

